using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV2
{
    internal class Town
    {
        public Town() { }

        public void TownCombat(PlayerDetails player)
        {
            Console.WriteLine("Not implemented yet. These thugs will get you next time!");
        }

        public void GenerateTreasure(PlayerDetails player)
        {
            Console.WriteLine("Not implemented yet. Seems like the treasure was a mirage.");
        }

        public void TownSocialEvent(PlayerDetails player)
        {
            Console.WriteLine("Not implemented yet. These people are just dummies right now.");
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
            }
            player.DisplayPlayerDetails();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
