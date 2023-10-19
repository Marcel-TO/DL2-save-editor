namespace Editor_Model.Logic
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Editor_Model.EventArgs;
    using Editor_Model.Items;
    using System.Diagnostics.Metrics;
    using System.Reflection.Metadata;
    using System.IO;

    public class FileAnalizer
    {
        private static byte[] startSkills = new byte[]
        {
            0x41, 0x6E, 0x74, 0x69, 0x7A, 0x69, 0x6E, 0x43,
            0x61, 0x70, 0x61, 0x63, 0x69, 0x74, 0x79, 0x55,
            0x70, 0x67, 0x72, 0x61, 0x64, 0x65, 0x53, 0x74,
            0x61, 0x6D, 0x69, 0x6E, 0x61, 0x5F, 0x73, 0x6B,
            0x69, 0x6C, 0x6C
        };

        private static byte[] endSkills = new byte[]
        {
            0x50, 0x72, 0x6F, 0x67, 0x72, 0x65, 0x73, 0x73,
            0x69, 0x6F, 0x6E, 0x53, 0x74, 0x61, 0x74, 0x65,
            0x3A, 0x3A, 0x45, 0x45, 0x6C, 0x65, 0x6D, 0x65,
            0x6E, 0x74, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F,
            0x6E
        };

        private static byte[] startInventory = new byte[]
        {
            0x54, 0x6F, 0x6B, 0x65, 0x6E, 0x00, 0x00, 0x00,
            0x00, 0x07, 0x00, 0x55, 0x6E, 0x6B, 0x6E, 0x6F, 0x77, 0x6E
        };

        public event EventHandler<ExtractBytesEventArgs> ExtractBytes;

        public event EventHandler<FoundMatchesEventArgs> FoundMatches;

        public event EventHandler<AnalizedSaveFileEventArgs> AnalizedSaveFile;

        public event EventHandler<ErrorMessageEventArgs> ErrorMessage;

        public event EventHandler<ReadFileEventArgs> ReadFile;

        /// <summary>
        /// Reads the content of the file.
        /// </summary>
        /// <param name="filePath">The filepath of the selected file.</param>
        public void ReadFileContent(string filePath)
        {
            try
            {
                // Open the file for reading in binary mode
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Create a byte array to hold the file contents
                    byte[] fileContents = new byte[fs.Length];

                    // Read the binary data from the file into the byte array
                    fs.Read(fileContents, 0, (int)fs.Length);

                    //// the fileContents byte array contains the binary data from the file
                    this.ReadFile?.Invoke(this, new ReadFileEventArgs(filePath, fileContents));
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage?.Invoke(this, new ErrorMessageEventArgs("An error occurred: " + ex.Message));
            }
        }

        /// <summary>
        /// Represents the method for finding all skills inside the save.
        /// </summary>
        /// <param name="data">The data of the current save.</param>
        /// <returns>All found skills.</returns>
        private string[] FindSkillMatches(byte[] data)
        {
            List<string> matches = new List<string>();
            string stringData = Encoding.UTF8.GetString(data);
            
            string pattern = @"([A-Za-z0-9_]+_skill)";
            MatchCollection matchCollection = Regex.Matches(stringData, pattern);

            // Iterates through each match.
            foreach (Match match in matchCollection)
            {
                if (match.Success)
                {
                    matches.Add(match.Value);
                }
            }

            return matches.ToArray();
        }

        /// <summary>
        /// Represents the method for analyzing the found skill matches and finds the corresponding index.
        /// </summary>
        /// <param name="data">The data of the current save.</param>
        /// <param name="matches">All skills that match the skill pattern.</param>
        /// <param name="startingIndex">The starting index of the needed data.</param>
        /// <returns>All matching skills.</returns>
        private SkillIItem[] AnalizeSkillData(byte[] data, string[] matches, int startingIndex)
        {
            List<SkillIItem> skills = new List<SkillIItem>();

            for (int i = 0; i < matches.Length; i++)
            {
                byte[] matchBytes = Encoding.UTF8.GetBytes(matches[i]);
                int index = this.FindSequenceIndex(data, 0, matchBytes, false) + startingIndex; // Due to the startingindex Offset
                skills.Add(new SkillIItem(matches[i].Replace("\x00", "").TrimEnd('\x01'), index, matchBytes.Length,matchBytes,this.ExtractByteInRange(data, index + matchBytes.Length, index + matchBytes.Length + 2)));
            }

            return skills.ToArray();
        }

        /// <summary>
        /// Represents a method for loading a savefile and preparing all necessary information.
        /// </summary>
        /// <param name="filePath">The filepath of the current selected save.</param>
        /// <param name="data">The data of the current selected save.</param>
        public void LoadSaveFile(string filePath, byte[] data)
        {
            // find all skills.
            int skillStartIndex = this.FindSequenceIndex(data, 0, startSkills, true);
            int skillEndIndex = this.FindSequenceIndex(data, 0, endSkills, false);
            byte[] skillDataRange = this.ExtractByteInRange(data, skillStartIndex, skillEndIndex);
            SkillIItem[] skills = this.AnalizeSkillData(skillDataRange, this.FindSkillMatches(skillDataRange), skillStartIndex);

            // find all unlockable items.
            UnlockableItems[] unlockItems = this.AnalizeUnlockableItemsData(data);
            UnlockableItems lastItem = unlockItems[unlockItems.Length - 1];

            // the space between the SGD IDs and chunk data.
            int jumpOffset = lastItem.Index + lastItem.Size + 75;

            // get all items within the inventory.
            List<InventoryItem[]> items = this.GetAllItems(data, jumpOffset);
            this.AnalizedSaveFile?.Invoke(this, new AnalizedSaveFileEventArgs(new SaveFile(filePath, data, BitConverter.ToString(data).Replace("-", " "), items, skills, unlockItems)));
        }

        /// <summary>
        /// Represents the method for finding all items inside the inventory.
        /// </summary>
        /// <param name="data">The data of the current selected save.</param>
        /// <param name="startIndex">The start index of the inventory data.</param>
        /// <returns>The list of all different item sections.</returns>
        private List<InventoryItem[]> GetAllItems(byte[] data, int startIndex) {
            List<InventoryItem[]> items = new List<InventoryItem[]>();
            int index = startIndex;

            while (true) 
            {
                // Prepare the inner item section.
                List<InventoryItem> innerItemList = new List<InventoryItem>();
                // Find all data chunks for the section.
                (InventoryChunk[] chunks, int newIndex) = this.FindAllInventoryChunks(data, index);

                // Check if there are no chunks left.
                if (chunks.Length == 0)
                {
                    break;
                }

                // Find the corresponding matches to each chunk (Including Mod data).
                (string[] currentItemIDs, int[] currentItemIndizes) = this.FindAmountOfMatches(data, newIndex, chunks.Length);

                // Preparing iteration data.
                int modCounter = 0;
                string currentItemID = string.Empty;
                int currentItemIndex = 0;
                int chunkCounter = 0;
                InventoryChunk currentInvChunk = chunks[0];
                byte[] matchBytes = Encoding.UTF8.GetBytes(currentItemID);
                List<Mod> mods = new List<Mod>();

                // Iterate through each found match and validate the position of the match.
                for (int i = 0; i < currentItemIDs.Length; i++)
                {
                    var test = currentItemIDs[i];
                    // Check if the match is an item or a mod.
                    if (!currentItemIDs[i].Contains("Mod") && !currentItemIDs[i].Contains("charm") && currentItemIDs[i] != "NoneSGDs" && currentItemIDs[i] != "SGDs")
                    {
                        // Check if the bullet acts as item or mod or if there is a transmog item.
                        if ((currentItemIDs[i].Contains("Bullet") && modCounter > 0 && modCounter < 4) || modCounter == 3)
                        {
                            mods.Add(new Mod(currentItemIDs[i], currentItemIndizes[i], this.ExtractByteInRange(data, currentItemIndizes[i], currentItemIndizes[i] + 30)));
                            modCounter++;
                            continue;
                        }

                        // Add the previous item if exists to the list.
                        if (currentItemID != string.Empty && mods.Count != 0)
                        {
                            innerItemList.Add(new InventoryItem(currentItemID.Replace("\x00", "").TrimEnd('\x01'), currentItemIndex, matchBytes.Length, matchBytes, currentInvChunk, mods.ToArray()));
                            modCounter = 0;
                            mods.Clear();
                        }

                        // Set the current item initialization.
                        currentItemID = currentItemIDs[i];
                        matchBytes = Encoding.UTF8.GetBytes(currentItemIDs[i]);
                        currentItemIndex = currentItemIndizes[i];
                        currentInvChunk = chunks[chunkCounter];
                        chunkCounter++;
                    }
                    // add mod to mods list
                    else
                    {
                        mods.Add(new Mod(currentItemIDs[i], currentItemIndizes[i], this.ExtractByteInRange(data, currentItemIndizes[i], currentItemIndizes[i] + 30)));
                        modCounter++;
                    }
                }

                // Add the last item
                innerItemList.Add(new InventoryItem(currentItemID.Replace("\x00", "").TrimEnd('\x01'), currentItemIndex, matchBytes.Length, matchBytes, currentInvChunk, mods.ToArray()));

                // add the inner section to the item list and fix index by offset.
                items.Add(innerItemList.ToArray());
                Mod lastMod = innerItemList[innerItemList.Count - 1].Mod[innerItemList[innerItemList.Count - 1].Mod.Length - 1];
                index = lastMod.Index + lastMod.Name.Length;
                index += 75;
            }

            return items;
        }

        /// <summary>
        /// Represents the method for finding all matches for each chunk.
        /// </summary>
        /// <param name="content">The content of the inventory.</param>
        /// <param name="startIndex">The start index of the search.</param>
        /// <param name="amount">The amount of chunks found for the current section.</param>
        /// <returns>A tuple that contains the matches for the current chunk and their corresponding index.</returns>
        private (string[], int[]) FindAmountOfMatches(byte[] content, int startIndex, int amount)
        {
            // Prepare data for iteration.
            int counter = 0;
            int modCounter = 0;
            List<string> matchValues = new List<string>();
            string currentItem = string.Empty;
            string stringData = Encoding.UTF8.GetString(this.ExtractByteInRange(content, startIndex, content.Length));

            // Finds the first match when comparing it with the pattern.
            string pattern = @"[A-Za-z0-9_]*SGDs";
            Match match = Regex.Match(stringData, pattern);
            Match savegameMatch = Regex.Match(stringData, "Savegame");

            while (match.Success)
            {
                // There are mod slots for each item. Even tokens, I mean why not Techland, right?
                // Check if the amount of item matches is in range and if the length of the match is at least 4.
                if (counter <= amount && match.Value.Length >= 4)
                {
                    // Check if it is an item or a mod.
                    if (!match.Value.Contains("Mod") && !match.Value.Contains("charm") && match.Value != "NoneSGDs" && match.Value != "SGDs")
                    {
                        // Check if the bullet acts as item or mod.
                        if ((match.Value.Contains("Bullet") && modCounter > 0 && modCounter <= 4) || modCounter == 4)
                        {
                            matchValues.Add(match.Value);
                            match = match.NextMatch();
                            modCounter++;
                            continue;
                        }

                        // update data.
                        counter++;
                        modCounter = 0;
                        currentItem = match.Value;
                    }
                    // Checks if the SGDs is at the end of the found list.
                    else if (match.Value == "SGDs" && modCounter != 4)
                    {
                        break;
                    }
                    // Checks if the match equals SGDs, since it is also possible for weapon mods.
                    else if (match.Value == "SGDs") 
                    {
                        // Check if Savegame indicator is between
                        if (savegameMatch.Index < match.Index)
                        {
                            break;
                        }

                        matchValues.Add(match.Value);
                        match = match.NextMatch();
                        continue;
                    }

                    // Add the match to the values and update counter.
                    matchValues.Add(match.Value);
                    modCounter++;
                }
                else
                {
                    break;
                }

                match = match.NextMatch();
            }

            int[] matchIndices = this.GetIndicesFromValues(content, startIndex, matchValues.ToArray());
            return (matchValues.ToArray(), matchIndices);
        }

        /// <summary>
        /// Represents a method for finding the indices for each matching value.
        /// </summary>
        /// <param name="content">The data of the save.</param>
        /// <param name="startIndex">The startIndex of the inventory</param>
        /// <param name="values">The matching values of the items.</param>
        /// <returns>The indices for each matching value.</returns>
        private int[] GetIndicesFromValues(byte[] content, int startIndex, string[] values)
        {
            List<int> matchIndices = new List<int>();

            // Get first index.
            if (values.Length > 0)
            {
                int index = this.FindSequenceIndex(content, startIndex, Encoding.UTF8.GetBytes(values[0]), false);
                matchIndices.Add(index);
            }

            // Add the rest of the indices.
            for (int i = 1; i < values.Length; i++)
            {
                byte[] matchBytes = Encoding.UTF8.GetBytes(values[i]);
                int tempIndex = matchIndices[i - 1] + Encoding.UTF8.GetByteCount(values[i - 1]);
                matchIndices.Add(this.FindSequenceIndex(content, tempIndex, matchBytes, false));
            }

            return matchIndices.ToArray();
        }

        /// <summary>
        /// Represents a method for analyzing and extracting the data for each unlockable item.
        /// </summary>
        /// <param name="fileContents">The data of the save.</param>
        /// <returns>All unlockable items inside the inventory.</returns>
        private UnlockableItems[] AnalizeUnlockableItemsData(byte[] fileContents)
        {
            // Finds all inventory sequences inside the file.
            int[] indizes = this.FindAllSequences(fileContents, 0, startInventory, true);
            List<UnlockableItems> items = new List<UnlockableItems>();

            // Checks if the sequence is not valid.
            if (indizes == null || indizes.Length != 2)
            {
                this.ErrorMessage?.Invoke(this, new ErrorMessageEventArgs("Start pattern(s) not found in file."));
                return items.ToArray();
            }

            // Takes the second inventory index for needed information.
            int startIndex = indizes[1];
            // Compresses the data and only extracts the inventory part of the file.
            byte[] inventoryData = this.ExtractByteInRange(fileContents, startIndex, fileContents.Length - 1);
            // Prepares a list of all matching strings.
            List<int> matchingStringIndizes = new List<int>();

            // Checks for all unlockableitem IDs.
            // The "_" is important, so that it doesn't include items like "hint_collectable".
            int[] craftPlanIndizes = this.FindAllSequences(inventoryData, 0, Encoding.UTF8.GetBytes(ItemTypeEnum.Craftplan.ToString() + "_"), false);
            int[] toolSkinIndizes = this.FindAllSequences(inventoryData, 0, Encoding.UTF8.GetBytes(ItemTypeEnum.ToolSkin.ToString() + "_"), false);
            int[] collectableIndizes = this.FindAllSequences(inventoryData, 0, Encoding.UTF8.GetBytes(ItemTypeEnum.Collectable.ToString() + "_"), false);
            matchingStringIndizes.AddRange(craftPlanIndizes);
            matchingStringIndizes.AddRange(toolSkinIndizes);
            matchingStringIndizes.AddRange(collectableIndizes);

            if (matchingStringIndizes.Count == 0)
            {
                this.ErrorMessage?.Invoke(this, new ErrorMessageEventArgs("No matching strings found."));
                return items.ToArray();
            }

            for (int i = 0; i < matchingStringIndizes.Count; i++)
            {
                string cleanString = this.GetFullString(inventoryData, matchingStringIndizes[i]);
                int currentIndex = matchingStringIndizes[i] + startIndex;
                int size = Encoding.UTF8.GetBytes(cleanString).Length;
                // Console.WriteLine($"Index/Offset: {currentIndex}, Size: {size}, String: {cleanString}");
                byte[] sdg = this.ExtractByteInRange(inventoryData, matchingStringIndizes[i], matchingStringIndizes[i] + size);
                items.Add(new UnlockableItems(cleanString, currentIndex, size, sdg));
            }

            // Sort the itemlist, so that the last entry is at the end
            UnlockableItems[] sortedItems = items.OrderBy(x => x.Index).ToArray();
            return sortedItems;
        }

        /// <summary>
        /// Represents a method for finding all SDG chunks inside the inventory.
        /// </summary>
        /// <param name="content">The content of the current save file.</param>
        /// <param name="startIndex">The starting index on where the search begins.</param>
        /// <returns>The array of all found chunks inside the inventory.</returns>
        public (InventoryChunk[], int) FindAllInventoryChunks(byte[] content, int startIndex)
        {
            // Checks if the index is out of range.
            if (startIndex > content.Length)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(startIndex)} must not greater than the content itself.");
            }

            List<InventoryChunk> chunks = new List<InventoryChunk>();

            // Preparing offsets.
            int levelOffset = 2;
            int seedOffset = 2;
            int amountOffset = 4;
            int durabilityOffset = 4;
            int spaceOffset = 25;
            int dataOffset = levelOffset + seedOffset + amountOffset + durabilityOffset + spaceOffset;

            // Finding all SGD matches and their corresponding indices.
            (string[] matchValues, int[] matchIndizes) = this.GetSGDMatches(content, startIndex);

            // Check if no matches where found.
            if (matchValues.Length == 0)
            {
                return (chunks.ToArray(), -1);
            }

            // Iterate through each value and get the needed 12 Bytes of data.
            for (int i = 0; i < matchValues.Length; i++)
            {
                if (matchIndizes[i] - dataOffset < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(matchIndizes)} at the index {i} must not be negative.");
                }

                int dataIndex = matchIndizes[i] - dataOffset;
                byte[] levelData = new byte[] { };
                byte[] seedData = new byte[] { };
                byte[] amountData = new byte[] { };
                byte[] DurabilityData = new byte[] { };
                byte[] chunkSpace = new byte[] { };

                // Extracts the content
                int index = dataIndex;
                levelData = this.ExtractByteInRange(content, index, index + levelOffset);
                index += levelOffset;
                seedData = this.ExtractByteInRange(content, index, index + seedOffset);
                index += seedOffset;
                amountData = this.ExtractByteInRange(content, index, index + amountOffset);
                index += amountOffset;
                DurabilityData = this.ExtractByteInRange(content, index, index + durabilityOffset);
                index += durabilityOffset;
                chunkSpace = this.ExtractByteInRange(content, index, index + spaceOffset);

                chunks.Add(new InventoryChunk(levelData, seedData, amountData, DurabilityData, chunkSpace, dataIndex));
            }

            // The 4 is for the SDGs name offset.
            int lastIndex = chunks[chunks.Count - 1].DataIndex + dataOffset + 4;
            return (chunks.ToArray(), lastIndex);
        }

        /// <summary>
        /// Represents a method for finding all sgd matches inside the range.
        /// </summary>
        /// <param name="content">The data of the current save.</param>
        /// <param name="startIndex">The index from where the search starts.</param>
        /// <returns>The matching vales and their corresponding indices.</returns>
        private (string[], int[]) GetSGDMatches(byte[] content, int startIndex)
        {
            // Preparing data.
            List<string> matchValues = new List<string>();
            string stringData = Encoding.UTF8.GetString(this.ExtractByteInRange(content, startIndex, content.Length));

            string pattern = @"[A-Za-z0-9_]*SGDs";
            Match match = Regex.Match(stringData, pattern);

            while (match.Success)
            {
                // Looking for all SGDs inside the current chunk.
                if (match.Value.Length == 4)
                {
                    matchValues.Add(match.Value);
                }
                else
                {
                    break;
                }

                match = match.NextMatch();
            }

            int[] matchIndices = this.GetIndicesFromValues(content, startIndex, matchValues.ToArray());

            // Check if Savegame section is between the start and the first SGDs.
            bool isSavegame = false;
            int firstIndex = 0;
            if (matchValues.Count > 1)
            {
                firstIndex = matchIndices[0];
            }

            isSavegame = this.IsSavegameBetween(content, startIndex, firstIndex);

            // Reset matches if savegame is between.
            if (isSavegame)
            {
                matchValues.Clear();
                matchIndices = new int[] {};
            }

            return (matchValues.ToArray(), matchIndices);
        }

        /// <summary>
        /// Represents a method for checking, whether savegame is between the items.
        /// </summary>
        /// <param name="data">The content of the current save.</param>
        /// <param name="startIndex">The starting index of the query.</param>
        /// <param name="endIndex">The ending index of the query.</param>
        /// <returns>Indicates whether savegame is between the items or not.</returns>
        private bool IsSavegameBetween(byte[] data, int startIndex, int endIndex)
        {
            byte[] targetData = this.ExtractByteInRange(data, startIndex, endIndex);
            int index = this.FindSequenceIndex(targetData, 0, Encoding.UTF8.GetBytes("Savegame"), false);

            if (index < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Represents a method for converting to string and removing unnecessary characters.
        /// </summary>
        /// <param name="data">The data from the save file.</param>
        /// <param name="index">The index of the string.</param>
        /// <returns>The trimmed string.</returns>
        private string GetFullString(byte[] data, int index)
        {
            for (int i = index; i < data.Length; i++)
            {
                if (Encoding.UTF8.GetString(new byte[] { data[i] }) == "\x00")
                {
                    return Encoding.UTF8.GetString(this.ExtractByteInRange(data, index, i)).Replace("\x00", "").TrimEnd('\x01');
                }
            }

            return Encoding.UTF8.GetString(this.ExtractByteInRange(data, index, data.Length)).Replace("\x00", "").TrimEnd('\x01');
        }

        /// <summary>
        /// Represents a method for finding a specific sequence inside an array.
        /// </summary>
        /// <param name="data">The data from the save file.</param>
        /// <param name="startingIndex">The starting index of the iteration.</param>
        /// <param name="sequence">The wanted sequence.</param>
        /// <param name="isStart">Indicates whether the sequence is at before or after the searched index.</param>
        /// <returns>Returns the index of the specific sequence.</returns>
        private int FindSequenceIndex(byte[] data, int startingIndex, byte[] sequence, bool isStart)
        {
            // iterates through the data.
            for (int i = startingIndex; i < data.Length; i++)
            {   
                // resets values for each inner iteration.
                bool isValid = true;
                int lastIndex = 0;

                // checks if the sequence starts with the same value as the current data.
                for (int s = 0; s < sequence.Length; s++)
                {
                    lastIndex = i + s;
                    if (data[lastIndex] != sequence[s])
                    {
                        isValid = false;
                        break;
                    }
                }

                // checks if it is the start sequence or the end sequence.
                if (isValid && isStart)
                {
                    return lastIndex + 1;
                }
                else if (isValid)
                {
                    return i;
                }
            } 

            // returns negative if sequence not found.
            return -1;
        }

        /// <summary>
        /// Represents a method for finding all sequences inside an byte array.
        /// </summary>
        /// <param name="data">The data from a save file.</param>
        /// <param name="startingIndex">The starting index of the iteration.</param>
        /// <param name="sequence">The wanted sequence.</param>
        /// <param name="isStart">Indicates whether the sequence is at before or after the searched index.</param>
        /// <returns>Returns the indizes for each found sequence.</returns>
        private int[] FindAllSequences(byte[] data, int startingIndex, byte[] sequence, bool isStart)
        {
            List<int> sequences = new List<int>();

            // iterates through the data.
            for (int i = startingIndex; i < data.Length - sequence.Length; i++)
            {
                // resets values for each inner iteration.
                bool isValid = true;
                int lastIndex = 0;

                // checks if the sequence starts with the same value as the current data.
                for (int s = 0; s < sequence.Length; s++)
                {
                    lastIndex = i + s;
                    if (data[lastIndex] != sequence[s])
                    {
                        isValid = false;
                        break;
                    }
                }

                // checks if it is the start sequence or the end sequence.
                if (isValid && isStart)
                {
                    sequences.Add(lastIndex + 1);
                }
                else if (isValid)
                {
                    sequences.Add(i);
                }
            }

            // returns negative if sequence not found.
            return sequences.ToArray();
        }

        /// <summary>
        /// Represents a method for extracting a sequence from a byte array.
        /// </summary>
        /// <param name="data">The data of the save file.</param>
        /// <param name="startIndex">The starting index of the data.</param>
        /// <param name="endIndex">The end index of the data.</param>
        /// <returns>The data between the start and the end index.</returns>
        private byte[] ExtractByteInRange(byte[] data, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex <= 0 || endIndex > data.Length)
            {
                this.ExtractBytes?.Invoke(this, new ExtractBytesEventArgs(new byte[0]));
                return new byte[0];
            }

            byte[] compactData = new byte[endIndex - startIndex];
            for (int i = startIndex; i < endIndex; i++)
            {
                compactData[i - startIndex] = data[i];
            }

            return compactData;
        }
    }
}