using System;
using System.Collections.Generic;

namespace LocalVendorAppDAL.Models
{
    public partial class Sellerdetail
    {
        public string? Name { get; set; }
        public long? Mobilenumber { get; set; }
        public string? Emailid { get; set; }
        public int? Shopid { get; set; }
        public string? Password { get; set; }

        public virtual Shopdetail? Shop { get; set; }
    }
}
