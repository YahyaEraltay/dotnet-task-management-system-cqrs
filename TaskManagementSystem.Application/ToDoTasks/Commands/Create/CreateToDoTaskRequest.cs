using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entites.ToDoTask;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Create
{
    public class CreateToDoTaskRequest : IRequest<CreateToDoTaskResponse>
    {
        public string ToDoTaskName { get; set; }
        public string ToDoTaskDescription { get; set; }
        public DateTime ToDoTaskDate { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CreatorUserId { get; set; }
        public Guid AssignedUserId { get; set; }
        public StatusEnum Status { get; set; }
    }
}
