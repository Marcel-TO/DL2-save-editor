namespace Editor_Model.Logic
{
    using Editor_Model.Items;
    using System;

    public class SaveFile
    {
        private string path;

        private byte[] fileData;

        private string fileContent;

        private UnlockableItems[] unlockableItems;

        private List<InventoryItem[]> items;

        private Skills skills;

        public SaveFile(string filepath, byte[] fileData, string fileContent, List<InventoryItem[]> items, Skills skills, UnlockableItems[] unlockableItems)
        {
            this.Path = filepath;
            this.FileData = fileData;
            this.FileContent = fileContent;
            this.Items = items;
            this.UnlockableItems = unlockableItems;
            this.Skills = skills;
        }

        public string Path
        {
            get
            {
                return this.path;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Path)} must not be null.");
                }

                this.path = value;
            }
        }

        public byte[] FileData
        {
            get
            {
                return this.fileData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.FileData)} must not be null.");
                }

                this.fileData = value;
            }
        }

        public string FileContent
        {
            get
            {
                return this.fileContent;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.FileContent)} must not be null.");
                }

                this.fileContent = value;
            }
        }

        public List<InventoryItem[]> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Items)} must not be null.");
                }

                this.items = value;
            }
        }

        public UnlockableItems[] UnlockableItems
        {
            get
            {
                return this.unlockableItems;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.UnlockableItems)} must not be null.");
                }

                this.unlockableItems = value;
            }
        }

        public Skills Skills
        {
            get
            {
                return this.skills;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Skills)} must not be null.");
                }

                this.skills = value;
            }
        }
    }
}
