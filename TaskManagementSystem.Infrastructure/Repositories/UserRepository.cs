using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.RelationalDb;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> All()
        {
            var users = await _context.Users
                                      .Include(x => x.Department)
                                      .ToListAsync();

            if (users != null)
            {
                return users;
            }
            else
            {
                throw new Exception("There is no user");
            }
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Delete(User user)
        {
            var deletedUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            _context.Users.Remove(deletedUser);
            await _context.SaveChangesAsync();

            return deletedUser;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await _context.Users
                                     .Include(x => x.Department)
                                     .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User> Update(User user)
        {
            var updatedUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            _context.Users.Update(updatedUser);
            await _context.SaveChangesAsync();

            return updatedUser;
        }
    }
}
