namespace pmpZH1gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Feladat:
            string[] availableGenres = File.ReadAllText("genre.txt").Split(", ");
            //2.Feladat:
            string[] rows = File.ReadAllLines("games_dataset.csv");
            string[] titles = new string[rows.Length - 1];
            string[] genres = new string[rows.Length - 1];
            int[] genreIds = new int[rows.Length - 1];
            string[] publishers = new string[rows.Length - 1];
            DateTime[] platformReleaseDates = new DateTime[rows.Length - 1];
            DateTime[] originalReleaseDates = new DateTime[rows.Length - 1];
            int index = -1;
            foreach (string row in rows)
            {
                if (index != -1)
                {
                    string[] parts = row.Split(";");
                    titles[index] = parts[0];
                    genres[index] = parts[2];
                    genreIds[index] = Array.IndexOf(availableGenres, genres[index]);
                    publishers[index] = parts[3];
                    platformReleaseDates[index] = DateTime.Parse(parts[4]);
                    originalReleaseDates[index] = DateTime.Parse(parts[5]);
                }
                index++;
            }
            //3.Feladat:
            Console.WriteLine("Adj meg egy kiadót!");
            string askedPublisher = Console.ReadLine();
            int gamesFromThePublisher = 0;
            foreach (string publisher in publishers)
                if (publisher == askedPublisher) gamesFromThePublisher++;
            Console.WriteLine($"Ettől a kiadótól: {askedPublisher} ennyi játék készült: {gamesFromThePublisher}");
            //4.Feladat:
            Console.WriteLine("A megjelenés napjától elérhető játékok:");
            index = 0;
            foreach (DateTime date in platformReleaseDates)
            {
                if (date.Year == originalReleaseDates[index].Year)
                {
                    Console.WriteLine($"\n\tCím: {titles[index]}");
                    Console.WriteLine($"\tMűfaj: {genres[index]}");
                    Console.WriteLine($"\tMegjelenés éve: {date.Year}");
                }
                index++;
            }
            //5.Feladat:
            Console.WriteLine("\nJátékok száma műfajonként:");
            foreach (string genre in availableGenres)
            {
                int genreCount = 0;
                foreach (string gameGenre in genres)
                    if (gameGenre == genre) genreCount++;
                Console.WriteLine($"\t{genre}: {genreCount} db");
            }
            Console.ReadKey();
        }
    }
}