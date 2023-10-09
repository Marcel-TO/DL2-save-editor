namespace Editor_Model.EventArgs
{
    using Editor_Model.Logic;
    using System;

    public class AnalizedSaveFileEventArgs : EventArgs
    {
        private SaveFile saveFile;

        public AnalizedSaveFileEventArgs(SaveFile saveFile)
        {
            this.SaveFile = saveFile;
        }

        public SaveFile SaveFile
        {
            get
            {
                return this.saveFile;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SaveFile)} must not be null.");
                }

                this.saveFile = value;
            }
        }
    }
}
