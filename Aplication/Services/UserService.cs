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
            //string hashSenha = PasswordHelper.HashPassword(senha);

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
            var userList = new List<UserDTO>();

            foreach (var item in userListRes)
            {
                var user = new UserDTO()
                {
                    Id = item.Id,
                    Username = item.Username,
                    Password = item.Password,
                    Email = item.Email,
                    Name = item.Name,
                    Lastname = item.Lastname,
                };

                userList.Add(user);
            }

            return userList;
        }

        public async Task<UserDTO> GetByUser(string username)
        {
            var usuario = await _userRepository.GetByUsername(username);

            if (usuario == null)
                throw new InvalidOperationException($"O usuario não foi encontrado");

            var user = new UserDTO()
            {
                Username = usuario.Username,
                Password = usuario.Password,
                Email = usuario.Email,
                Name = usuario.Name,
                Lastname = usuario.Lastname,
            };

            return user;
        }


    }
}
