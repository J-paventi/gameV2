using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class Town
    {
        private List<Enemies> townEnemiesBelow5;
        private List<int> townEnemyBelow5Weights;

        public Town() 
        {
            townEnemiesBelow5 = Enemies.GetTownEnemyListBelow5();
            townEnemyBelow5Weights = [25, 20, 50, 5];
        }

        public void TownCombat(PlayerDetails player)
        {
            if(player.Level <= 5)
            {
                Combat combat = new(player);
                Enemies enemyToFight = combat.GetCombatWeight(townEnemiesBelow5, townEnemyBelow5Weights);
                combat.TownCombatEncounter(player, enemyToFight);
            }
        }

        public void GenerateTreasure(PlayerDetails player)
        {
            Console.WriteLine("Not implemented yet. Seems like the treasure was a mirage.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void TownSocialEvent(PlayerDetails player)
        {
            Console.WriteLine("Not implemented yet. These people are just dummies right now.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void TownNothingHappened(PlayerDetails player)
        {
            Console.WriteLine("You take some time to recover.");
            player.CurrentHealth += 10;
            if (player.CurrentHealth > player.MaxHealth)
            {
                player.CurrentHealth = player.MaxHealth;
            }
            player.CurrentMana += 10;
            if (player.CurrentMana > player.MaxMana)
            {
                player.CurrentMana = player.MaxMana;
            }
            player.DisplayPlayerDetails();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void TownBadLuck(PlayerDetails player)
        {
            Console.WriteLine("You are clipped by a passing carriage.");
            player.CurrentHealth -= 10;
            if (player.CurrentHealth <= 0)
            {
                Console.WriteLine("You have perished! But not really. This just isn't implemented yet.");
                player.CurrentHealth = player.MaxHealth;
                Console.WriteLine("Let's just put you back to full health and continue on :)");
            }
            player.DisplayPlayerDetails();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
