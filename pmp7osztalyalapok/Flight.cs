using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmp7TulajdonsagosKapcsolatos
{
    enum status { Schedulded, Delayed, Canceled};
    internal class Flight
    {
        string id;
        string destination;
        DateTime departure;
        public int late;
        public status status;
        
        public Flight(string i, string des, DateTime dep, int l)
        {
            id = i;
            destination = des;
            departure = dep;
            late = l;
            UpdateStatus(l);
        }

        public Flight(string i, string des, DateTime dep) : this(i, des, dep, 0)
        { }

        public void Delay(int late)
        {
            this.late = late;
            UpdateStatus(status.Delayed);
        }

        public void Cancel()
        {
            UpdateStatus(status.Canceled);
        }

        private void UpdateStatus(status s)
        {
            status = s;
        }
        private void UpdateStatus(int late)
        {
            if (late == 0) UpdateStatus(status.Schedulded);
            else UpdateStatus(status.Delayed);
        }

        public string AllData()
        {
            string final = $"Flight {id} is ";
            if (status == status.Canceled)
            {
                final += "canceled";
                return final;
            }
            if (status == status.Schedulded) final += "on time. (STD ";
            else final += $"delayed by {late} minutes. (ETD ";
            final += EstimatedDeparture() + ")";
            return final;
        }
        public DateTime EstimatedDeparture()
        {
            return departure.AddMinutes(late);
        }
    }

    internal class GroundControl
    {
        DateTime time;
        List<Flight> flights;
        public GroundControl()
        {
            flights = new List<Flight>();
            time = DateTime.Now;
        }
        public void AddFlight(Flight f)
        {
            flights.Add(f);
        }
        private double AverageDelay()
        {
            double sum = 0;
            foreach (Flight f in flights)
                if (f.status != status.Canceled) sum += f.late;
            return sum / flights.Count;
        }
        public void DisplayAllData()
        {
            foreach (Flight f in flights)
                Console.WriteLine(f.AllData());
            Console.WriteLine("Average delay is: " + AverageDelay() + "minutes");
        }
    }
}
