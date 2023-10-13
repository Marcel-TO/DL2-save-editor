namespace Editor_Model.Items
{
    using System;
    using Editor_Model.Logic;

    public class SkillIItem : BaseItem
    {
        public SkillIItem(string name, int index, int size, byte[] sdgData, string sdgString, InventoryChunk chunkData) : base(name, index, size, sdgData, sdgString, chunkData)
        {
        }
    }
}
