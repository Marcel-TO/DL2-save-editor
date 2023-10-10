namespace Editor_Model.Logic
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Editor_Model.EventArgs;
    using Editor_Model.Items;

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


        public FileAnalizer()
        {

        }

        public event EventHandler<ExtractBytesEventArgs> ExtractBytes;

        public event EventHandler<FoundMatchesEventArgs> FoundMatches;

        public event EventHandler<AnalizedSaveFileEventArgs> AnalizedSaveFile;

        public event EventHandler<ErrorMessageEventArgs> ErrorMessage;

        public event EventHandler<ReadFileEventArgs> ReadFile;

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

        private string[] FindSkillMatches(byte[] data)
        {
            List<string> matches = new List<string>();
            string stringData = Encoding.UTF8.GetString(data);
            
            string pattern = @"([A-Za-z0-9_]+_skill)(..)";
            MatchCollection matchCollection = Regex.Matches(stringData, pattern);

            foreach (Match match in matchCollection)
            {
                if (match.Success)
                {
                    matches.Add(match.Value);
                }
            }

            return matches.ToArray();
        }

        private BaseItem[] AnalizeSkillData(byte[] data, string[] matches, int startingIndex)
        {
            List<BaseItem> skills = new List<BaseItem>();

            for (int i = 0; i < matches.Length; i++)
            {
                byte[] matchBytes = Encoding.UTF8.GetBytes(matches[i]);
                int index = this.FindSequenceIndex(data, 0, matchBytes, false);
                skills.Add(new SkillIItem(matches[i].Replace("\x00", "").TrimEnd('\x01'), index + startingIndex, matchBytes.Length, matchBytes, BitConverter.ToString(matchBytes).Replace("-", " ")));
            }

            return skills.ToArray();
        }

        public void LoadSaveFile(string filePath, byte[] data)
        {
            // find all skills.
            int skillStartIndex = this.FindSequenceIndex(data, 0, startSkills, true);
            int skillEndIndex = this.FindSequenceIndex(data, 0, endSkills, false);
            byte[] skillDataRange = this.ExtractByteInRange(data, skillStartIndex, skillEndIndex);
            BaseItem[] skills = this.AnalizeSkillData(skillDataRange, this.FindSkillMatches(skillDataRange), skillStartIndex);
            BaseItem[] items = this.AnalizeUnlockableItemsData(data);
            BaseItem lastItem = items[items.Length - 1];

            // the space between the SDG IDs and chunk data.
            int jumpOffset = lastItem.Index + lastItem.Size + 75;
            InventoryChunk[] chunks = this.FindAllInventoryChunks(data, jumpOffset);
            this.AnalizedSaveFile?.Invoke(this, new AnalizedSaveFileEventArgs(new SaveFile(filePath, data, BitConverter.ToString(data).Replace("-", " "), items, chunks, skills)));
        }



        private BaseItem[] AnalizeUnlockableItemsData(byte[] fileContents)
        {
            // Finds all inventory sequences inside the file.
            int[] indizes = this.FindAllSequences(fileContents, 0, startInventory, true);
            List<BaseItem> items = new List<BaseItem>();

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
                items.Add(new UnlockableItems(cleanString, currentIndex, size, sdg, BitConverter.ToString(sdg).Replace("-", " ")));
            }

            // Sort the itemlist, so that the last entry is at the end
            BaseItem[] sortedItems = items.OrderBy(x => x.Index).ToArray();
            //Console.WriteLine(BitConverter.ToString(sortedItems[sortedItems.Length - 1].SdgData).Replace("-", " "));
            //Console.WriteLine($"Summary -> {sortedItems.Length} SDGs where found");

            return sortedItems;
        }

        /// <summary>
        /// Represents a method for finding all SDG chunks inside the inventory.
        /// </summary>
        /// <param name="content">The content of the current save file.</param>
        /// <param name="startIndex">The starting index on where the search begins.</param>
        /// <returns>The array of all found chunks inside the inventory.</returns>
        public InventoryChunk[] FindAllInventoryChunks(byte[] content, int startIndex)
        {
            // Checks if the index is out of range.
            if (startIndex >= content.Length)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(startIndex)} must not greater than the content itself.");
            }

            List<InventoryChunk> chunks = new List<InventoryChunk>();
            int index = startIndex;

            // Preparing offsets.
            int dataOffset = 12;
            int spaceOffset = 25;
            int sdgOffset = 4;
            
            // Iterates through the content until the parsing is not valid anymore
            while (true)
            {
                // Represents the chunkData and the space to the next SDG.
                // The data is always the same offset.
                byte[] chunkData = new byte[] { };
                byte[] chunkSpace = new byte[] { };

                try
                {
                    // Extracts the content
                    chunkData = this.ExtractByteInRange(content, index, index + dataOffset);
                    index += dataOffset;
                    chunkSpace = this.ExtractByteInRange(content, index, index + spaceOffset);
                    index += spaceOffset;

                    // Checks if after the chunk information follows an SDG -> {0x53, 0x47, 0x44, 0x73}
                    if (this.FindSequenceIndex(this.ExtractByteInRange(content, index, index + sdgOffset), 0, new byte[] { 0x53, 0x47, 0x44, 0x73 }, true) != -1)
                    {
                        // Checks if the content starts with 0x00 and the space as well 0x00, otherwise wrong SDGs would be included.
                        if (index > 0 && content[index - 1] == 0x00 && chunkSpace[0] == 0x00)
                        {
                            //Console.WriteLine($"{chunks.Count + 1}");
                            //Console.WriteLine(" ");
                            //Console.WriteLine("12 Bytes After Jump (Hex):");
                            //Console.WriteLine(BitConverter.ToString(chunkData).Replace("-", " "));
                            //Console.WriteLine("25 Bytes After 12 Bytes (Hex):");
                            //Console.WriteLine(BitConverter.ToString(chunkSpace).Replace("-", " "));
                            //Console.WriteLine(" ");
                            //Console.WriteLine($"SDGs found! Offset: {index}");
                            //Console.WriteLine(" ");
                            //Console.WriteLine("=======================================================================");
                            chunks.Add(new InventoryChunk(chunkData, chunkSpace));
                        }
                    }
                    else
                    {
                        break;
                    }

                    // After the SDG are 75 space. Due to the SDG length from before, we have to add it to the index.
                    index += 75 + sdgOffset;
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }

            return chunks.ToArray();
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