using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Configurations
{
    internal class CouponConfiguration:IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> entity)
        { 
            entity.HasIndex(x => x.Code)
            .IsUnique();

            entity.ToTable(x => x.HasCheckConstraint(
                "CK_Coupon_DiscountPercentage",
                "DiscountPercentage >= 1 and DiscountPercentage <=100"));

            entity.Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}
