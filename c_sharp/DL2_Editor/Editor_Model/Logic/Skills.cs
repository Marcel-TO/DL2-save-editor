namespace Editor_Model.Logic
{
    using Editor_Model.Items;
    using System;

    public class Skills
    {
        private SkillIItem[] baseSkills;

        private SkillIItem[] legendSkills;

        public Skills(SkillIItem[] baseSkills, SkillIItem[] legendSkills)
        {
            this.BaseSkills = baseSkills;
            this.LegendSkills = legendSkills;
        }

        public SkillIItem[] BaseSkills
        {
            get
            {
                return this.baseSkills;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.BaseSkills)} must not be null.");
                }

                this.baseSkills = value;
            }
        }

        public SkillIItem[] LegendSkills
        {
            get
            {
                return this.legendSkills;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.LegendSkills)} must not be null.");
                }

                this.legendSkills = value;
            }
        }
    }
}
