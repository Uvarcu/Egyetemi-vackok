namespace PMP_2024_09_25_Feladatsor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new();
            /*
            //1.feladat
            Console.WriteLine("1. feladat - kártyák feltöltése.");
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jumbó", "Dáma", "Király", "Ász" };
            string[] cards = new string[52];
            for (int suits = 0; suits < 4; suits++)
            {
                string suit = suits switch
                {
                    0 => "Kőr",
                    1 => "Treff",
                    2 => "Káró",
                    _ => "Pikk"
                };
                for (int value = 0; value < values.Length; value++)
                    cards[suits * 13 + value] = suit + " " + values[value];
            }
            //2.feladat
            Console.WriteLine("2. feladat - kártyák keverése.");
            for (int card = 0; card < 52; card++)
            {
                string storedCard = cards[card];
                int replacement = r.Next(card, 52);
                cards[card] = cards[replacement];
                cards[replacement] = storedCard;
            }
            //3.feladat ÉS 4.feladat
            Console.WriteLine("3. ÉS 4. feladat - szavak elrakása és bekérése." +
                "\nAdj meg szavakat ENTER-rel elválasztva, vagy írd hogy 'STOP' ha nem akarsz többet.");
            List<string> words = new List<string>();
            bool need = true;
            while (need)
            {
                string input = Console.ReadLine()!;
                if (input == "STOP") need = false;
                else words.Add(input);
            }
            Console.WriteLine("Most adj meg egy szót és én megmondom benne van-e, és ha igen, hol!");
            int index = 0;
            need = true;
            string askedWord = Console.ReadLine()!;
            while (index < words.Count && need)
            {
                if (askedWord == words[index]) need = false;
                else index++;
            }
            if (need) Console.WriteLine("Nincsen benne a szó a gyűjteményben.");
            else Console.WriteLine($"A szó benne van, méghozzá a(z) {index + 1}. helyen először!");
            //5.feladat
            need = true;
            List<string> names = new();
            List<int> ages = new();
            List<bool> knowledges = new();
            Console.WriteLine("Adj meg neveket majd azokhoz életkort és igen/nem-mel programozói tudást" +
                "\nAzesetben ha már nem kívánnál neveket bevinni, a névnél nyomj entert!");
            while (need)
            {
                Console.WriteLine("Adj meg egy nevet!");
                string givenName = Console.ReadLine() ?? "";
                if (givenName == "") need = false;
                else
                {
                    names.Add(givenName);
                    Console.WriteLine("Most adj meg egy életkort hozzá!");
                    ages.Add(int.Parse(Console.ReadLine()!));
                    Console.WriteLine("Most add meg, tud-e prrogramozni? (igen/nem, ha mást adsz meg -> automatikusan nem)");
                    knowledges.Add(Console.ReadLine() == "igen");
                }
            }
            int sum = 0;
            index = 0;
            int count = 0;
            int max = 0;
            int maxPos = 0;
            foreach (int age in ages) sum += age;
            Console.WriteLine("Az átlag életkor: " + ((double)sum / ages.Count));
            sum = 0;
            foreach (bool knowledge in knowledges)
            {
                if (!knowledge)
                {
                    sum += ages[index];
                    count++;
                }
                else
                {
                    if (ages[index] > max)
                    {
                        max = ages[index];
                        maxPos = index;
                    }
                }
                index++;
            }
            Console.WriteLine("Az átlag életkora a programozni NEM tudó embereknek: " + ((double)sum / count));
            Console.WriteLine($"A legidősebb programozó: {names[maxPos]} ({ages[maxPos]} év)");
            //6.feladat
            int n = r.Next(1, 11);
            int m = r.Next(1, 11);
            int[,] matrix = new int[n, m];
            Console.WriteLine("6.feladat:\nMátrix:");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = r.Next(10);
                    Console.Write(matrix[row, col] + (col == m - 1 ? "\n" : "\t"));
                }
            }
            Console.WriteLine("Transzponált mátrix:");
            for (int col = 0; col < m; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    Console.Write(matrix[row, col] + (row == n - 1 ? "\n" : "\t"));
                }
            }
            //7.feladat
            Console.WriteLine("\n7.feladat");
            //Én most itt az előző mátrixot fogom használni mint véletlenszerű mátrix
            int[] sumOfCatches = new int[n];
            for (int row = 0; row < n; row++)
            {
                sum = 0;
                for (int col = 0; col < m; col++)
                {
                    sum += matrix[row, col];
                    Console.Write(matrix[row, col] + (col == m - 1 ? "\n" : "\t"));
                }
                sumOfCatches[row] = sum;
            }
            max = 0;
            maxPos = 0;
            index = 0;
            bool unluckyFisher = false;
            foreach (int fish in sumOfCatches)
            {
                if (fish > max)
                {
                    max = fish;
                    maxPos = index;
                }
                if (fish == 0) unluckyFisher = true;
                index++;
            }
            Console.WriteLine($"A legtöbb halat fogó horgász a(z) {maxPos + 1}. horgász volt, {max} hallal." +
                $"\n{(unluckyFisher ? "Volt" : "Nem volt")} olyan horgász, aki nem fogott egy halat sem.");
            //8.feladat
            Console.WriteLine("8.feladat\nAdj meg egy N pozitív értéket");
            List<int> collatz = new List<int>();
            collatz.Add(int.Parse(Console.ReadLine()!));
            while (collatz.Last() != 1)
            {
                int k = collatz.Last();
                collatz.Add(k % 2 == 0 ? k / 2 : 3 * k + 1);
            }
            Console.WriteLine("A lista sikeresen eljutott 1-ig!");
            //9.feladat
            Console.WriteLine("9.feladat");
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            for (int i = 0; i < x.Length / 2; i++)
            {
                int tmp = x[i];
                x[i] = x[x.Length - i - 1];
                x[x.Length - i - 1] = tmp;
            }
            foreach (int i in x) Console.WriteLine(i);
            //10.feladat
            Console.WriteLine("10.feladat");
            int[] randomArray = new int[4];
            List<int> everySecondItemArray = new List<int>();
            List<int> everySecondItemList = new List<int>();
            List<int> randomList = new(4);
            for (int i = 0; i < 4; i++)
            {
                randomArray[i] = r.Next(1, 10);
                randomList.Add(r.Next(1, 10));
                if (i % 2 == 1) everySecondItemArray.Add(randomArray[i]);
                if (i % 2 == 1) everySecondItemList.Add(randomList[i]);
            }
            Console.WriteLine("Elemek: " + string.Join("\t", randomArray));
            for (int i = 0; i < randomArray.Length / 2; i++)
                (randomArray[randomArray.Length - i - 1], randomArray[i]) = (randomArray[i], randomArray[randomArray.Length - i - 1]);
            for (int i = 0; i < randomList.Count / 2; i++)
                (randomList[randomList.Count - i - 1], randomList[i]) = (randomList[i], randomList[randomList.Count - i - 1]);
            Console.WriteLine("Második elemek kiválogatva, elemek megfordítva");
            Console.WriteLine("Második elemek: " + string.Join("\t", everySecondItemArray));
            Console.WriteLine("Elemek a fordítás után: " + string.Join("\t", randomArray));
            n = 2;
            m = 2;
            matrix = new int[n, m];
            Console.WriteLine("Az ebből elkészült négyzetes mátrix:");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (row * 2 + col > randomArray.Length) matrix[row, col] = 0;
                    else matrix[row, col] = randomArray[row * 2 + col];
                    Console.Write(matrix[row, col] + (col == m - 1 ? "\n" : "\t"));
                }
            }
            //11.feladat
            //Legyen most a matrix az előző n = m = 2 matrix
            int K = matrix[0, 0];
            Console.WriteLine($"11.feladat: Az előző mátrix {K} alkalommal elforgatva 90fokban:");
            for (int i = 0; (i < K%4); i++)
            {
                int[,] matrixAfterRotation = new int[m, n];
                for (int col = 0; col < m; col++)
                    for (int row = 0; row < n; row++)
                        matrixAfterRotation[col,n-row-1] = matrix[row, col];
                matrix = matrixAfterRotation;
            }
            for (int row = 0; row < n; row++)
                for (int col = 0; col < m; col++)
                    Console.Write(matrix[row, col] + (col == m - 1 ? "\n" : "\t"));
            //12.feladat*/
            Console.WriteLine("12.feladat: Labirintus!");
            int n = 4;
            int m = 10;
            bool[,] labirinth = new bool[n, m];
            for (int row = 0; row < n; row++)
                for (int col = 0; col < m; col++)
                {
                    labirinth[row, col] = r.Next(2) == 1;
                    Console.Write((labirinth[row, col]?"T":"F") + (col == m - 1 ? "\n" : "\t"));
                }
            Console.WriteLine("Adj meg egy X és Y koordinátát ENTER-rel elválasztva!");
            int Y = int.Parse(Console.ReadLine()!)-1;
            int X = int.Parse(Console.ReadLine()!)-1;
            bool solvable = false;
            bool need = true;
            while (need)
            {
                if (X == labirinth.GetLength(0) - 1 && Y == labirinth.GetLength(1) - 1)
                {
                    need = false;
                    solvable = true;
                }
                else
                {
                    bool up = X > 0 && labirinth[X - 1, Y];
                    bool down = X + 1 < n && labirinth[X + 1, Y];
                    bool left = Y > 0 && labirinth[X, Y - 1];
                    bool right = Y + 1 < m && labirinth[X, Y + 1];
                    if (right)
                    {
                        if (!left && !up && !down) labirinth[X, Y] = false;
                        Y += 1;
                        Console.WriteLine("Jobbra");
                    }
                    else if (down)
                    {
                        if (!left && !up && !right) labirinth[X, Y] = false;
                        X += 1;
                        Console.WriteLine("Le");
                    }
                    else if (left)
                    {
                        if (!right && !up && !down) labirinth[X, Y] = false;
                        Y -= 1;
                        Console.WriteLine("Balra");
                    }
                    else if (up)
                    {
                        if (!left && !right && !down) labirinth[X, Y] = false;
                        X -= 1;
                        Console.WriteLine("Fel");
                    }
                    else
                    {
                        need = false;
                    }
                }
            }
            Console.WriteLine($"A labirintusnak {X+1}-{Y+1} koordinátás kezdéssel {(solvable?"":"nem ")}megoldható");
        }
    }
}
