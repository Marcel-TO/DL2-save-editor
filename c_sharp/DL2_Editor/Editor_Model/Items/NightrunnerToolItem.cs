namespace Editor_Model.Items
{
    using Editor_Model.Logic;
    using System;

    public class NightrunnerToolItem : InventoryItem
    {
        private byte[] _toolData;
        public NightrunnerToolItem(string name, int index, int size, byte[] sgdData, InventoryChunk chunkData, Mod[] mod, byte[] toolData) : base(name, index, size, sgdData, chunkData, mod)
        {
            this.ToolData = toolData;
        }

        public byte[] ToolData
        {
            get
            {
                return this._toolData;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.ToolData)} must not be null.");
                }

                this._toolData = value;
            }
        }
    }
}
