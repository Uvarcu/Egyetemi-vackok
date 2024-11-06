using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pmpConsoleSlayer
{
    internal class Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Position Add(Position a, Position b)
        {
            return new Position(a.x + b.x, a.y + b.y);
        }

        public static double Distance(Position a, Position b)
        {
            return Math.Sqrt(Math.Pow(b.x - a.x,2) + Math.Pow(b.y - a.y, 2));
        }
    }
}
