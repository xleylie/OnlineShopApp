using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShop.Entities
{
    internal class Address
    {
        [Key]
        public int Id { get; set; }

        public string Country { get; set; } = null!;
        public string City {get;set ; } = null!;
        public string Street { get; set; } = null!;

        public string House { get; set; } = null!;
        public string Apartment { get; set; } = null!;
        public string PostalCode { get; set; } = null!;


        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
