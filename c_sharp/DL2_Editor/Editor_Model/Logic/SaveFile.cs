namespace Editor_Model.Logic
{
    using Editor_Model.Items;
    using System;

    public class SaveFile
    {
        private byte[] fileData;

        private string fileContent;

        private BaseItem[] items;

        private InventoryChunk[] chunks;

        public SaveFile(byte[] fileData, string fileContent, BaseItem[] items, InventoryChunk[] chunks)
        {
            this.FileData = fileData;
            this.FileContent = fileContent;
            this.Items = items;
            this.Chunks = chunks;
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
    }
}
