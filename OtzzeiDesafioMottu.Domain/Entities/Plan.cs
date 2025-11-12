using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Entities
{
    public class Plan
    {
        public int Days { get; private set; }
        public decimal DailyRate { get; private set; }
        public decimal? EarlyReturnPenalty { get; private set; }

        public Plan(int days, decimal dailyRate, decimal? earlyReturnPenalty = null)
        {
            Days = days;
            DailyRate = dailyRate;
            EarlyReturnPenalty = earlyReturnPenalty;
        }

        public static Plan Create7Days() => new(7, 30m, 0.20m);
        public static Plan Create15Days() => new(15, 28m, 0.40m);
        public static Plan Create30Days() => new(30, 22m);
        public static Plan Create45Days() => new(45, 20m);
        public static Plan Create50Days() => new(50, 18m);

        public static Plan FromDays(int days)
        {
            return days switch
            {
                7 => Create7Days(),
                15 => Create15Days(),
                30 => Create30Days(),
                45 => Create45Days(),
                50 => Create50Days(),
                _ => throw new ArgumentException("Invalid rental plan duration.")
            };
        }

        public override string ToString() => $"{Days} days - {DailyRate:C}/day";
    }
}