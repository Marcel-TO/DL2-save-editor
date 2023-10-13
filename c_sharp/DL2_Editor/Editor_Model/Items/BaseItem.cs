namespace Editor_Model.Items
{
    using Editor_Model.Logic;
    using System;

    public abstract class BaseItem
    {
        private string _name;

        private int _index;

        private int _size;

        private byte[] _sdgData;

        private string _sdgString;

        private InventoryChunk _chunkData;

        public BaseItem(string name, int index, int size, byte[] sdgData, string sdgString, InventoryChunk chunkData)
        {
            this.Name = name;
            this.Index = index;
            this.Size = size;
            this.SdgData = sdgData;
            this.SdgString = sdgString;
            this.ChunkData = chunkData;
        }

        public string Name
        {
            get
            {
                return this._name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Name)} must not be null.");
                }

                this._name = value;
            }
        }

        public int Index
        {
            get
            {
                return this._index;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.Index)} must not be out of range.");
                }

                this._index = value;
            }
        }

        public int Size
        {
            get
            {
                return this._size;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.Size)} must not be out of range.");
                }

                this._size = value;
            }
        }

        public byte[] SdgData
        {
            get
            {
                return this._sdgData;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SdgData)} must not be null.");
                }

                this._sdgData = value;
            }
        }

        public string SdgString
        {
            get
            {
                return this._sdgString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SdgString)} must not be null.");
                }

                this._sdgString = value;
            }
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
    }
}
