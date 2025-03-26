using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
        Customer GetCustomerById(int customerID);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        //-------------function--------------
        public Customer? LoginCustomer(string key, string password);
        public List<Customer> SearchCustomer(string  name, byte status);

    }
}
