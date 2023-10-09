namespace Editor_Model.EventArgs
{
    using System;

    public class ExtractBytesEventArgs : EventArgs
    {
        private byte[] _data;

        public ExtractBytesEventArgs(byte[] data)
        {
            this.Data = data;
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

                this._data = value;
            }
        }
    }
}
