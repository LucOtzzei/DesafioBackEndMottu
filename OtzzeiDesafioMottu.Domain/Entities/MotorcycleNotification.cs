using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Entities
{
    public class MotorcycleNotification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid MotoId { get; set; }
        public string Placa { get; set; } = default!;
        public int Ano { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    }
}
