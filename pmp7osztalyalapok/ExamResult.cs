using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmp7TulajdonsagosKapcsolatos
{
    internal class ExamResult
    {
        string neptun_code;
        public string Neptun_code
        {
            get { return neptun_code; }
            set
            {
                if (value.Length == 6) neptun_code = value;
            }
        }
        int score;

        public int Score
        {
            get { return score; }
            set
            {
                if (value <=100 && value >=0) score = value;
            }
        }

        public ExamResult(string nc, int scr)
        {
            Neptun_code=nc;
            Score = scr;
        }
        public ExamResult()
        {
            Random r = new Random();
            Score = r.Next(101);
            string nc = "";
            do
            {
                if (r.Next(2) == 1)
                    nc += r.Next(10);
                else
                {
                    nc += (char)r.Next(65, 91);
                }
            } while (nc.Length != 6);
            Neptun_code = nc;
        }

        public bool Passed
        {
            get
            {
                return score >= 50;
            }
        }

        public grade Grade(int[] boundaries)
        {
            for (int i = 0; i < boundaries.Length; i++)
            {
                if (score >= boundaries[i])
                {
                    return (grade)i;
                }
            }
            return grade.Elégtelen;
        }
    }
    enum grade { Jeles, Jó, Közepes, Elégséges, Elégtelen};
}
