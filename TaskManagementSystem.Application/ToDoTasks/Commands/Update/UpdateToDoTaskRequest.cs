using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entites.ToDoTask;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Update
{
    public class UpdateToDoTaskRequest : IRequest<UpdateToDoTaskResponse>
    {
        public Guid Id { get; set; }
        public string ToDoTaskName { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CreatorUserId { get; set; }
        public Guid AssignedUserId { get; set; }
        public StatusEnum Status { get; set; }
    }
}
