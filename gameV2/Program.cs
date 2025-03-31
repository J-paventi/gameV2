namespace gameV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextUI textUI = new();
            Menu menu = new();
            PlayerDetails playerDetails = new();
            menu.StartMenu();
            textUI.Welcome();
            playerDetails.Name = textUI.GetPlayerName();
        }
    }
}
