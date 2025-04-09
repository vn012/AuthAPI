using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IMapper _mapper;


        public AuthService(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Authenticate2(string email, string password)
        {

            var user = await _userRepository.GetByEmail(email);

            if (user == null)
                return false;

            if (user.Name == email && user.Password == password)
                return true;

            return false;

        }

        Task<TbUser> IAuthService.Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<TbUser> Register(TbUser user)
        {
            throw new NotImplementedException();
        }



    }
}
