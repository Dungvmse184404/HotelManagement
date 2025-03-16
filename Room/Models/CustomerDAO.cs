using DAL;
using DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CustomerDAO
    {
        private static FuminiHotelManagementContext CreateContext() => new FuminiHotelManagementContext();
        public static List<Customer> GetCustomer()
        {
            var listCustomer = new List<Customer>();
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                listCustomer = dbContext.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCustomer;
        }


        public static Customer GetCustomerById(int customerID)
        {
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                return dbContext.Customers.FirstOrDefault(c => c.CustomerId.Equals(customerID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Customer GetCustomerByEmail(string email)
        {
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                return dbContext.Customers.FirstOrDefault(c => c.EmailAddress.ToLower() == email.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void SaveCustomer(Customer customer)
        {
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<Customer>(customer).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var delCustomer =
                    context.Customers.SingleOrDefault(c => c.CustomerId == customer.CustomerId);
                context.Customers.Remove(delCustomer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
