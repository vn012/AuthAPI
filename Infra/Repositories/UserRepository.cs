using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<TbUser> Create(TbUser user)
        {
            var res = _context.TbUser.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public Task<TbUser> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TbUser>> GetAll()
        {
            var res = _context.TbUser.ToListAsync();

            return res;
        }

        public Task<TbUser> GetByEmail(string email)
        {
            var res = _context.TbUser.FirstOrDefaultAsync(x => x.Email == email);

            return res;
        }     
        
        public Task<TbUser> GetByUsername(string username)
        {
            var res = _context.TbUser.FirstOrDefaultAsync(x => x.Username == username);

            return res;
        } 

        public Task<TbUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TbUser> Update(TbUser user)
        {
            throw new NotImplementedException();
        }
    }
}
