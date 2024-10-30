namespace pmp7TulajdonsagosKapcsolatos
{
    internal class Program
    {
        public static void MoleGame()
        {
            Mole mole = new Mole();
            int guess = 0;
            do
            {
                mole.Hide(1, 5);
                guess = int.Parse(Console.ReadLine());
                mole.TurnUp();
            } while (guess != mole.Position);
            Console.WriteLine("Eltaláltad!");
        }
        public static void FlightSim()
        {
            GroundControl groundControl = new GroundControl();
            Flight a = new Flight("A","Budapest", DateTime.Now.AddDays(-1));
            Flight b = new Flight("B","Budapest", DateTime.Now.AddDays(-1));
            Flight c = new Flight("C","Budapest", DateTime.Now.AddDays(-1), 10);
            Flight d = new Flight("D","Budapest", DateTime.Now.AddDays(-1),20);
            groundControl.AddFlight(a);
            groundControl.AddFlight(b);
            groundControl.AddFlight(c);
            groundControl.AddFlight(d);
            groundControl.DisplayAllData();
        }
        public static void Exam()
        {

        }
        static void Main(string[] args)
        {
            //1.Feladat:
            //MoleGame();
            //2.Feladat:
            //FlightSim();
            //3.Feladat:
            Exam();
        }
    }
}
