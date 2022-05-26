using System;
using System.Collections.Generic;

namespace LocalVendorAppDAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Shopdetails = new HashSet<Shopdetail>();
        }

        public byte Categoryid { get; set; }
        public string? Categoryname { get; set; }

        public virtual ICollection<Shopdetail> Shopdetails { get; set; }
    }
}
