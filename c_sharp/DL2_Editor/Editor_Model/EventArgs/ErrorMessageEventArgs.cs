namespace Editor_Model.EventArgs
{
    using System;

    public class ErrorMessageEventArgs : EventArgs
    {
        private string _message;

        public ErrorMessageEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message 
        {
            get
            {
                return this._message;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Message)} must not be null.");
                }

                this._message = value;
            }
        }
    }
}
