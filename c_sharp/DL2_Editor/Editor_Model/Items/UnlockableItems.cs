namespace Editor_Model.Items
{
    using Editor_Model.Logic;
    using System;

    public class UnlockableItems : BaseItem
    {
        public UnlockableItems(string name, int index, int size, byte[] sdgData, string sdgString, InventoryChunk chunkData) : base(name, index, size, sdgData, sdgString, chunkData)
        {
        }
    }
}
