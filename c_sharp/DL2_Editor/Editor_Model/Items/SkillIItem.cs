namespace Editor_Model.Items
{
    using System;
    using Editor_Model.Logic;

    public class SkillIItem : BaseItem
    {
        private byte[] _points;

        private string _pointsString;

        public SkillIItem(string name, int index, int size, byte[] sdgData, byte[] points) : base(name, index, size, sdgData)
        {
            this.Points = points;
        }

        public byte[] Points
        {
            get
            {
                return this._points;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Points)} must not be null.");
                }

                this._points = value;
                this.PointsString = BitConverter.ToString(value).Replace("-", " ");
            }
        }

        public string PointsString
        {
            get
            {
                return this._pointsString;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.PointsString)} must not be null.");
                }

                this._pointsString = value;
            }
        }
    }
}
