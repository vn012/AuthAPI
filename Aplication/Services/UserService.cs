using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DTOs;
using Aplication.Interfaces;
using Domain.Interfaces;
using Domain.Entities;

namespace Aplication.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IMapper _mapper;


        public UserService(
            IUserRepository userRepository
            ) {
            _userRepository = userRepository;
        }

        public async Task AddUser(UserDTO user)
        {
            var userRequest = new TbUser()
            {
                Name = user.Name,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username
            };

            await _userRepository.Create(userRequest);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var userListRes = await _userRepository.GetAll();

            foreach(var item in userListRes)
            {
                var user = new UserDTO()
                {
                    Username = item.Username,
                    Password = item.Password,
                };
            }
            
            var userList = new List<UserDTO>();

            return userList;
        }
    }
}
