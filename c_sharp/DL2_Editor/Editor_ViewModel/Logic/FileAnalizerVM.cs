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
            this.fileAnalizer.ReadFile += this.ReadFile;
            this.fileAnalizer.ChangedSkillItems += this.OnSkillItemsChanged;
        }

        public event EventHandler<AnalizedSaveFileEventArgs> AnalizedSaveFile;

        public event EventHandler<ErrorMessageEventArgs> ErrorMessage;

        public event EventHandler<ChangedItemsEventArgs> ChangedSkillItems;

        public void ReadSaveFile(string filePath)
        {
            this.fileAnalizer.ReadFileContent(filePath);
        }

        public void ChangeSkillItems(SaveFile savegame, int index, string name, int size, string currentValue, string userInput)
        {
            this.fileAnalizer.ChangeSkillItems(savegame, index, name, size, currentValue, userInput);
        }

        protected void OnErrorMessage(object sender, ErrorMessageEventArgs e)
        {
            this.ErrorMessage?.Invoke(this, e);
        }

        protected void OnAnalizedSaveFile(object sender, AnalizedSaveFileEventArgs e)
        {
            this.AnalizedSaveFile?.Invoke(this, e);
        }

        protected void ReadFile(object sender, ReadFileEventArgs e)
        {
            this.fileAnalizer.LoadSaveFile(e.FilePath, e.Data);
        }

        protected void OnSkillItemsChanged(object sender, ChangedItemsEventArgs e)
        {
            this.ChangedSkillItems?.Invoke(this, e);
        }
    }
}
