﻿using AuditManagementPortalClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Services
{
    public interface IUserService
    {
        public bool CheckUser(User user);
    }
}
