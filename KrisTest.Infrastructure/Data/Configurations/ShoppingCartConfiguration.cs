using KrisTest.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Infrastructure.Data.Configurations
{
    internal class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasMany(sc => sc.LineItems)
                .WithOne(li => li.ShoppingCart)
                .IsRequired();

            builder.HasOne(sc => sc.WebUser).WithOne(wu => wu.ShoppingCart).HasForeignKey<WebUser>(wu => wu.Id);
        }
    }
}
