using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Requests
{
    public class CreateRentalRequest
    {
        public Guid MotorcycleId { get; set; }
        public Guid DeliverymanId { get; set; }
        public int PlanDays { get; set; }
    }
}