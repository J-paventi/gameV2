using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class MenuItem
    {
        public string Title { get; set; }
        public Action Action { get; set; }

        public MenuItem(string title, Action action)
        {
            Title = title;
            Action = action;
        }
    }

    internal class Menu
    {
        private List<MenuItem> menuItems;
        public Menu()
        {
            menuItems = new List<MenuItem>();
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"| {i+1}. {menuItems[i].Title, -30} |");
            }
            Console.WriteLine("-------------------------------------");
        }

        public void Execute(int index)
        {
            if(index >= 0 && index < menuItems.Count)
            {
                menuItems[index].Action.Invoke(); 
            }
        }

        public void StartMenu()
        {
            menuItems.Add(new MenuItem("New Game", NewGame));
            menuItems.Add(new MenuItem("Load Game", LoadGame));
            menuItems.Add(new MenuItem("Exit", Exit));
            Display();
            string choice;
            int.TryParse(choice = Console.ReadLine(), out int result);
            Execute(result - 1);
        }

        public void NewGame()
        {
            Console.WriteLine("New Game");
        }

        public void SaveGame()
        {
            Console.WriteLine("Saving Game...");
            string gameState = "Fake Game State";
            File.WriteAllText("gameState.txt", gameState);
            Console.WriteLine("Game Saved!");
        }

        public void LoadGame()
        {
            Console.WriteLine("Load Game");
        }

        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Exiting game...");
            Environment.Exit(0);
        }
    }
}
