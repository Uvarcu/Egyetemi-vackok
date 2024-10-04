namespace pmp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Feladat:
            Console.WriteLine("Adj meg egy szót az elemzéshez!");
            Console.WriteLine(Observer(Console.ReadLine()));
            //2.Feladat:
            Console.WriteLine("Adj meg egy szót és én megmondom hogy Palindróm-e?");
            Console.WriteLine(Palindrom(Console.ReadLine())?"Igen":"Nem");
            //3.Feladat:
            string[] examples = { "aabc 123", "a a BC123", "a a B c 1 2 3", "AABc-123" };
            foreach (string example in examples)
                Console.WriteLine($"Ebből: '{example}'\tEz lett: '{MyFormatter(example)}'");
            //4.Feladat:
            Console.WriteLine("Generálok X db rendszámot! Mennyi legyen az X?");
            int neededValuesCount = int.Parse(Console.ReadLine());
            int db = 0;
            List<string> generatedValues = new List<string>();
            while (db < neededValuesCount)
            {
                string generatedValue = Generate();
                if (!generatedValues.Contains(generatedValue))
                {
                    generatedValues.Add(generatedValue);
                    db++;
                }
            }
            foreach (string value in generatedValues)
                Console.WriteLine(value);
            //5.Feladat:
            Console.WriteLine("Adj meg egy email-t!");
            Console.WriteLine(CheckEmail(Console.ReadLine())?"Az email helyes":"Az email helytelen");
            //6.Feladat:
            Console.WriteLine("Add meg a neptunkódodat! (EZ MOST NEM MŰKÖDIK, MERT 99ÉV)");
            //Console.WriteLine(TryYourNeptunCode(Console.ReadLine()) + " próbálkozás kellett, mire legeneráltuk véletlenül pont a tiédet");
            //7.Feladat:
            Console.WriteLine("Az eredeti szöveg: 'Well, a Big Mac's a Big Mac, but they call it le Big-Mac'");
            string originalText = "Well, a Big Mac's a Big Mac, but they call it le Big-Mac.";
            Console.WriteLine("Átalakított szöveg: " + ToSponge(originalText));
            //8.Feladat:
            Console.WriteLine("Az eredeti szöveg: Vincent;Vega;Vince\nMarsellus;Wallace;Big Man\nWinston;Wolf;The Wolf");
            string s = "Vincent;Vega;Vince\nMarsellus;Wallace;Big Man\nWinston;Wolf;The Wolf";
            string[,] matrix = ToMatrix(s);
            MatrixOutput(matrix);
            //9.Feladat:
            Console.WriteLine("Adj meg zárójelsorozatot és én eldöntöm hogy helyes vagy sem!");
            string brackets = Console.ReadLine();
            Console.WriteLine(IsValidBrackets(brackets)?"Helyes":"Nem helyes");
            //10.Feladat:




            //METHODS
            string Observer(string word)
            {
                string validLetters = "aáeéiíoóöőüűuú";
                int letters = 0, digits = 0, validLetterCount = 0;
                foreach (char c in word)
                {
                    if (char.IsLetter(c))
                    {
                        if (validLetters.Contains(c)) validLetterCount++;
                        letters++;
                    }
                    else if (char.IsDigit(c)) digits++;
                }
                return $"Betűk: {letters}db\tszámok: {digits}db\tMagánhangzók: {validLetterCount}db";
            }
            
            bool Palindrom(string word)
            {
                string text = word.Replace(" ","").ToLower();
                return text == new string(text.Reverse().ToArray());
            }
            
            string MyFormatter(string original)
            {
                string text = original.Replace(" ", "").Replace("-", "").ToUpper();
                string final = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (i == 2) final += " ";
                    if (i == 4) final += "-";
                    final += text[i];
                }
                return final;
            }
            
            string Generate()
            {
                Random r = new();
                string final = "";
                for (int i = 0; i < 4; i++)
                {
                    if (i == 2) final += " ";
                    final += (char)r.Next(65, 65 + 25 + 1);
                }
                final += "-";
                for (int i = 0; i < 3; i++)
                    final += r.Next(1, 10);
                return final;
            }
            
            bool CheckEmail(string email)
            {
                //a
                string[] parts = email.Split('@');
                if (parts.Length != 2) return false;
                string localPart = parts[0];
                string domainPart = parts[1];
                //b
                bool hasLetterBeforeAt = false;
                foreach (char c in localPart)
                    if (char.IsLetter(c)) hasLetterBeforeAt = true;
                if (!hasLetterBeforeAt) return false;
                //c
                if (!domainPart.Contains('.')) return false;
                //d
                int lastDotPos = domainPart.LastIndexOf('.');
                bool hasLetterDigitBetween = false;
                for (int i = 0; i < lastDotPos; i++)
                    if (char.IsLetterOrDigit(domainPart[i])) hasLetterDigitBetween = true;
                if (!hasLetterDigitBetween) return false;
                //e
                for (int i = 1; i < localPart.Length - 1; i++)
                    if (localPart[i] == '.' && ((!char.IsLetterOrDigit(localPart[i - 1]) && localPart[i - 1] != '@') || (!char.IsLetterOrDigit(localPart[i + 1]) && localPart[i + 1] != '@')))
                        return false;
                if (localPart.Contains('.') && (localPart.Length < 3 || localPart.Last() == '.')) return false;
                //f
                string afterLastDot = domainPart.Substring(lastDotPos + 1);
                if (afterLastDot.Length < 2) return false;
                foreach (char c in afterLastDot)
                    if (!char.IsLetter(c)) return false;

                return true;
            }
            
            ulong TryYourNeptunCode(string originalCode)
            {
                Random r = new();
                ulong attempts = 0;
                string code = "";
                do
                {
                    code = "" + (char)r.Next(65, 65 + 25 + 1);
                    for (int i = 0; i < 5; i++)
                    {
                        if (r.Next(2) == 0) code += r.Next(10);
                        else code += (char)r.Next(65, 65 + 25 + 1);
                    }
                    attempts++;
                }
                while (code != originalCode);
                return attempts;
            }
            
            string ToSponge(string text)
            {
                string final = "";
                Random r = new();
                foreach (char c in text)
                {
                    if (r.Next(2) == 0) final += char.ToUpper(c);
                    else final += char.ToLower(c);
                }
                return final;
            }
            
            string[,] ToMatrix(string s)
            {
                int rows = s.Split('\n').Count();
                int cols = s.Split('\n').First().Split(';').Count();
                string[,] tempMatrix  = new string[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        tempMatrix[i, j] = s.Split('\n')[i].Split(';')[j];
                return tempMatrix;
            }
            
            void MatrixOutput(string[,] m)
            {
                for (int i = 0; i < m.GetLength(0); i++)
                    for (int j = 0; j < m.GetLength(1); j++)
                        Console.Write(m[i, j] + (j == m.GetLength(1) - 1 ? "\n" : "\t"));
            }

            bool IsValidBrackets(string brackets)
            {
                bool need = true, solvable = true;
                int prevLength = brackets.Length;
                while (need)
                {
                    brackets = brackets.Replace("()", "");
                    brackets = brackets.Replace("[]", "");
                    brackets = brackets.Replace("()", "");
                    brackets = brackets.Replace("[]", "");
                    if (brackets.Length == 0) need = false;
                    else if (brackets.Length == prevLength)
                    {
                        solvable = false;
                        need = false;
                    }
                    prevLength = brackets.Length;
                }
                return solvable;
            }
        }
    }
}
