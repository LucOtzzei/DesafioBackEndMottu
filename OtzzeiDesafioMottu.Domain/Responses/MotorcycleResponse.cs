using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Responses
{
    public class MotorcycleResponse
    {
        [Required] public int Ano { get; set; }
        [Required] public required string Modelo { get; set; }
        [Required] public required string Placa { get; set; }
    }
}
