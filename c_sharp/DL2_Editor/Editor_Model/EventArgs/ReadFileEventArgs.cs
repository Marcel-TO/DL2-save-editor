namespace Editor_Model.EventArgs
{
    using System;

    public class ReadFileEventArgs : EventArgs
    {
        private string filepath;

        private byte[] data;

        public ReadFileEventArgs(string filepath, byte[] data)
        {
            this.FilePath = filepath;
            this.Data = data;
        }

        public string FilePath
        {
            get
            {
                return this.filepath;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.FilePath)} must not be null.");
                }

                this.filepath = value;
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
            }
        }
    }
}
