namespace Editor_Model.Logic
{
    using System;

    public class Mod
    {
        private string name;

        private int index;

        private byte[] data;

        private string dataString;

        public Mod(string name, int index, byte[] data)
        {
            this.Name = name;
            this.Index = index;
            this.Data = data;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Name)} must not be null.");
                }

                this.name = value;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.Index)} must not be negative.");
                }

                this.index = value;
            }
        }

        public byte[] Data
        {
            get
            {
                return this.data;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Data)} must not be null.");
                }

                this.data = value;
                this.DataString = BitConverter.ToString(value).Replace("-", " ");
            }
        }

        public string DataString
        {
            get
            {
                return this.dataString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.DataString)} must not be null.");
                }

                this.dataString = value;
            }
        }
    }
}
