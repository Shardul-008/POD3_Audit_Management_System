using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Service
{
    public interface IAuthService
    {
        public string GetJsonWebToken();
    }
}
