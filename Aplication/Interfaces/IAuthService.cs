using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IAuthService
    {
        Task<TbUser> Authenticate(string email, string password);
        Task<bool> Authenticate2(string email, string password);

        Task<TbUser> Register(TbUser user);

    }
}
