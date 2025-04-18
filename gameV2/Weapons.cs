using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class Weapons
    {
        private Dictionary<string, double> weaponList;
        private int weaponDamage;
        private string name;

        public Dictionary<string, double> WeaponList { get { return weaponList; } }
        public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
        public string Name { get { return name; } set { name = value; } }

        public Weapons() 
        {
            Name = "N/A";
            weaponList = new Dictionary<string, double>()
            {
                // Starter Weapons
                { "Basic Sword", 1.1 },
                { "Basic Dagger", 1.2 },
                { "Quarterstaff", 1.3 },
                // Debug Weapons
                { "Debug Sword", 100 },
            };
        }

        internal class Swords : Weapons
        {
            public Swords() { }

            internal class BasicSword : Swords
            {
                public BasicSword()
                {
                    Name = "Basic Sword";
                    WeaponDamage = 5;
                }
            }
        }
    }
}
