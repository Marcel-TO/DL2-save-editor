namespace Editor_Model.Logic
{
    using System;

    public class InventoryChunk
    {
        private byte[] _level;

        private byte[] _seed;

        private byte[] _amount;

        private byte[] _durability;

        private byte [] _space;

        private int dataIndex;

        private string _levelString;

        private string _seedString;

        private string _amountString;

        private string _durabilityString;

        private string _spaceString;

        public InventoryChunk(byte[] level, byte[] seed, byte[] amount, byte[] durability, byte[] space, int dataIndex)
        {
            this.Level = level;
            this.Space = space;
            this.DataIndex = dataIndex;
        }

        public byte[] Level
        {
            get
            {
                return this._level;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Level)} must not be null.");
                }
                else if (value.Length != 2)
                {
                    throw new ArgumentOutOfRangeException($"The length of {nameof(this.Level)} must be 2.");
                }

                this._level = value;
                this.LevelString = BitConverter.ToString(value).Replace("-", " ");
            }
        }

        public byte[] Seed
        {
            get
            {
                return this._seed;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Seed)} must not be null.");
                }
                else if (value.Length != 2)
                {
                    throw new ArgumentOutOfRangeException($"The length of {nameof(this.Seed)} must be 2.");
                }

                this._seed = value;
                this.SeedString = BitConverter.ToString(value).Replace("-", " ");
            }
        }

        public byte[] Amount
        {
            get
            {
                return this._amount;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Amount)} must not be null.");
                }
                else if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException($"The length of {nameof(this.Amount)} must be 4.");
                }

                this._amount = value;
                this.AmountString = BitConverter.ToString(value).Replace("-", " ");
            }
        }

        public byte[] Durability
        {
            get
            {
                return this._durability;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Durability)} must not be null.");
                }
                else if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException($"The length of {nameof(this.Durability)} must be 2.");
                }

                this._durability = value;
                this.DurabilityString = BitConverter.ToString(value).Replace("-", " ");
            }
        }

        public byte[] Space
        {
            get
            {
                return this._space;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Space)} must not be null.");
                }
                else if (value.Length != 25)
                {
                    throw new ArgumentOutOfRangeException($"The length of {nameof(this.Space)} must be 12.");
                }

                this._space = value;
                this.SpaceString = BitConverter.ToString(value).Replace("-", " ");
            }
        }

        public string LevelString
        {
            get
            {
                return this._levelString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.LevelString)} must not be null.");
                }

                this._levelString = value;
            }
        }

        public string SeedString
        {
            get
            {
                return this._seedString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SeedString)} must not be null.");
                }

                this._seedString = value;
            }
        }

        public string AmountString
        {
            get
            {
                return this._amountString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.AmountString)} must not be null.");
                }

                this._amountString = value;
            }
        }

        public string DurabilityString
        {
            get
            {
                return this._durabilityString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.DurabilityString)} must not be null.");
                }

                this._durabilityString = value;
            }
        }

        public string SpaceString
        {
            get
            {
                return this._spaceString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SpaceString)} must not be null.");
                }

                this._spaceString = value;
            }
        }

        public int DataIndex
        {
            get
            {
                return this.dataIndex;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.DataIndex)} must not be null.");
                }
                else if (value.Length != 2)
                {
                    throw new ArgumentOutOfRangeException($"The length of {nameof(this.DataIndex)} must be 2.");
                }

                this.dataIndex = value;
            }
        }
    }
}
