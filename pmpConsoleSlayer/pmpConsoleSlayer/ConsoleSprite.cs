using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmpConsoleSlayer
{
    internal class ConsoleSprite
    {
        public ConsoleColor Foreground;
        public ConsoleColor Background;
        public char Glyph;

        public ConsoleSprite(ConsoleColor fg, ConsoleColor bg, char g)
        {
            Foreground = fg;
            Background = bg;
            Glyph = g;
        }

    }
}
