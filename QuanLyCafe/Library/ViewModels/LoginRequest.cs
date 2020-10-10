using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class LoginRequest
    {
        public string User { set; get; }
        public string PassWord { set; get; }
        public bool RememberMe{ set; get; }
    }
}
