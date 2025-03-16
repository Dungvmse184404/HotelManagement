using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomer();
        Customer GetCustomerById(int customerID);
        Customer GetCustomerByEmail(string email);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        List<Customer> SearchCustomers(string name, byte status);
    }
}
