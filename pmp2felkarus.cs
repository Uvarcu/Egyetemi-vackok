namespace SZRJ_Orai
{
    internal class Program
    {
        static void Main(string[] args)
        {
          * 
            //1.feladat:
            Console.WriteLine("1..Feladat:\nAdj meg egy N pozitív egész számot (a 3. feladat miatt 1-1000)!");
            int limit = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"A páros számok 0-{limit}");
            for (int i = 0; i <= limit; i++)
                if(i%2==0) Console.WriteLine(i);
            //2.feladat:
            string actualPwd = "pwd123";
            string givenPwd;
            Console.WriteLine("2.Feladat:");
            do
            {
                Console.WriteLine("Add meg a jelszavadat! (pwd123)");
                givenPwd = Console.ReadLine()!;
            }
            while (givenPwd != actualPwd);
            //3.feladat:
            Random r = new Random();
            int probalkozas = 0;
            int generaltSzam;
            do
            {
                probalkozas++;
                generaltSzam = r.Next(1000) + 1;
            }
            while (generaltSzam != limit);
            Console.WriteLine($"3.Feladat:\nLegenerálni a számot amit az elején adtál, {probalkozas} próbálkozásba került");
            //4.feladat:
            Console.WriteLine("4.Feladat:\nAdja meg a játékosok számát a társasjátékhoz!");
            int jatekosSzam = int.Parse(Console.ReadLine()!);
            int aktualisJatekos = 0;
            int aktualisDobas;
            do
            {
                if (aktualisJatekos == jatekosSzam) aktualisJatekos = 1;
                else aktualisJatekos++;
                Console.ReadKey();
                aktualisDobas = r.Next(6) + 1;
                Console.WriteLine($"Aktuális játékos: {aktualisJatekos} \t Aktuális dobás: {aktualisDobas}");
            }
            while (aktualisDobas != 6);
            Console.WriteLine($"A {aktualisJatekos}. számú játékos fog kezdeni!");
            //5.feladat:
            probalkozas = 0;
            int gondoltSzam = r.Next(100)+1;
            int bekertSzam = 0;
            Console.WriteLine("5.Feladat:\nGondoltam egy számra! Találgass én elmondom jó e vagy sem, ha nem jó, kisebb vagy nagyobb a gondolt számom!");
            do
            {
                if (probalkozas != 0)
                {
                    Console.WriteLine($"a szám amire gondoltam: {(bekertSzam > gondoltSzam ? "kisebb" : "nagyobb")} mint {bekertSzam}");
                }
                else
                    Console.WriteLine("Adja meg a számot amire tippel!");
                probalkozas++;
                bekertSzam = int.Parse(Console.ReadLine()!);
            }
            while (bekertSzam != gondoltSzam);
            Console.WriteLine($"Eltaláltad! A szám amire gondoltam, az pont {gondoltSzam}");
            //6.feladat:
            Console.WriteLine("6.Feladat:\nAdj meg egy pozitív egész számot!");
            bekertSzam= int.Parse(Console.ReadLine()!);
            Console.WriteLine($"Ez a szám: {bekertSzam}\n{(bekertSzam%2==0?"páros":"páratlan")}");
            Console.Write("Pozitív valódi osztóinak száma: ");
            int osztokSzama = 0;
            for (int i = 2; i < bekertSzam; i++)
                if (bekertSzam%i==0)
                    osztokSzama++;
            Console.WriteLine(osztokSzama);
            Console.WriteLine(osztokSzama==0?"Prímszám":"Összetett szám");
            //7.feladat:
            Console.WriteLine("7.Feladat:\nAdj meg egy számot aminek veszem a faktoriálisát!");
            bekertSzam = int.Parse(Console.ReadLine()!);
            int vegeredmeny = 1;
            for (int i = 2; i <= bekertSzam; i++)
                vegeredmeny *= i;
            Console.WriteLine($"{bekertSzam}! = {vegeredmeny}");
            //8.feladat:
            Console.WriteLine("8.Feladat: A szorzótábla");
            for (int i = 1; i <= 9; i++)
                for (int j = 1; j <= 9; j++)
                    Console.Write(i*j + (j==9?"\n":"\t"));
            //9.feladat:
            Console.WriteLine("Adj meg egy időtartamot másodpercben!");
            bekertSzam = int.Parse(Console.ReadLine()!);
            TimeSpan counter = TimeSpan.FromSeconds(bekertSzam);
            while(counter.TotalSeconds != 0)
            {
                Console.Clear();
                counter = TimeSpan.FromSeconds(counter.TotalSeconds-1);
                Console.WriteLine(counter.Minutes.ToString("00") + ":" + counter.Seconds.ToString("00"));
                Thread.Sleep(1000);
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Beep();
            Console.ResetColor();
            //10.feladat:
            Console.WriteLine("Adj meg egy 32bites előjel nélküli egész-be illeszkedő számot! Átalakítom binárisra");
            bekertSzam = int.Parse(Console.ReadLine()!);
            string binaris = "";
            double maradekSzam = bekertSzam;
            for (int i = 31;i >=0; i--)
            {
                double hatvany = Math.Pow(2, i);
                if (maradekSzam >= hatvany)
                {
                    binaris += "1";
                    maradekSzam -= hatvany;
                }
                else
                    binaris += "0";
                if ((31 - i + 1) % 8 == 0 && i != 0 && i != 31) binaris += " ";
            }
            Console.WriteLine($"{bekertSzam} (10) = {binaris} (2)");
            //11.feladat:
            /*Console.WriteLine("Félkarú rablót csinálunk. 100 kredittel kezdesz, fel és legombbal tudod növelni/csökenteni a tétet\n" +
                "Spacebar billentyűvel tudsz pörgetni és az Escape billentyűvel tudsz kilépni");
            int credit = 100;
            int bet = 1;
            bool jatek = true;
            Console.WriteLine($"Jelenlegi Kredited: {credit}");
            do
            {
                var action = Console.ReadKey().Key;
                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        bet++;
                        break;
                    case ConsoleKey.DownArrow:
                        bet--;
                        break;
                    case ConsoleKey.Spacebar:
                        break;
                }
            }
            while (jatek);*/
        }
    }
}
