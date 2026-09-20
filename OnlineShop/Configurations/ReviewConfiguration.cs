using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Configurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> entity)
        {
            entity.ToTable(x => x.HasCheckConstraint(
                "CK_Review_Rating",
                "Rating >= 1 and Rating <=5 "));

            entity.Property(x => x.Comment)
            .HasMaxLength(1000);

            entity.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

            entity.HasIndex(x => new { x.UserId, x.ProductId })
                .IsUnique();

            entity.Property(x => x.Rating)
                .HasColumnType("decimal(18,2)");
        }
    }
}
