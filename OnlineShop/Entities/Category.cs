using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShop.Entities
{
    internal class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description {  get; set; } = null!;


        public ICollection<Product> Products { get; set; } = null!;
    }
}
