using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static gameV2.Armour;
using static gameV2.Weapons.Swords;

namespace gameV2
{
    internal class TextUI
    {
        public void Welcome()
        {
            Console.Clear(); 
            Console.WriteLine("Welcome to 'Definitely Not DragonQuest'!");
            Console.WriteLine("Press any key to continuue...\n");
            Console.ReadKey();
        }

        public string GetPlayerName()
        {
            string? inputName;
            while (true)
            {
                Console.WriteLine("Please enter a name for your character.");
                Console.Write("Name: ");
                inputName = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputName))
                {
                    Console.Clear();
                    Console.WriteLine("\nHello, {0}!", inputName);
                    Console.WriteLine("Press any key to continue...\n");
                    Console.ReadKey();
                    return inputName;
                }
                Console.WriteLine("Invalid input. Please try again.\n");
            }
        }

        public void DisplayHumanDetails()
        {
            Console.WriteLine("\nHumans are the most populace people of Orthan. " +
                "They are well rounded and suited to almost any role.");
            Console.WriteLine("Becuase of this, they also do not excel at any one role.");
            Console.WriteLine("\nHumans gain the ability 'Healing Surge'        Not yet implemented");
            Console.WriteLine("     For 5 Mana, you can heal 10HP.");
        }

        public void DisplayElfDetails()
        {
            Console.WriteLine("\nElves are a people closely related to the magic of Orthan. " +
                "They typically focus heavily on magic use.");
            Console.WriteLine("Because of this, they make some of the best Wizards in Orthan.");
            Console.WriteLine("\nElves gain the ability 'Force Blast'           Not yet implemented");
            Console.WriteLine("     For 7 Mana, you shoot a ball of force dealing 10 damage");
        }

        public void DisplayDwarfDetails()
        {
            Console.WriteLine("\nDwarves are a hearty and resilient people. They excel at physcial combat" +
                "but typically eschew magic.");
            Console.WriteLine("Becuase of this, they make excellent Fighters and Rogues, but are not well" +
                "suited to being Wizards.");
            Console.WriteLine("\nDwarves gain the ability 'Overhead Chop'       Not yet implemented");
            Console.WriteLine("     For 7 Mana, you swing a brutal overhead attack at your enemy dealing 1.25x" +
                "normal damage.");
        }

        public void DisplayFighterDetails()
        {
            Console.WriteLine("\nThough weak with magic, the Fighter excels at dealing physical damage.");
            Console.WriteLine("The Fighter has higher Attack and Health at the cost of reduced " +
                "Mana and Magic Attack.");
            Console.WriteLine("\nStarting Ability: Quick Slash                  Not yet implemented");
            Console.WriteLine("     Quick slash allows the player to always attack first and " +
                "deals 0.85x normal damage.");
            Console.WriteLine("\nStarting Equipment:                            Not yet implemented");
            Console.WriteLine("     Basic Sword - +5 Attack, +7 Accuracy");
            Console.WriteLine("     Breatplate - +5 Defence, +2 Magic Defence\n");
        }

        public void DisplayRogueDetails()
        {
            Console.WriteLine("\nThough not physically strong, the Rogue excels at moving quickly and" +
                "balances decent physical stats with mediocre magic stats.");
            Console.WriteLine("The Rogue has higher Accuracy and Evasion and average Attack, Health," +
                "Mana, and Magic Attack.");
            Console.WriteLine("\nStarting Ability: Evasion                      Not yet implemented");
            Console.WriteLine("     Evasion is a passive ability that grants an additional" +
                "1.2x normal evasion.");
            Console.WriteLine("\nStarting Equipment:");
            Console.WriteLine("     Basic Dagger - +3 Attack, +10 Accuracy");
            Console.WriteLine("     Leather Armour - +3 Defence, +3 Magic Defence, +3 Evasion");
        }

        public void DisplayWizardDetails()
        {
            Console.WriteLine("\nThough physically frail, the Wizard is an undisputed master of magic.");
            Console.WriteLine("The Wizard has higher Magic Attack, Magic Defence, and Mana at the " +
                "cost of reduced Attack, Defence, and Health.");
            Console.WriteLine("\nStarting Abilities: Ice Bolt, Fire Bolt        Not implemented Yet");
            Console.WriteLine("     Ice Bolt shoots a magical bolt of ice for 5 Mana and 8 Damage");
            Console.WriteLine("     Fire Bolt shoots a magical bolt of fire for 5 Mana and 8 Damage");
            Console.WriteLine("\nStarting Equipment:");
            Console.WriteLine("     Quarterstaff - +3 Attack, +5 Magic Attack");
            Console.WriteLine("     Wizard Robe - +5 Magic Defence, +10 Mana, +1 Evasion");
        }

        public void ConfirmChoices(PlayerDetails player)
        {
            bool validInput = false;
            while(validInput == false)
            {
                Console.WriteLine("Would you like to use these choices? Yes/No");
                string? confirmationChoice = Console.ReadLine();
                if (!string.IsNullOrEmpty(confirmationChoice) && confirmationChoice == "Yes")
                {
                    Console.WriteLine("You have finished creating your character!");
                    Console.WriteLine("Press any key to continue...");
                    string? chosenClass = player.PlayerClass;
                    switch(chosenClass)
                    {
                        case "Fighter":
                            BasicSword sword = new();
                            Breastplate armour = new();
                            player.EquipWeapon(player, sword);
                            player.EquipArmour(player, armour);
                            break;
                        case "Rogue":
                            player.EquippedWeapon = "Basic Dagger";
                            player.EquippedArmour = "Leather Armour";
                            break;
                        case "Wizard":
                            player.EquippedWeapon = "Quarterstaff";
                            player.EquippedArmour = "Wizard Robe";
                            break;
                    }
                    validInput = true;
                    Console.ReadKey();
                }
                else if (confirmationChoice == "No")
                {
                    player.PlayerClass = null;
                    player.Sex = null;
                    player.Race = null;
                    player.MaxHealth = 100;
                    player.MaxMana = 0;
                    player.CurrentHealth = 100;
                    player.CurrentMana = 0;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose either 'Yes' or 'No'");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        public void DisplayShops(PlayerDetails player)
        {
            Console.WriteLine("Not implemented yet");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void VisitTavern(PlayerDetails player)
        {
            Console.WriteLine("Not implemented yet");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Explore(PlayerDetails player)
        {
            Menu menu = new();
            menu.ExploringMenu(player); 
            Console.ReadKey();
        }

        public void CombatTextUI(PlayerDetails player, Enemies enemy)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"| Player Details                    | Enemy Details {"", -19} |");
            Console.WriteLine($"| Name: {player.Name,-27} | Name: {enemy.Name, -27} |");
            Console.WriteLine($"| Level: {player.Level,-26} | Level: {enemy.Level, -26} |");
            Console.WriteLine($"| Health: {player.CurrentHealth,-3}/{player.MaxHealth,-21} | " +
                $"Health: {enemy.CurrentHealth, -3}/{enemy.MaxHealth, -21} |");
            Console.WriteLine($"| Mana: {player.CurrentMana,-3} / {player.MaxMana,-21} | {"",-33} |");
            Console.WriteLine("-------------------------------------------------------------------------");

        }
    }
}
