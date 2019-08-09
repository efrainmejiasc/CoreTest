using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Models.System
{
    public class Client
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}
