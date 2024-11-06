namespace pmpConsoleSlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            List<GameItem> gameItems = new List<GameItem>()
            {
                new GameItem(new Position(0, 1), ItemType.Wall),
                new GameItem(new Position(1, 1), ItemType.Ammo),
                new GameItem(new Position(2, 1), ItemType.Door)
            };
            game.Items.AddRange(gameItems);
            game.Run();
        }
    }
}
