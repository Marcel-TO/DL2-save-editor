namespace Editor_Model.Items
{
    using Editor_Model.Logic;
    using System;

    public abstract class BaseItem
    {
        private string _name;

        private int _index;

        private int _size;

        private byte[] _sgdData;

        private string _sgdString;

        public BaseItem(string name, int index, int size, byte[] sgdData)
        {
            this.Name = name;
            this.Index = index;
            this.Size = size;
            this.SgdData = sgdData;
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

        public byte[] SgdData
        {
            get
            {
                return this._sgdData;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SgdData)} must not be null.");
                }

                this._sgdData = value;
                this.SgdString = BitConverter.ToString(value).Replace("-", " ");
            }
        }

        public string SgdString
        {
            get
            {
                return this._sgdString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SgdString)} must not be null.");
                }

                this._sgdString = value;
            }
        }
    }
}
