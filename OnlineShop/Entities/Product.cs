using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Text;

namespace OnlineShop.Entities
{
    internal class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt {  get; set; }
        public bool IsActive { get; set; }



        public ICollection<OrderItem> OrderItems { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; } = null!;
        public ICollection<ProductTag> ProductTags { get; set; } = null!;
    }
}
