using OtzzeiDesafioMottu.Domain.Entities;
using OtzzeiDesafioMottu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Responses
{
    public class DeliveryManResponse
    {
        public string Name { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string CnhNumber { get; set; } = null!;
        public CNHTypeEnum CnhType { get; set; }
        public string? CnhImagePath { get; set; }

        public DeliveryManResponse(DeliveryMan deliveryMan)
        {
            Name = deliveryMan.Name;
            Cnpj = deliveryMan.Cnpj;
            BirthDate = deliveryMan.BirthDate;
            CnhNumber = deliveryMan.CnhNumber;
            CnhType = deliveryMan.CnhType;
        }
    }
}
