using DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Services.Services
{
    

    public class AdminAccountService : IAdminAccountService
    {
        private readonly AdminAccount _adminAccount;

        public AdminAccountService()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            _adminAccount = config.GetSection("AdminAccount").Get<AdminAccount>();
        }

        public AdminAccount GetAdminAccount()
        {
            return _adminAccount;
        }

        public bool ValidateAccount(string email, string password)
        {
            return email.ToLower().Equals(_adminAccount.Email.ToLower()) && password == _adminAccount.Password;
        }
    }

}
