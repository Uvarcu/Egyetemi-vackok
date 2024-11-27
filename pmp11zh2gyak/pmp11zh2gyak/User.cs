using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmp11zh2gyak
{
    internal class User
    {
        int id;
        SubscriptionType subType;
        int subCost;
        DateTime join;
        DateTime lastPayment;
        CountryName countryName;
        int age;
        DeviceType deviceType;

        public User(int id, string subType, int subCost, DateTime join, DateTime lastPayment, string countryName, int age, string deviceType)
        {
            this.id = id;
            this.subType = Enum.Parse<SubscriptionType>(subType);
            this.subCost = subCost;
            this.join = join;
            this.lastPayment = lastPayment;
            this.countryName = Enum.Parse<CountryName>(countryName);
            this.age = age;
            this.deviceType = Enum.Parse<DeviceType>(deviceType);
        }

        public int Id { get => id; }
        public SubscriptionType SubType { get => subType; }
        public int SubCost { get => subCost; }
        public DateTime Join { get => join; }
        public DateTime LastPayment { get => lastPayment; }
        public CountryName CountryName { get => countryName; }
        public int Age { get => age; }
        public DeviceType DeviceType { get => deviceType; }

        public int SubscriptionDays()
        {
            return DateTime.Now.Subtract(join).Days;
        }

        public int DaysSinceLastPayment()
        {
            return DateTime.Now.Subtract(lastPayment).Days;
        }

        public string DataAsText()
        {
            return $"User ID: {id} ({countryName}, {subType}, {deviceType}). Subscription: {SubscriptionDays()} Days, last payment: {DaysSinceLastPayment()} days.";
        }
    }
}
