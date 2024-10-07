using System.Globalization;

namespace pmp5fajlos
{
    internal class Program
    {
        static void ColoredOutput(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                string[] parts = text[i].Split('#');
                Console.ForegroundColor = parts[0] switch
                {
                    "Blue" => ConsoleColor.Blue,
                    "Red" => ConsoleColor.Red,
                    "Green" => ConsoleColor.Green,
                };
                Console.WriteLine(parts[1]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void GenerateWinningNumbers(DateTime date)
        {
            int[] numbers = new int[5];
            Random r = new();
            int i = 0;
            while (i < numbers.Length)
            {
                int number = r.Next(90)+1;
                if (!numbers.Contains(number))
                {
                    numbers[i] = number;
                    i++;
                }
            }
            Console.Write($"On {date.ToString("yyyy.MM.dd")}. numbers were: {string.Join(' ',numbers)}\nAnother week? [y/n] ");
            if (Console.ReadLine() == "y") GenerateWinningNumbers(date.AddDays(7));
        }
        static void AntMovement(string[] text)
        {
            string[] parameters = text[0].Split(' ');
            int x = int.Parse(parameters[0]);
            int y = int.Parse(parameters[1]);
            int degree = int.Parse(parameters[2]);
            foreach (string order in text.Skip(1))
            {
                string[] orderParts = order.Split(' ');
                string command = orderParts[0];
                int value = int.Parse(orderParts[1]);
                if (command == "left")
                    degree = (degree + value) % 360;
                if (command == "right")
                    degree = (degree - value) % 360;
                if (command == "go")
                {
                    switch (degree)
                    {
                        case 0:
                            x += value;
                            break;
                        case 90:
                            y += value;
                            break;
                        case 180:
                            x -= value;
                            break;
                        default:
                            y -= value;
                            break;
                    }
                }
            }
            Console.WriteLine($"The ant's final position is: ({x},{y}) degree: {degree}");
        }
        static void Nhanes(string[] text)
        {
            CultureInfo culture = new CultureInfo("en-US");
            int[] id = new int[text.Length-1];
            string[] period = new string[text.Length-1];
            byte[] gender = new byte[text.Length-1];
            double[] ages = new double[text.Length - 1];
            double[] bmi = new double[text.Length - 1];
            double[] bloodSugarLevel = new double[text.Length - 1];
            int index = 0;
            foreach (string row in text.Skip(1))
            {
                string[] attributes = row.Split(',');
                id[index] = int.Parse(attributes[0]);
                period[index] = attributes[1];
                gender[index] = byte.Parse(attributes[2], culture);
                ages[index] = double.Parse(attributes[3], culture);
                bmi[index] = double.Parse(attributes[4], culture);
                bloodSugarLevel[index] = double.Parse(attributes[5], culture);
                index++;
            }
            double overweightAges = 0;
            int overweightCount = 0;
            double avgBmi = 0;
            double highestBmi = 0;
            index = 0;
            foreach (double i in bmi)
            {
                if (i >= 30)
                {
                    overweightAges += ages[index];
                    overweightCount++;
                }
                avgBmi += i;
                if (highestBmi<i) highestBmi = i;
                index++;
            }
            avgBmi /= bmi.Length;
            double highSBL = 0;
            foreach (double i in bloodSugarLevel)
                if (i > 5.6) highSBL++;
            highSBL /= bloodSugarLevel.Length;
            Console.WriteLine("Avg bmi: " + avgBmi);
            Console.WriteLine("High BloodSugarLevel %: " + highSBL.ToString("P2"));
            Console.WriteLine("Highest Bmi person's BSL: " + bloodSugarLevel[Array.IndexOf(bmi, highestBmi)].ToString("#0.0"));
            Console.WriteLine("Overweight people avg age: " + (overweightAges/overweightCount).ToString("##.##"));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1.Feladat:");
            ColoredOutput(File.ReadAllLines("1feladat.txt"));
            GenerateWinningNumbers(DateTime.Now);
            AntMovement(File.ReadAllLines("2feladat.txt"));
            Nhanes(File.ReadAllLines("NHANES_1999-2018.csv"));

            Console.ReadKey();
        }
    }
}
