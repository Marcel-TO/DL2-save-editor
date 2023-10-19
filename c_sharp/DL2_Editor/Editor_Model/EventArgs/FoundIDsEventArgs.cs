namespace Editor_Model.EventArgs
{
    using Editor_Model.Logic;
    using System;

    public class FoundIDsEventArgs : EventArgs
    {
        private IdData[] idData;

        public FoundIDsEventArgs(IdData[] idData)
        {
            this.IdData = idData;
        }

        public IdData[] IdData
        {
            get
            {
                return this.idData;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.IdData)} must not be null.");
                }

                this.idData = value;
            }
        }
    }
}
