namespace Editor_Model.Items
{
    using Editor_Model.Logic;
    using System;

    public class WeaponItem : InventoryItem
    {
        private byte[] _weaponData;

        public WeaponItem(string name, int index, int size, byte[] sgdData, InventoryChunk chunkData, Mod[] mod, byte[] weaponData) : base(name, index, size, sgdData, chunkData, mod)
        {
            this.WeaponData = weaponData;
        }

        public byte[] WeaponData
        {
            get
            {
                return this._weaponData;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.WeaponData)} must not be null.");
                }

                this._weaponData = value;
            }
        }
    }
}
