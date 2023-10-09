namespace Editor_ViewModel.Logic
{
    using Editor_Model.EventArgs;
    using Editor_Model.Logic;
    using System;

    public class FileAnalizerVM
    {
        private FileAnalizer fileAnalizer;

        public FileAnalizerVM()
        {
            this.fileAnalizer = new FileAnalizer();
            this.fileAnalizer.ErrorMessage += this.OnErrorMessage;
            this.fileAnalizer.AnalizedSaveFile += this.OnAnalizedSaveFile;
        }

        public event EventHandler<AnalizedSaveFileEventArgs> AnalizedSaveFile;

        public event EventHandler<ErrorMessageEventArgs> ErrorMessage;

        public void AnalyzeUnlockableItemsData(byte[] data)
        {
            this.fileAnalizer.AnalyzeUnlockableItemsData(data);
        }

        protected void OnErrorMessage(object sender, ErrorMessageEventArgs e)
        {
            this.ErrorMessage?.Invoke(this, e);
        }

        protected void OnAnalizedSaveFile(object sender, AnalizedSaveFileEventArgs e)
        {
            this.AnalizedSaveFile?.Invoke(this, e);
        }

    }
}
