using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class Enemies
    {
        // Class Members
        private string name;
        private int level;
        private int maxHealth;
        private int currentHealth;
        private int maxMana;
        private int currentMana;

        // Accessors and Mutators
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    name = "Error Getting Name";
                }
                else
                {
                    name = value;
                }
            }
        }
        public int Level { get => level; set => level = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public int MaxMana { get => maxMana; set => maxMana = value; }
        public int CurrentMana { get => currentMana; set => currentMana = value; }

        public Enemies(string enemy)
        {
            Name = enemy;
            Level = 0;
            MaxHealth = 0;
            CurrentHealth = 0;
            MaxMana = 0;
            CurrentMana = 0;
        }

        public static List<Enemies> GetTownEnemyListBelow5()
        {
            return new List<Enemies>
            {
                new Enemies("Thug") 
                {Level = 1, MaxHealth = 50, CurrentHealth = 50, MaxMana = 0, CurrentMana = 0},
                new Enemies("Thief") 
                {Level = 1, MaxHealth = 30, CurrentHealth = 30, MaxMana = 50, CurrentMana = 50},
                new Enemies("Slime") 
                {Level = 1, MaxHealth = 60, CurrentHealth = 60, MaxMana = 40, CurrentMana = 40},
                new Enemies("Corrupt Guard") 
                {Level = 2, MaxHealth = 75, CurrentHealth = 75, MaxMana = 50, CurrentMana= 50},
            };
        }
    }


}
