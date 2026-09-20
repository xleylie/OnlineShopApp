using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    internal enum OrderStatus
    {
        Pending,
        Paid,
        Shipped,
        Delivered,
        Cancelled
    }
}
