using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class Exploring
    {
        private List<string> townEvent; 
        public Exploring(PlayerDetails player)
        {
            townEvent = ["Combat Encounter", "Random Treasure", "Social Encounter", "Nothing Happens", "Bad Luck"];
        }

        public void Town(PlayerDetails player)
        {
            Console.Clear();
            Random randomEvent = new();
            Town town = new(); 
            int randomSelection = 0;
            int count = 0;
            while(count < 3)
            {
                randomSelection = randomEvent.Next(0, townEvent.Count);
                string selectedEvent = townEvent[randomSelection];
                Console.Clear();
                Console.WriteLine($"Event {count + 1}: {selectedEvent}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                count++;
                switch(randomSelection)
                {
                    case 0:
                        Console.Clear();
                        town.TownCombat(player); 
                        break;
                    case 1:
                        Console.Clear();
                        town.GenerateTreasure(player);
                        break;
                    case 2:
                        Console.Clear();
                        town.TownSocialEvent(player);
                        break;
                    case 3:
                        Console.Clear();
                        town.TownNothingHappened(player);
                        break;
                    case 4:
                        Console.Clear();
                        town.TownBadLuck(player);
                        break;
                }
            }
        }
    }
}
