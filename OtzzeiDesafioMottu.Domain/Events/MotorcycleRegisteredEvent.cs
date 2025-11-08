using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Events
{
    public class MotorcycleRegisteredEvent
    {
        public Guid MotoId { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; } = default!;
        public string Placa { get; set; } = default!;
    }
}
