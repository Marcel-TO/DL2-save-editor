namespace Editor_Model.Logic
{
    using System;

    public class Mod
    {
        private string name;

        private byte[] data;

        private string dataString;

        public Mod(string name, byte[] data)
        {
            this.Name = name;
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
