using DAL.Enities;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void DeleteCustomer(Customer customer) => CustomerDAO.DeleteCustomer(customer);
        public List<Customer> GetCustomer() => CustomerDAO.GetCustomer();

        public Customer GetCustomerByEmail(string email) => CustomerDAO.GetCustomerByEmail(email);

        public Customer GetCustomerById(int customerID) => CustomerDAO.GetCustomerById(customerID);
        public void SaveCustomer(Customer customer) => CustomerDAO.SaveCustomer(customer);

        public void UpdateCustomer(Customer customer)
        {
            var cus = CustomerDAO.GetCustomerById(customer.CustomerId);
            if (cus != null)
            {
                cus.CustomerFullName = !string.IsNullOrWhiteSpace(customer?.CustomerFullName) ? customer.CustomerFullName : cus.CustomerFullName;
                cus.Telephone = !string.IsNullOrWhiteSpace(customer?.Telephone) ? customer.Telephone : cus.Telephone;
                cus.EmailAddress = !string.IsNullOrWhiteSpace(customer?.EmailAddress) ? customer.EmailAddress : cus.EmailAddress;
                cus.CustomerBirthday = customer?.CustomerBirthday ?? cus.CustomerBirthday;
                cus.CustomerStatus = customer?.CustomerStatus ?? cus.CustomerStatus;
                cus.Password = !string.IsNullOrWhiteSpace(customer?.Password) ? customer.Password : cus.Password;

                CustomerDAO.UpdateCustomer(cus);
            }
        }

        public List<Customer> SearchCustomers(string name, byte status)
            => CustomerDAO.GetCustomer()
                          .Where(c => (c.CustomerFullName ?? "").ToLower().Contains(name.ToLower())
                             && c.CustomerStatus.HasValue
                             && c.CustomerStatus.Value == status)
                          .ToList();


    }
}
