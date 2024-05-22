using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Create
{
    public class CreateToDoTaskMapper
    {
        public static ToDoTask MapToEntity(CreateToDoTaskRequest request, Guid currentUserId, Guid currentDepartmentId)
        {
            return new ToDoTask
            {
                ToDoTaskName = request.ToDoTaskName,
                ToDoTaskDescription = request.ToDoTaskDescription,
                ToDoTaskDate = DateTime.Now.Date,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = currentUserId,
                DepartmentId = currentDepartmentId,
                Status = request.Status = 0
            };
        }

        public static CreateToDoTaskResponse MapToResponse(ToDoTask task)
        {
            return new CreateToDoTaskResponse
            {
                Id = task.Id,
                ToDoTaskName = task.ToDoTaskName,
                ToDoTaskDescription = task.ToDoTaskDescription,
                ToDoTaskDate = task.ToDoTaskDate.Date,
                AssignedUserId = task.AssignedUserId,
                CreatorUserId = task.CreatorUserId,
                DepartmentId = task.DepartmentId,
                Status = task.Status
            };
        }
    }
}
