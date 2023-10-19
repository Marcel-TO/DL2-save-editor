namespace Editor_ViewModel.Logic
{
    using Editor_Model.EventArgs;
    using Editor_Model.Logic;
    using System;

    public class IdSearcherVM
    {
        private IdSearcher idSearcher;

        public IdSearcherVM()
        {
            this.idSearcher = new IdSearcher();
            this.idSearcher.OnSearch += this.OnIdSearchFired;
        }

        public event EventHandler<FoundIDsEventArgs> OnIdSearch;

        public void GetIDs()
        {
            this.idSearcher.GetIDs();
        }

        protected void OnIdSearchFired(object sender,FoundIDsEventArgs e)
        {
            this.OnIdSearch?.Invoke(this, e);
        }
    }
}
