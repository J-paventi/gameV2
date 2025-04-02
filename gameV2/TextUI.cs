using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    validInput = true;
                    Console.ReadKey();
                }
                else if (confirmationChoice == "No")
                {
                    player.PlayerClass = null;
                    player.Sex = null;
                    player.Race = null;
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
