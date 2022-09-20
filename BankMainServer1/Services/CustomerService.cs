using BankMainServer1.Data;

namespace BankMainServer1.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly HttpClient http;
        private string ba = "";
        private string parth = "api/Customer/";

        public CustomerService(HttpClient _http)
        {
            http = _http;
        }

        Customer ICustomerService.GetCustomer(string nic)
        {
            Customer customer = new Customer();
            return customer;
        }
    }
}
