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
        private List<int> townEventWeights;

        public Exploring(PlayerDetails player)
        {
            townEvent = ["Combat Encounter", "Random Treasure", "Social Encounter", "Nothing Happens", "Bad Luck"];
            townEventWeights = [30, 15, 25, 20, 10];
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
                randomSelection = GetWeightedRandomEvent();
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

        public void Forest(PlayerDetails player)
        {
            Console.Clear();
            Console.WriteLine("The forest is too spooky! You decide to turn back.");
            Console.WriteLine("It is not implemented yet. Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void Dungeon(PlayerDetails player)
        {
            Console.Clear();
            Console.WriteLine("The door is locked, with a sign reading 'Under Construction'.");
            Console.WriteLine("It is not implemented yet. Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private int GetWeightedRandomEvent()
        {
            Random random = new();
            int totalWeight = 0;
            foreach(int weight in townEventWeights)
            {
                totalWeight += weight;
            }

            int randomValue = random.Next(0, totalWeight);
            int cumulativeWeight = 0;

            for(int i = 0; i < townEventWeights.Count; i++)
            {
                cumulativeWeight += townEventWeights[i];
                if(randomValue < cumulativeWeight)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
