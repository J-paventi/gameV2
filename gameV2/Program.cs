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
            player.DisplayPlayerDetails();
            menu.CharacterBuildMenu(player);
        }
    }
}
