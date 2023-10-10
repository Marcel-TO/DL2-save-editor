namespace Editor_Model.Logic
{
    using System;

    public class InventoryChunk
    {
        private byte[] _data;

        private byte[] _space;

        private string _dataString;

        private string _spaceString;

        public InventoryChunk(byte[] data, byte[] space)
        {
            this.Data = data;
            this.Space = space;
            this.DataString = BitConverter.ToString(data).Replace("-", " ");
            this.SpaceString = BitConverter.ToString(space).Replace("-", " ");
        }

        public byte[] Data
        {
            get
            {
                return this._data;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Data)} must not be null.");
                }
                else if (value.Length != 12)
                {
                    throw new ArgumentOutOfRangeException($"The length of {nameof(this.Data)} must be 12.");
                }

                this._data = value;
            }
        }

        public byte[] Space
        {
            get
            {
                return this._space;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Space)} must not be null.");
                }
                else if (value.Length != 25)
                {
                    throw new ArgumentOutOfRangeException($"The length of {nameof(this.Space)} must be 12.");
                }

                this._space = value;
            }
        }

        public string DataString
        {
            get
            {
                return this._dataString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.DataString)} must not be null.");
                }

                this._dataString = value;
            }
        }

        public string SpaceString
        {
            get
            {
                return this._spaceString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SpaceString)} must not be null.");
                }

                this._spaceString = value;
            }
        }
    }
}
