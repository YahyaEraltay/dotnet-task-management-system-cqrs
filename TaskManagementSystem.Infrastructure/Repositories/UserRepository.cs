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

            return users;
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

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<string> GetUserByEmail(string email)
        {
            var userEmail = await _context.Users.FirstOrDefaultAsync(x => x.UserEmail == email);

            if (userEmail != null)
            {
                var userPassword = userEmail.UserPassword;
                return userPassword;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users
                                     .Include(x => x.Department)
                                     .Include(x => x.ToDoTasks)
                                     .FirstOrDefaultAsync(x => x.UserEmail == email && x.UserPassword == password);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("Invalid email or password");
            }
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
