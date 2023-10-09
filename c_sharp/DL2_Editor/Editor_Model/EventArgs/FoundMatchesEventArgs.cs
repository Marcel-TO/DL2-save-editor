namespace Editor_Model.EventArgs
{
    using System;

    public class FoundMatchesEventArgs : EventArgs
    {
        private string[] matches;

        public FoundMatchesEventArgs(string[] matches)
        {
            this.Matches = matches;
        }

        public string[] Matches
        {
            get 
            { 
                return matches; 
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Matches)} must not be null.");
                }

                this.matches = value;
            }
        }
    }
}
