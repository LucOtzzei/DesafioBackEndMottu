using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Entities
{
    public class Rental
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid MotorcycleId { get; private set; }
        public Guid DeliverymanId { get; private set; }
        public Plan? Plan { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime ExpectedEndDate { get; private set; }
        public DateTime? ActualEndDate { get; private set; }
        public decimal? TotalValue { get; private set; }

        public Rental() { }
        public Rental(Guid motorcycleId, Guid deliverymanId, Plan plan)
        {
            MotorcycleId = motorcycleId;
            DeliverymanId = deliverymanId;
            Plan = plan ?? throw new ArgumentNullException(nameof(plan));

            StartDate = DateTime.UtcNow.AddDays(1);
            ExpectedEndDate = StartDate.AddDays(plan.Days);
        }

        public void FinishRental(DateTime returnDate)
        {
            ActualEndDate = returnDate;
            TotalValue = CalculateTotalValue(returnDate);
        }

        private decimal CalculateTotalValue(DateTime returnDate)
        {
            int usedDays = (returnDate - StartDate).Days;
            if (usedDays < 0) usedDays = 0;

            if (returnDate < ExpectedEndDate)
            {
                int unusedDays = (ExpectedEndDate - returnDate).Days;
                decimal dailyTotal = usedDays * Plan.DailyRate;
                decimal unusedTotal = unusedDays * Plan.DailyRate;

                if (Plan.EarlyReturnPenalty.HasValue)
                {
                    decimal penaltyRate = Plan.EarlyReturnPenalty.Value;
                    return dailyTotal + (unusedTotal * penaltyRate);
                }

                return dailyTotal;
            }
            else if (returnDate > ExpectedEndDate)
            {
                int extraDays = (returnDate - ExpectedEndDate).Days;
                decimal baseTotal = Plan.Days * Plan.DailyRate;
                return baseTotal + (extraDays * 50m);
            }

            return Plan.Days * Plan.DailyRate;
        }
    }
}