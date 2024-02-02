using Elegencia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Configurations
{
    public class SaladConfiguration : IEntityTypeConfiguration<Salad>
    {
        public void Configure(EntityTypeBuilder<Salad> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Ingredients).HasColumnType("text").IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(6,2)").IsRequired();
        }
    }
}
