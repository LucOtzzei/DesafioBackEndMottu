using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Requests
{
    public class CreateDeliveryManRequest
    {
        [Required]
        public string Identifier { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(14, MinimumLength = 14)]
        public string Cnpj { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string CnhNumber { get; set; } = null!;

        [Required]
        public CNHType CnhType { get; set; }
    }
}
