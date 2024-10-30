using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmp7TulajdonsagosKapcsolatos
{
    internal class Mole
    {
        public int Position { get; private set; }

        public void TurnUp()
        {
            Console.WriteLine("M".PadLeft(Position));
        }

        public void Hide(int x, int y)
        {
            Random r = new Random();
            Position = r.Next(x, y+1);
        }

    }
}
