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
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(25).IsRequired();
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.HasIndex(x=>x.Email).IsUnique();
        }
    }
}
