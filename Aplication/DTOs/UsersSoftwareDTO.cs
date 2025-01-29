using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    internal class UsersSoftwareDTO
    {
        public int Id { get; set; } 
        public int IdUser { get; set; } 
        public int IdSoftware { get; set; } 
        public string Role { get; set; }

    }
}
