using AuditManagementPortalClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public class UserRepo : IUserRepo
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
            new User{Name = "Admin", Password ="Admin123" },
            new User{Name = "Rohit", Password ="Rohit123" },
            new User{Name = "Anmol", Password ="Anmol123" },
            new User{Name = "Arnav", Password ="Arnav123" },
            new User{Name = "Shardul", Password ="Shardul123" }
            };
            return users;
        }
    }
}
