using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private List<string> characterBuild; 
        private List<string> races;
        private List<string> classes;
        private List<string> sexes;
        private List<string> gameMenu;

        public Menu()
        {
            menuItems = [];
            characterBuild = ["Choose Race", "Choose Class", "Choose Sex"];
            races = ["Human", "Elf", "Dwarf"];
            classes = ["Fighter", "Rogue", "Wizard"];
            sexes = ["Male", "Female", "Other"];
            gameMenu = ["Check Status", "Visit Shops", "Go to the Tavern", "Explore", "Save Game", "Exit"];
        }

        public void Display(List <string> items)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"| {i+1}. {items[i], -30} |");
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
            bool validInput = false;
            menuItems.Add(new MenuItem("New Game", NewGame));
            menuItems.Add(new MenuItem("Load Game", LoadGame));
            menuItems.Add(new MenuItem("Exit", Exit));
            List<string> menuTitles = []; 
            foreach(var item in menuItems)
            {
                menuTitles.Add(item.Title);
            }
            while(!validInput)
            {
                Display(menuTitles);
                int.TryParse(Console.ReadLine(), out int result);
                if (result > 0 && result <= menuItems.Count)
                {
                    validInput = true;
                    Execute(result - 1);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void CharacterBuildMenu(PlayerDetails player)
        {
            while(string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.PlayerClass) || string.IsNullOrEmpty(player.Sex))
            {
                Display(characterBuild);
                if(int.TryParse(Console.ReadLine(), out int result))
                {
                    switch (result)
                    {
                        case 1:
                            player.ChooseRace(player);
                            break;
                        case 2:
                            player.ChooseClass(player);
                            break;
                        case 3:
                            player.ChooseSex(player);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void ChooseRaceMenu(PlayerDetails player)
        {
            bool validInput = false;
            while(!validInput)
            {
                Display(races);
                if(int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= races.Count)
                {
                    Console.WriteLine($"You have chosen: {races[result - 1]}");
                    player.Race = races[result - 1];
                    Console.ReadKey();
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void ChooseClass(PlayerDetails player)
        {
            bool validInput = false;
            while(!validInput)
            {
                Display(classes);
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= classes.Count)
                {
                    Console.WriteLine($"You have chosen {classes[result - 1]}");
                    player.PlayerClass = classes[result - 1];
                    Console.ReadKey();
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void ChooseSex(PlayerDetails player)
        {
            bool validInput = false;
            while(!validInput)
            {
                Display(sexes);
                if(int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= sexes.Count)
                {
                    Console.WriteLine($"You have chosen {sexes[result - 1]}");
                    player.Sex = sexes[result - 1];
                    Console.ReadKey();
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void GameMenu(PlayerDetails player)
        {
            bool validInput = false;
            TextUI textUI = new();
            Menu menu = new();
            while(!validInput)
            {
                Display(gameMenu);
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= gameMenu.Count)
                {
                    switch (result)
                    {
                        case 1:
                            player.DisplayPlayerDetails();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        case 2:
                            textUI.DisplayShops(player);
                            break;
                        case 3:
                            textUI.VisitTavern(player);
                            break;
                        case 4:
                            textUI.Explore(player);
                            break;
                        case 5:
                            menu.SaveGame();
                            break;
                        case 6:
                            menu.Exit();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void NewGame()
        {
            Console.WriteLine("New Game");
        }

        public void SaveGame()
        {
            Console.WriteLine("Saving Game...");
            Thread.Sleep(1000);
            string gameState = "Fake Game State";
            File.WriteAllText("gameState.txt", gameState);
            Console.WriteLine("Game Saved!");
            Console.ReadKey();
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
