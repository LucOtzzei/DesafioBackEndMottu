using OtzzeiDesafioMottu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OtzzeiDesafioMottu.Domain.Entities
{
    public class DeliveryMan
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Cnpj { get; private set; } = null!;
        public DateTime BirthDate { get; private set; }
        public string CnhNumber { get; private set; } = null!;
        public CNHTypeEnum CnhType { get; private set; }
        public string? CnhImagePath { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; } = DateTime.UtcNow;

        public DeliveryMan(string name, string cnpj, DateTime birthDate, string cnhNumber, CNHTypeEnum cnhType)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cnpj = cnpj;
            BirthDate = birthDate;
            CnhNumber = cnhNumber;
            CnhType = cnhType;
        }
        public void UpdateCnhImage(string cnhImagePath)
        {
            CnhImagePath = cnhImagePath;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
