using BankMainServer1.Data;

namespace BankMainServer1.Services
{
    internal interface ICustomerService
    {
        Customer GetCustomer(string nic);
    }
}
