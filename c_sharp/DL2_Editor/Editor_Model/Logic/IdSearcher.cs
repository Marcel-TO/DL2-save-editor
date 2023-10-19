namespace Editor_Model.Logic
{
    using Editor_Model.EventArgs;
    using System;
    using System.Xml.Linq;

    public class IdSearcher
    {
        public event EventHandler<FoundIDsEventArgs> OnSearch;

        public void GetIDs()
        {
            List<IdData> ids = new List<IdData>();

            string root = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(root, @"..\..\..\..\IDs"));
            string[] allFiles = Directory.GetFiles(newPath);

            for (int i = 0; i < allFiles.Length; i++)
            {
                ids.Add(new IdData(Path.GetFileNameWithoutExtension(allFiles[i]), File.ReadAllLines(allFiles[i])));
            }

            this.OnSearch?.Invoke(this, new FoundIDsEventArgs(ids.ToArray()));
        }
    }
}
