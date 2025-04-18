using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class PlayerDetails
    {
        // Class Members
        private string name;
        private int level;
        private int maxHealth;
        private int currentHealth;
        private int maxMana;
        private int currentMana;
        private string race;
        private string playerClass;
        private string sex;
        private string equippedWeapon;
        private string equippedArmour;
        private int weaponDmgModifier;
        private int armourDmgReduction;

        // Accessors and Mutators
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    name = "Player";
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
        public int CurrentMana { get=> currentMana; set => currentMana = value; }
        public string Race { get=> race; set => race = value; }
        public string PlayerClass {  get => playerClass; set => playerClass = value; }
        public string Sex { get => sex; set => sex = value; }
        public string EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }
        public string EquippedArmour { get => equippedArmour; set => equippedArmour = value; }
        public int WeaponDmgModifier { get => weaponDmgModifier; set => weaponDmgModifier = value; }
        public int ArmourDmgReduction { get => armourDmgReduction; set => armourDmgReduction = value; }

        public PlayerDetails()
        {
            Name = "Player";
            Level = 1;
            MaxHealth = 100;
            MaxMana = 0;
            CurrentHealth = maxHealth;
            CurrentMana = maxMana;
            Race = null;
            PlayerClass = null;
            Sex = null;
            EquippedWeapon = "N/A";
            EquippedArmour = "N/A";
        }

        public void DisplayPlayerDetails()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("| Player Details                    |");
            Console.WriteLine($"| Name: {Name,-27} |");
            Console.WriteLine($"| Level: {Level, -26} |");
            Console.WriteLine($"| Health: {CurrentHealth, -3}/{MaxHealth, -21} |");
            Console.WriteLine($"| Mana: {CurrentMana, -3}/{MaxMana, -23} |");
            Console.WriteLine($"| Sex: {Sex, -28} |");
            Console.WriteLine($"| Race: {Race, -27} |");
            Console.WriteLine($"| Class: {PlayerClass, -26} |");
            Console.WriteLine($"| Equipped Weapon: {EquippedWeapon,-16} |");
            Console.WriteLine($"| Equipped Armout: {EquippedArmour,-16} |");
            Console.WriteLine("-------------------------------------");
        }

        public void ChooseRace(PlayerDetails player)
        {
            Menu menu = new();
            menu.ChooseRaceMenu(player);
        }

        public void ChooseClass(PlayerDetails player)
        {
            Menu menu = new();
            menu.ChooseClass(player);
        }

        public void ChooseSex(PlayerDetails player)
        {
            Menu menu = new();
            menu.ChooseSex(player);
        }

        public void EquipWeapon(PlayerDetails player, Weapons weaponName)
        {
            player.EquippedWeapon = weaponName.Name;
            player.WeaponDmgModifier = weaponName.WeaponDamage;
            //Console.WriteLine($"Player's weapon damage is {player.WeaponDmgModifier}");
        }

        public void EquipArmour(PlayerDetails player, Armour armourName)
        {
            player.EquippedArmour = armourName.Name;
            player.ArmourDmgReduction = armourName.DamageReduction;
            //Console.WriteLine($"Player's armour gives {player.ArmourDmgReduction} reduction.");
        }

        public void PlayerAttack(PlayerDetails player, Enemies enemy)
        {
            enemy.CurrentHealth -= player.WeaponDmgModifier; 
        }
    }
}
