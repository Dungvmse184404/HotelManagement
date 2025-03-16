using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IAdminAccountService
    {
        AdminAccount GetAdminAccount();
        bool ValidateAccount(string email, string password);
    }
}
