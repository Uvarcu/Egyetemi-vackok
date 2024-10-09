using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmpZH1gyak
{
    internal class Game
    {
        public string Title;
        public int GenreId;
        public string Genre;
        public string Publisher;
        public DateTime PlatformRelease;
        public DateTime OriginalRelease;
        public Game(string row)
        {
            string[] parts = row.Split(';');
            Title = parts[0];
            GenreId = int.Parse(parts[1]);
            Genre = parts[2];
            Publisher = parts[3];
            PlatformRelease = DateTime.Parse(parts[4]);
            OriginalRelease = DateTime.Parse(parts[5]);
        }

        public void GenreCorrection(string[] genres)
        {
            GenreId = Array.IndexOf(genres, Genre);
        }
    }
}
