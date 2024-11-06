using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmpConsoleSlayer
{
    internal class Player
    {
        public Position Position { get; set; }
        public ConsoleSprite Sprite { get; set; }
        public double FillingRatio { get; set; }
        public Player(Position position)
        {
            Position = position;
            Sprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.Black, 'O');
            FillingRatio = 0.5;
        }
    }
}
