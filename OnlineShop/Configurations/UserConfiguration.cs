using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace OnlineShop.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            entity
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);

            entity
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

            entity.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);

            entity.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(150);

            entity.Property(x => x.Phone)
            .HasMaxLength(20);

            entity.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

            entity.Property(x => x.IsActive)
            .HasDefaultValue(true);

            entity.HasIndex(x => x.Email)
            .IsUnique();
        }
    }
}
