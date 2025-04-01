using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
