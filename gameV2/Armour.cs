using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class Armour
    {
        private Dictionary<string, double> armourList;
        private int damageReduction;
        private string name;

        public Dictionary<string, double> ArmourList { get { return armourList; } }
        public int DamageReduction { get { return damageReduction; } set { damageReduction = value; } }
        public string Name { get { return name; } set { name = value; } }

        public Armour()
        {
            Name = "N/A";
            armourList = new Dictionary<string, double>()
            {
                // Starter Equipment
                { "Breastplate", 1.1 },
                { "Leather Armour", 1.2 },
                { "Wizard Robe", 1.3 }
            };
        }

        internal class Breastplate : Armour
        {
            public Breastplate()
            {
                Name = "Breastplate";
                DamageReduction = 5; 
            }
        }
    }
}
