using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities
{
    internal class Coupon
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Code { get; set; } = null!;
        [Required]
        public decimal DiscountPercent { get; set; }
        [Required]
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Order> Orders { get; set; } = null!;

    }
}
