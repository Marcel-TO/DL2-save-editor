namespace Editor_Model.Logic
{
    using System;

    public class IdData
    {
        private string name;

        private string[] ids;

        public IdData(string name, string[] iDs)
        {
            this.Name = name;
            this.IDs = iDs;
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

        public string[] IDs
        {
            get
            {
                return this.ids;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.IDs)} must not be null.");
                }

                this.ids = value;
            }
        }
    }
}
