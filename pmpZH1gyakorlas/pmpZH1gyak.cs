namespace pmpZH1gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Feladat:
            string[] availableGenres = File.ReadAllText("genre.txt").Split(", ");
            //2.Feladat a):
            string[] rows = File.ReadAllLines("games_dataset.csv");
            List<Game> games = new List<Game>();
            foreach (string row in rows)
                if (row != rows[0]) games.Add(new Game(row));
            //2.Feladat b):
            foreach (Game game in games)
                game.GenreCorrection(availableGenres);

            //3.Feladat:
            Console.WriteLine("Adj meg egy kiadót!");
            string askedPublisher = Console.ReadLine();
            int gamesFromThePublisher = 0;
            foreach (Game game in games)
                if (game.Publisher == askedPublisher) gamesFromThePublisher++;
            Console.WriteLine($"Ettől a kiadótól: {askedPublisher} ennyi játék készült: {gamesFromThePublisher}");
            //4.Feladat:
            Console.WriteLine("A megjelenés napjától elérhető játékok:");
            foreach (Game game in games)
            {
                if (game.PlatformRelease.Year == game.OriginalRelease.Year)
                {
                    Console.WriteLine($"\n\tCím: {game.Title}");
                    Console.WriteLine($"\tMűfaj: {game.Genre}");
                    Console.WriteLine($"\tMegjelenés éve: {game.OriginalRelease.Year}");
                }
            }
            //5.Feladat:
            Console.WriteLine("\nJátékok száma műfajonként:");
            foreach (string genre in availableGenres)
            {
                int genreCount = 0;
                foreach (Game game in games)
                    if (game.Genre == genre) genreCount++;
                Console.WriteLine($"\t{genre}: {genreCount} db");
            }
            Console.ReadKey();
        }
    }
}