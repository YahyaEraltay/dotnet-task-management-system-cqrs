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

        public async Task<List<ToDoTask>> AssignedToDoTask(Guid id)
        {
            var assignedTasks = await _context.ToDoTasks
                                              .Include(x => x.Department)
                                              .Include(x => x.CreatorUser)
                                              .Include(x => x.AssignedUser)
                                              .Where(x => x.AssignedUserId == id)
                                              .ToListAsync();
            return assignedTasks;
        }

        public async Task<Guid> AssignedUser(Guid id)
        {
            var user = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == id);
            var assignedUser = user.AssignedUserId;

            return assignedUser;
        }

        public async Task<ToDoTask> Create(ToDoTask toDoTask)
        {
            _context.ToDoTasks.Add(toDoTask);
            await _context.SaveChangesAsync();

            return toDoTask;
        }

        public async Task<Guid> CreatorUser(Guid id)
        {
            var task = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == id);
            var creatorUser = task.CreatorUserId;

            return creatorUser;
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
            if (toDoTask != null)
            {
                return toDoTask;
            }
            else
            {
                throw new Exception("To do task no found");
            }
        }

        public async Task<ToDoTask> Update(ToDoTask toDoTask)
        {
            var updatedToDoTask = _context.ToDoTasks.FirstOrDefault(x => x.Id == toDoTask.Id);

            _context.ToDoTasks.Update(updatedToDoTask);
            await _context.SaveChangesAsync();

            return updatedToDoTask;
        }

        public async Task<ToDoTask> UpdateStatus(ToDoTask toDoTask)
        {
            var statusToDoTask = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == toDoTask.Id);

            if (statusToDoTask != null)
            {
                statusToDoTask.Status = toDoTask.Status;

                _context.ToDoTasks.Update(statusToDoTask);
                await _context.SaveChangesAsync();

                return statusToDoTask;
            }
            else
            {
                throw new Exception("To do task not found");
            }
        }
    }
}
