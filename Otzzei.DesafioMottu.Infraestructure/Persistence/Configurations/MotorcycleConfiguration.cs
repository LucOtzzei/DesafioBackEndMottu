using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtzzeiDesafioMottu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.DesafioMottu.Infraestructure.Persistence.Configurations
{
    public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("Motorcycles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Modelo)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Placa)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasIndex(x => x.Placa)
                   .IsUnique();
        }
    }
}
