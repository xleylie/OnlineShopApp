using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity
                .HasMany(o => o.OrderItems)
                .WithOne(or => or.Order)
                .HasForeignKey(or => or.OrderId);

            entity.Property(x => x.UserId).IsRequired();

            entity.Property(x => x.OrderDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

            entity.Property(x => x.Status)
            .IsRequired()
            .HasMaxLength(30);

            entity.Property(x => x.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

            entity.ToTable(x => x.HasCheckConstraint(
                "CK_Order_TotalAmount",
                "TotalAmount > 0"));

            entity.Property(o => o.Status)
                .HasConversion<int>();
        }
    }
}
