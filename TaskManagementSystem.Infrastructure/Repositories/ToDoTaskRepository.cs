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
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoTask>> All()
        {
            var toDoTask = await _context.ToDoTasks
                                         .Include(x => x.Department)
                                         .Include(x => x.CreatorUser)
                                         .Include(x => x.AssignedUser)
                                         .ToListAsync();
            return toDoTask;
        }

        public async Task<ToDoTask> Create(ToDoTask toDoTask)
        {
            _context.ToDoTasks.Add(toDoTask);
            await _context.SaveChangesAsync();

            return toDoTask;
        }

        public async Task<ToDoTask> Delete(ToDoTask toDoTask)
        {
            var deletedTask = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == toDoTask.Id);

            _context.ToDoTasks.Remove(deletedTask);
            await _context.SaveChangesAsync();

            return deletedTask;
        }

        public async Task<ToDoTask> GetById(Guid id)
        {
            var toDoTask = await _context.ToDoTasks
                                   .Include(x => x.Department)
                                   .Include(x => x.CreatorUser)
                                   .Include(x => x.AssignedUser)
                                   .FirstOrDefaultAsync(x => x.Id == id);
            return toDoTask;
        }

        public async Task<ToDoTask> Update(ToDoTask toDoTask)
        {
            var updatedUser = _context.ToDoTasks.FirstOrDefault(x => x.Id == toDoTask.Id);

            _context.ToDoTasks.Update(updatedUser);
            await _context.SaveChangesAsync();

            return updatedUser;
        }
    }
}
