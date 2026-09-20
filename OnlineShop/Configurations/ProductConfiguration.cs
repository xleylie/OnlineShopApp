using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId);

            entity
                .HasMany(p => p.OrderItems)
                .WithOne(or => or.Product)
                .HasForeignKey(or => or.ProductId);

            entity.Property(x => x.CategoryId).IsRequired();

            entity.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

            entity.Property(x => x.Description)
            .HasMaxLength(1000);

            entity.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

            entity.ToTable(x => x.HasCheckConstraint(
                "CK_ProductPrice",
                "Price > 0"
            ));

            entity.Property(x => x.StockQuantity)
            .IsRequired();

            entity.ToTable(x => x.HasCheckConstraint(
                "CK_Product_StockQuantity",
                "StockQuantity >= 0"
            ));

            entity.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

            entity.Property(x => x.IsActive)
            .HasDefaultValue(true);

            entity.HasIndex(x => new { x.CategoryId, x.Name }).IsUnique();  //если продукт есть в категории, то зачем второй с таким же названием в одной категории.
            entity.HasIndex(x => x.Name);
        }
    }
}
