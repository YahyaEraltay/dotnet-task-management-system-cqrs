using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Update
{
    public class UpdateToDoTaskMapper
    {
        public static ToDoTask MapToEntity(ToDoTask task, UpdateToDoTaskRequest request)
        {
            task.Id = request.Id;
            task.ToDoTaskName = request.ToDoTaskName;
            task.AssignedUserId = request.AssignedUserId;
            task.ToDoTaskDescription = request.ToDoTaskDescription;

            return task;
        }
        
        public static UpdateToDoTaskResponse MapToResponse(ToDoTask task)
        {
            return new UpdateToDoTaskResponse
            {
                Id = task.Id,
                ToDoTaskName = task.ToDoTaskName,
                AssignedUserName = task.AssignedUser.UserName,
                CreatorUserName = task.CreatorUser.UserName,
                AssignedDepartmentName = task.Department.DepartmentName,
                ToDoTaskDescription = task.ToDoTaskDescription,
            };
        }
    }
}
