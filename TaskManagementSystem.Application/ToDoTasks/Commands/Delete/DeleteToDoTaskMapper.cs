using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.ToDoTasks.Commands.Create;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Delete
{
    public class DeleteToDoTaskMapper
    {
        public static ToDoTask MapToEntity(ToDoTask task)
        {
            return new ToDoTask
            {
                Id = task.Id
            };
        }

        public static DeleteToDoTaskResponse MapToResponse(bool isDeleted, string message)
        {
            return new DeleteToDoTaskResponse
            {
                IsDeleted = isDeleted,
                Message = message
            };
        }
    }
}
