using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pmp11zh2gyak
{
    internal class Dataset
    {
        private List<User> users;
        public Dataset(string fileName)
        {
            users = new List<User>();
            string[] rows = File.ReadAllLines(fileName);
            foreach (string row in rows.Skip(1))
            {
                string[] parts = row.Split(';');
                users.Add(new User(int.Parse(parts[0]), parts[1], int.Parse(parts[2]), DateTime.Parse(parts[3]), DateTime.Parse(parts[4]), parts[5], int.Parse(parts[6]), parts[7]));
            }
        }
        public int UserCount { get => users.Count; }

        public double AverageMonthlyRevenue(SubscriptionType type)
        {
            double sum = 0;
            foreach (User user in users)
                if (user.SubType == type) sum += user.SubCost;
            return sum / UserCount;
        }

        public User[] CollectNonPayers(int days)
        {
            List<User> users = new List<User>();
            foreach (User user in users)
                if (user.DaysSinceLastPayment() >= days) users.Add(user);
            return users.ToArray();
        }
        public string MaximalAgeData()
        {
            int maxIndex = 0;
            for (int i = 0; i < UserCount; i++)
                if (users[i].Age > users[maxIndex].Age) maxIndex = i;
            return users[maxIndex].DataAsText();
        }
        /*public string DistributionOfDeviceType(DeviceType type)
        {
            Dictionary<CountryName,int> stats = new Dictionary<CountryName, int>();
            int sum = 0;
            foreach (CountryName country in Enum.GetValues(typeof(CountryName)))
            {
                stats.Add(country, 0);
                foreach (User user in users)
                {
                    if (user.DeviceType == type)
                    {
                        stats[country]++;
                        sum++;
                    }
                }
            }
            string final = "-- Distribution of Smartphone --\n";
            foreach (var stat in stats.Keys)
            {
                final+= $"{stats}: {stats[stat]}"
            }

        }*/
    }
}
