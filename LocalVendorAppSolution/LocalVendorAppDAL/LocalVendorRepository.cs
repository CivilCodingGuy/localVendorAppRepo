using LocalVendorAppDAL.Models;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public int AddSellerUsingUSP(string name,long mobileNumber, string emailId,int shopId, string password )
        {
            int result=-1;
            try
            {
                SqlParameter prmName = new SqlParameter("@prmName", name);
                SqlParameter prmMobileNumber = new SqlParameter("@prmMobileNumber", mobileNumber);
                SqlParameter prmemailId = new SqlParameter("@email", emailId);
                SqlParameter prmShopId = new SqlParameter("@id", shopId);
                SqlParameter prmPassword = new SqlParameter("@password", password);
                 result = demoAppContext.Database.ExecuteSqlCommand("EXEC dbo.ADDSELLER @prmName,@prmMobileNumber, @email,@id,@password" +
                    new[] {prmName,prmMobileNumber,prmemailId, prmShopId, prmPassword});    

                
                             }
            catch (Exception)
            {

                throw;
            }
            return result;
        }



    }
}
