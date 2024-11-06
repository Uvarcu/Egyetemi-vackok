using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmpConsoleSlayer
{
    internal class Game
    {
        public Player Player { get; set; }
        public bool Exited { get; set; }
        public List<GameItem> Items { get; set; }
        public Game()
        {
            Player = new Player(new Position(0, 0));
            Exited = false;
            Items = new List<GameItem>();
        }

        public void RenderSingleSprite(Position pos, ConsoleSprite sprite)
        {
            if (pos.x < Console.WindowWidth && pos.x >= 0 && pos.y < Console.WindowHeight && pos.y >= 0)
            {
                Console.BackgroundColor = sprite.Background;
                Console.ForegroundColor = sprite.Foreground;
                Console.SetCursorPosition(pos.x, pos.y);
                Console.Write(sprite.Glyph);
                Console.ResetColor();
            }
        }

        private void RenderGame()
        {
            Console.CursorVisible = false;
            Console.Clear();
            foreach (GameItem item in Items)
                RenderSingleSprite(item.Position, item.Sprite);
            RenderSingleSprite(Player.Position, Player.Sprite);
        }
        private void CleanUpGameItems()
        {
            List<GameItem> trash = new();
            foreach (GameItem item in Items)
                if (!item.Available) trash.Add(item);
            foreach (GameItem garbage in trash)
                Items.Remove(garbage);
        }
        private void UserAction()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                switch (pressed.Key)
                {
                    case ConsoleKey.Escape:
                        Exited = true;
                        break;
                    case ConsoleKey.UpArrow:
                        Move(Player, Position.Add(Player.Position, new Position(0, -1)));
                        break;
                    case ConsoleKey.DownArrow:
                        Move(Player, Position.Add(Player.Position, new Position(0, 1)));
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(Player, Position.Add(Player.Position, new Position(-1, 0)));
                        break;
                    case ConsoleKey.RightArrow:
                        Move(Player, Position.Add(Player.Position, new Position(1, 0)));
                        break;
                }
            }
        }
        public void Run()
        {
            while(!Exited)
            {
                RenderGame();
                UserAction();
                Thread.Sleep(25);
            }
        }
        private List<GameItem> GetGameItemsWithinDistance(Position position, double distance)
        {
            List<GameItem> closeItems = new List<GameItem>();
            foreach(GameItem gameItem in Items)
                if (Position.Distance(position,gameItem.Position) <= distance) closeItems.Add(gameItem);
            return closeItems;
        }

        private double GetTotalFillingRatio(Position position)
        {
            List<GameItem> closeItems = GetGameItemsWithinDistance(position, 0);
            double total = 0.0;
            foreach (GameItem gameItem in closeItems)
                total += gameItem.FillingRatio;
            return total;
        }
        private void Move(Player player, Position position)
        {
            double totalFillingRatioAtDestination = GetTotalFillingRatio(position) + Player.FillingRatio;
            if (totalFillingRatioAtDestination <= 1.0)
            {
                player.Position = position;
            }
        }
    }
}
