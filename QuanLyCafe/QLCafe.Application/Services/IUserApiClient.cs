using Library;
using QLCafe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.Application.Services
{
   public interface IUserApiClient
    {
        public Task<string> Authenticate(LoginRequest request);
    }
}
