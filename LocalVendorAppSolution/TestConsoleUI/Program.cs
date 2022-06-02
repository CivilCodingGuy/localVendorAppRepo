// See https://aka.ms/new-console-template for more information


using LocalVendorAppDAL;

LocalVendorRepository repository = new LocalVendorRepository();
var  customerDetails= repository.GetCustomerDetails();
foreach (var item in customerDetails)
{
    Console.WriteLine(item.Customerid);
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Emailid);
    Console.WriteLine(item.Mobilenumber);

}
