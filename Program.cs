namespace PMPHF011_HE53B7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wordCount = int.Parse(Console.ReadLine());
            string[] words = new string[wordCount];
            for (int i = 0; i < words.Length; i++)
                words[i] = Console.ReadLine();
            string originalWord = Console.ReadLine();
            List<List<int>> positionsOfMarks = new List<List<int>>();
            foreach (string word in words)
            {
                if (originalWord.Contains(word))
                    for (int i = 0; i < originalWord.Length; i++)
                        if (originalWord.Length - i >= word.Length && originalWord[i] == word[0] && originalWord.Substring(i,word.Length) == word)
                        {
                            List<int> marks = new List<int>();
                            for (int j = 0; j < word.Length; j++)
                                marks.Add(j+i);
                            positionsOfMarks.Add(marks);
                        }
                string reversedWord = "";
                for (int i = word.Length-1; i >= 0; i--)
                    reversedWord += word[i];
                if (originalWord.Contains(reversedWord))
                    for (int i = 0; i < originalWord.Length; i++)
                        if (originalWord.Length - i >= reversedWord.Length && originalWord[i] == reversedWord[0] && originalWord.Substring(i, reversedWord.Length) == reversedWord)
                        {
                            List<int> marks = new List<int>();
                            for (int j = 0; j < reversedWord.Length; j++)
                                marks.Add(j + i);
                            positionsOfMarks.Add(marks);
                        }
            }
            List<int> finalMarks = new List<int>();
            for (int i = 0; i < originalWord.Length; i++) finalMarks.Add(i);
            List<int> removeMarks = new List<int>();
            foreach (List<int> marks in positionsOfMarks)
                for (int i = 0; i < marks.Count; i++)
                    if (finalMarks.Contains(marks[i]) && !removeMarks.Contains(marks[i])) removeMarks.Add(marks[i]);
            foreach (int mark in removeMarks)
                finalMarks.Remove(mark);
            for (int i = 0; i < originalWord.Length; i++)
                if (finalMarks.Contains(i)) Console.Write(originalWord[i]);
        }
    }
}