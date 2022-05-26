using System;
using System.Collections.Generic;

namespace LocalVendorAppDAL.Models
{
    public partial class Customer
    {
        public int Customerid { get; set; }
        public string? Name { get; set; }
        public long? Mobilenumber { get; set; }
        public string? Emailid { get; set; }
        public string? Password { get; set; }
    }
}
