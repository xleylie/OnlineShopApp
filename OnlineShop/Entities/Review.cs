using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShop.Entities
{
    internal class Review
    {
        [Key]
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
