using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TbUser
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string Country { get; set; }

        public bool IsAdmin { get; set; } = false;

        public bool IsVerified { get; set; }
    }
}
