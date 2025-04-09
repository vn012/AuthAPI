using Aplication.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IUserService
    {
        #region Get

        Task<IEnumerable<UserDTO>> GetAll();

        Task <UserDTO> GetByUser(string username);

        public string GetUsername()
        {
            return "username";
        }

        #endregion

    }
}
