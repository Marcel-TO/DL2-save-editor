namespace Editor_Model.Items
{
    using System;
    using Editor_Model.Logic;

    public class InventoryItem : BaseItem
    {
        private InventoryChunk _chunkData;

        private Mod[] mod;

        public InventoryItem(string name, int index, int size, byte[] sdgData, InventoryChunk chunkData, Mod[] mod) : base(name, index, size, sdgData)
        {
            this.ChunkData = chunkData;
            this.Mod = mod;
        }

        public InventoryChunk ChunkData
        {
            get
            {
                return this._chunkData;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.ChunkData)} must not be null.");
                }

                this._chunkData = value;
            }
        }

        public Mod[] Mod
        {
            get
            {
                return this.mod;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Mod)} must not be null.");
                }

                this.mod = value;
            }
        }
    }
}
