using System.Formats.Tar;

namespace gameV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;
            TextUI textUI = new();
            Menu menu = new();
            PlayerDetails player = new();
            menu.StartMenu();
            //textUI.Welcome();
            player.Name = textUI.GetPlayerName();
            while(player.PlayerClass == null || player.Sex == null || player.Race == null)
            {
                menu.CharacterBuildMenu(player);
                Console.Clear();
                player.DisplayPlayerDetails();
                textUI.ConfirmChoices(player);
            }
            while(gameRunning)
            {
                menu.GameMenu(player);
            }
        }
    }
}
