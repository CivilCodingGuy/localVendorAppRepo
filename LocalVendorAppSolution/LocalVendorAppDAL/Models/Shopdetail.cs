using System;
using System.Collections.Generic;

namespace LocalVendorAppDAL.Models
{
    public partial class Shopdetail
    {
        public int ShopId { get; set; }
        public string? ShopName { get; set; }
        public string? Address { get; set; }
        public byte? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
