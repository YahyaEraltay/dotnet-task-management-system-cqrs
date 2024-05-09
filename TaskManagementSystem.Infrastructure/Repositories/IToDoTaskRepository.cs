using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IToDoTaskRepository
    {
        Task<ToDoTask> Create(ToDoTask toDoTask);
        Task<ToDoTask> Update(ToDoTask toDoTask);
        Task<ToDoTask> Delete(ToDoTask toDoTask);
        Task<ToDoTask> GetById(Guid id);
        Task<List<ToDoTask>> All();
        Task<List<ToDoTask>> AssignedToDoTask(Guid id);
        Task<ToDoTask> UpdateStatus(ToDoTask toDoTask);
        Task<Guid> CreatorUser(Guid id);
        Task<Guid> AssignedUser(Guid id);
    }
}
