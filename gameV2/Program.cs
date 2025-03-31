namespace gameV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextUI textUI = new();
            Menu menu = new();
            PlayerDetails player = new();
            menu.StartMenu();
            textUI.Welcome();
            player.Name = textUI.GetPlayerName();
            //menu.CharacterBuildMenu(player);
            //Console.Clear();
            //player.DisplayPlayerDetails();
            //textUI.ConfirmChoices(player);
            while(player.PlayerClass == null || player.Sex == null || player.Race == null)
            {
                menu.CharacterBuildMenu(player);
                Console.Clear();
                player.DisplayPlayerDetails();
                textUI.ConfirmChoices(player);
            }
        }
    }
}
