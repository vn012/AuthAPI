using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<TbUser>> GetAll();
        Task<TbUser> GetById(int id);
        Task<TbUser> GetByEmail(string email);
        Task<TbUser> GetByUsername(string username);
        Task<TbUser> Create(TbUser user);
        Task<TbUser> Update(TbUser user);
        Task<TbUser> Delete(int id);

        //Task<TbUser> Delete(TbUser user);
    }
}
