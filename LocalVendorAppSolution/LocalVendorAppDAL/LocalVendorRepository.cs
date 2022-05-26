using LocalVendorAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalVendorAppDAL
{
    public class LocalVendorRepository
    {
        demoAppContext demoAppContext;
        public LocalVendorRepository()
        {
            demoAppContext = new demoAppContext();
        }
        public List<Customer> GetCustomerDetails()
        {
            var customerList = (from customer in demoAppContext.Customers
                                orderby customer.Name
                                select customer).ToList();

            return customerList;
        }

    }
}
