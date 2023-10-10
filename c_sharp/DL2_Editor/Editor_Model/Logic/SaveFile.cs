namespace Editor_Model.Logic
{
    using Editor_Model.Items;
    using System;

    public class SaveFile
    {
        private string path;

        private byte[] fileData;

        private string fileContent;

        private BaseItem[] items;

        private InventoryChunk[] chunks;

        private BaseItem[] skills;

        public SaveFile(string filepath, byte[] fileData, string fileContent, BaseItem[] items, InventoryChunk[] chunks, BaseItem[] skills)
        {
            this.Path = filepath;
            this.FileData = fileData;
            this.FileContent = fileContent;
            this.Items = items;
            this.Chunks = chunks;
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

            private set
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

        public BaseItem[] Items
        {
            get
            {
                return this.items;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Items)} must not be null.");
                }

                this.items = value;
            }
        }

        public InventoryChunk[] Chunks
        {
            get
            {
                return this.chunks;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Chunks)} must not be null.");
                }

                this.chunks = value;
            }
        }

        public BaseItem[] Skills
        {
            get
            {
                return this.skills;
            }

            private set
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
