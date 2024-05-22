using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.ToDoTasks.Commands.Create;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Status
{
    public class StatusToDoTaskMapper
    {
        public static ToDoTask MapToEntity(ToDoTask task, StatusToDoTaskRequest request)
        {
            task.Status = request.Status;

            return task;
        }

        public static StatusToDoTaskResponse MapToResponse(ToDoTask task)
        {
            return new StatusToDoTaskResponse
            {
                Status = task.Status,
            };
        } 
    }
}
