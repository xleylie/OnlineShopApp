using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    internal class ProductTag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;


        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
