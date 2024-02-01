using Elegencia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Configurations
{
    internal class ChefConfiguration : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Info).HasColumnType("text").IsRequired();
        }
    }
}
