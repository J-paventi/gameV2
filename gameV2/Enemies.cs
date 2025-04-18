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
        private int attackDmg;
        private int strength;
        private int dmgReduction;

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
        public int AttackDmg { get => attackDmg; set => attackDmg = value; }
        public int Strength { get => strength; set => strength = value; }
        public int DmgReduction { get => dmgReduction; set => dmgReduction = value; }

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
                {Level = 1, MaxHealth = 50, CurrentHealth = 50, MaxMana = 0, CurrentMana = 0, 
                    AttackDmg = 3, Strength = 4, DmgReduction = 3},
                new Enemies("Thief") 
                {Level = 1, MaxHealth = 30, CurrentHealth = 30, MaxMana = 50, CurrentMana = 50,
                    AttackDmg = 2, Strength = 2, DmgReduction = 2},
                new Enemies("Slime") 
                {Level = 1, MaxHealth = 60, CurrentHealth = 60, MaxMana = 40, CurrentMana = 40,
                    AttackDmg = 1, Strength = 3, DmgReduction = 4},
                new Enemies("Corrupt Guard") 
                {Level = 2, MaxHealth = 75, CurrentHealth = 75, MaxMana = 50, CurrentMana= 50,
                    AttackDmg = 5, Strength = 5, DmgReduction = 3},
            };
        }

        public int EnemyAttack(PlayerDetails player, Enemies enemy)
        {
            int damage = enemy.AttackDmg - player.ArmourDmgReduction;
            if(damage < 0)
            {
                damage = 1 + enemy.Strength;
            }
            else
            {
                damage += enemy.Strength;
            }
            
            player.CurrentHealth -= damage;

            return damage;
        }
    }


}
