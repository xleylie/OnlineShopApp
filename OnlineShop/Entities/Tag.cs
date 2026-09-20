using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShop.Entities
{
    internal class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<ProductTag> ProductTags { get; set; } = null!;
    }
}
