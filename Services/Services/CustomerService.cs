using DAL.Enities;
using Repositories.IRepositories;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public void DeleteCustomer(Customer customer)
            => _customerRepository.DeleteCustomer(customer);

        public List<Customer> GetAllCustomer()
            => _customerRepository.GetCustomer();

        public Customer GetCustomerById(int customerID)
            => _customerRepository.GetCustomerById(customerID);

        public void SaveCustomer(Customer customer)
        {
            customer = ValidateCustomer(customer);
            _customerRepository.SaveCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            //customer = ValidateCustomer(customer);
            _customerRepository.UpdateCustomer(customer);
        }

        public Customer? LoginCustomer(string key, string password)
        {
            return _customerRepository.GetCustomer().FirstOrDefault(c =>
                (c.EmailAddress == key || c.Telephone == key) && c.Password == password);
        }



        public Customer ValidateCustomer(Customer customer)
        {
            var customerList = _customerRepository.GetCustomer();
            if (customer == null)
                throw new ArgumentNullException(nameof(customer), "Khách hàng không được null.");

            if (string.IsNullOrWhiteSpace(customer.CustomerFullName))
                throw new ArgumentException("Tên khách hàng không được để trống.");

            if (string.IsNullOrWhiteSpace(customer.EmailAddress))
                throw new ArgumentException("Email không được để trống.");

            if (!Regex.IsMatch(customer.EmailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email không hợp lệ.");
            var existingCustomer = _customerRepository.GetCustomerByEmail(customer.EmailAddress);
            if (existingCustomer != null && existingCustomer.CustomerId != customer.CustomerId)
                throw new ArgumentException("Email đã tồn tại trong hệ thống.");

            if (!string.IsNullOrWhiteSpace(customer.Telephone) && !Regex.IsMatch(customer.Telephone, @"^\d{10,12}$"))
                throw new ArgumentException("Số điện thoại phải có 10-12 chữ số.");
            foreach (var c in customerList)
                if (c.Telephone == customer.Telephone && c.CustomerId != customer.CustomerId)
                    throw new ArgumentException("Số điện thoại đã tồn tại trong hệ thống.");
            
            var today = DateOnly.FromDateTime(DateTime.Today);
            if (customer.CustomerBirthday > today)
                throw new ArgumentException("Ngày sinh không hợp lệ.");

            return customer;
        }

        public List<Customer> SearchCustomer(string name, byte status)
        {
            var CustomerList = _customerRepository.GetCustomer();
           return string.IsNullOrWhiteSpace(name) ? CustomerList.Where(c => c.CustomerStatus == status).ToList() : CustomerList.Where(c => c.CustomerFullName.ToLower().Contains(name.ToLower()) && c.CustomerStatus == status).ToList();
        }

        public void ChangePassword(int customerId, string password)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            customer.Password = password;
            _customerRepository.UpdateCustomer(customer);
        }

        public void DisableCustomer(Customer customer)
        {
            customer.CustomerStatus = 0;
            UpdateCustomer(customer);
        }
    }
}
