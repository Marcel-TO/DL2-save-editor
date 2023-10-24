namespace Editor_Model.EventArgs
{
    using Editor_Model.Items;
    using Editor_Model.Logic;
    using System;

    public class ChangedItemsEventArgs : EventArgs
    {
        private SaveFile savegame;

        private int index;

        public ChangedItemsEventArgs(SaveFile savegame, int index)
        {
            this.Savegame = savegame;
            this.Index = index;
        }

        public SaveFile Savegame
        {
            get
            {
                return this.savegame;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Savegame)} must not be null.");
                }

                this.savegame = value;
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
                    throw new ArgumentNullException($"The {nameof(this.Index)} must not be null.");
                }

                this.index = value;
            }
        }
    }
}
