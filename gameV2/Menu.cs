using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace gameV2
{
    internal class Menu
    {
        private List<string> startMenu; 
        private List<string> characterBuild; 
        private List<string> races;
        private List<string> classes;
        private List<string> sexes;
        private List<string> gameMenu;
        private List<string> exploreMenu;
        private List<string> combatMenu = ["Attack", "Cast Spell", "Use Ability", "Use Item", "Run"];

        public List<string> CombatMenu {  get; }

        public Menu()
        {
            startMenu = ["New Game", "Load Game", "Exit Game"];
            characterBuild = ["Choose Race", "Choose Class", "Choose Sex"];
            races = ["Human", "Elf", "Dwarf"];
            classes = ["Fighter", "Rogue", "Wizard"];
            sexes = ["Male", "Female", "Other"];
            gameMenu = ["Check Status", "Visit Shops", "Go to the Tavern", "Explore", "Save Game", "Exit"];
            exploreMenu = ["Explore Town", "Explore Forest", "Explore Dungeon", "Quit Exploring"];
            CombatMenu = combatMenu;
        }

        public void Display(List<string> items)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"| {i+1}. {items[i], -30} |");
            }
            Console.WriteLine("-------------------------------------");
        }

        public void StartMenu()
        {
            bool validInput = false;
            while(!validInput)
            {
                Display(startMenu);
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= startMenu.Count)
                {
                    switch(result)
                    {
                        case 1:
                            NewGame();
                            validInput = true;
                            break;
                        case 2:
                            LoadGame();
                            validInput= true;
                            break;
                        case 3:
                            Exit();
                            validInput = true;
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
                    Console.WriteLine("Press any key to continue...");
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
                    Console.WriteLine("Press any key to continue...");
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
                    Console.WriteLine("Press any key to continue...");
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
                            menu.SaveGame(player);
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

        public void ExploringMenu(PlayerDetails player)
        {
            bool quitExploring = false;
            Exploring exploring = new(player);
            Menu menu = new();
            while(!quitExploring)
            {
                Display(exploreMenu);
                if(int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= exploreMenu.Count)
                {
                    switch(result)
                    {
                        case 1:         // town
                            exploring.Town(player); 
                            break;
                        case 2:         // forest
                            exploring.Forest(player);
                            break;
                        case 3:         // dungeon
                            exploring.Dungeon(player); 
                            break;
                        case 4:
                            menu.GameMenu(player);
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

        public void GenerateCombatMenu(PlayerDetails player, Enemies enemy)
        {
            TextUI textUI = new();
            Display(CombatMenu);
            textUI.CombatTextUI(player, enemy);
        }

        public void NewGame()
        {
            Console.WriteLine("New Game");
            TextUI textUI = new();
            textUI.Welcome();
        }

        public void SaveGame(PlayerDetails player)
        {
            Console.WriteLine("Saving Game...");
            string gameState = JsonSerializer.Serialize(player);
            string filename = $"savegame_{player.Name}.json";
            File.WriteAllText(filename, gameState);
            Console.WriteLine("Game Saved!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void LoadGame()
        {
            Console.WriteLine("Enter the name of the file to load. It should be in the format of:");
            Console.WriteLine("savegame_[player's name]");
            string filename = Console.ReadLine();
            if(File.Exists($"{filename}.json"))
            {
                string gameState = File.ReadAllText($"{filename}.json");
                PlayerDetails player = JsonSerializer.Deserialize<PlayerDetails>(gameState);
                Console.WriteLine("Game Loaded!");
                player.DisplayPlayerDetails();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                GameMenu(player);
            }
            else
            {
                Console.WriteLine("Save file not found. Press any key to return to the main menu.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear(); 
                StartMenu();
            }
        }

        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Exiting game...");
            Console.WriteLine("Come back soon. The world of Orthan needs heroes like you!");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
