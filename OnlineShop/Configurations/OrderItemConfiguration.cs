using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity.HasKey(oi => new { oi.OrderId, oi.ProductId });

            entity.Property(x => x.OrderId).IsRequired();

            entity.Property(x => x.ProductId).IsRequired();

            entity.Property(x => x.Quantity)
            .IsRequired();

            entity.ToTable(x => x.HasCheckConstraint(
                "CK_Product_Quantity",
                "Quantity > 0"));

            entity.Property(x => x.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

            entity.ToTable(x => x.HasCheckConstraint(
                "CK_Product_UnitPrice",
                "UnitPrice > 0"));
        }
    }
}
