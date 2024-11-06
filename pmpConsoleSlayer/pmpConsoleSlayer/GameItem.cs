using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmpConsoleSlayer
{
    internal class GameItem
    {
        public Position Position { get; set; }
        public ConsoleSprite Sprite { get; set; }
        public ItemType Type { get; set; }
        public double FillingRatio { get; set; }
        public bool Available { get; set; }
        private void SetInitialProperties()
        {
            switch(Type)
            {
                case ItemType.Ammo:
                    Sprite = new ConsoleSprite(ConsoleColor.Yellow, ConsoleColor.Red, 'A');
                    FillingRatio = 0.0;
                    break;
                case ItemType.BFGCell:
                    Sprite = new ConsoleSprite(ConsoleColor.White, ConsoleColor.White, 'B');
                    FillingRatio = 0.0;
                    break;
                case ItemType.Door:
                    Sprite = new ConsoleSprite(ConsoleColor.Yellow, ConsoleColor.DarkGray, '/');
                    FillingRatio = 1.0;
                    break;
                case ItemType.LevelExit:
                    Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Blue, 'e');
                    FillingRatio = 1.0;
                    break;
                case ItemType.Medikit:
                    Sprite = new ConsoleSprite(ConsoleColor.Red, ConsoleColor.Gray, '+');
                    FillingRatio = 0.0;
                    break;
                case ItemType.ToxicWaste:
                    Sprite = new ConsoleSprite(ConsoleColor.White, ConsoleColor.DarkGreen, ':');
                    FillingRatio = 0.0;
                    break;
                case ItemType.Wall:
                    Sprite = new ConsoleSprite(ConsoleColor.White, ConsoleColor.DarkGray, ' ');
                    FillingRatio = 1.0;
                    break;
            }    
        }
        public GameItem(Position position, ItemType itemtype)
        {
            Position = position;
            this.Type = itemtype;
            SetInitialProperties();
            Available = true;
        }
        public void Interact()
        {
            ItemType[] consumables = { ItemType.Ammo, ItemType.BFGCell, ItemType.Medikit };
            if (Type == ItemType.Door)
            {
                Available = !Available;
                if (FillingRatio == 0.0)
                {
                    FillingRatio = 1.0;
                    Sprite = new ConsoleSprite(ConsoleColor.DarkRed, ConsoleColor.DarkGray, '/');
                }
                else
                {
                    FillingRatio = 0.0;
                    Sprite = new ConsoleSprite(ConsoleColor.Yellow, ConsoleColor.DarkGray, '/');
                }
            }
            else if (consumables.Contains(Type)) Available = false;
        }
    }
}
