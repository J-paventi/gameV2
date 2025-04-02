using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class Combat
    {
        public Combat(PlayerDetails player)
        {

        }

        public Enemies GetCombatWeight(List<Enemies> enemyList, List<int> enemyWeights)
        {
            Random random = new();
            int totalWeight = 0;
            foreach(int weight in enemyWeights)
            {
                totalWeight += weight;
            }

            int randomValue = random.Next(0, totalWeight);
            int cumulativeWeight = 0;
            for (int i = 0; i < enemyWeights.Count; i++)
            {
                cumulativeWeight += enemyWeights[i];
                if (randomValue < cumulativeWeight)
                {
                    return enemyList[i];
                }
            }

            return null;        // will return the first enemy as a default
        }

        public void TownCombatEncounter(PlayerDetails player, Enemies enemy)
        {
            Menu menu = new();
            bool combatFinished = false;
            Console.WriteLine($"A {enemy.Name} has appeared! {player.Name}, prepare to fight!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            while(!combatFinished)
            {
                menu.GenerateCombatMenu(player, enemy);
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= menu.CombatMenu.Count)
                {
                    switch(result)
                    {
                        case 1:
                            Console.WriteLine("You attack!");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("You cast a spell.");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("You use an ability.");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("You use an item.");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("You run away!");
                            Console.ReadKey();
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
    }
}
