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
    }
}
