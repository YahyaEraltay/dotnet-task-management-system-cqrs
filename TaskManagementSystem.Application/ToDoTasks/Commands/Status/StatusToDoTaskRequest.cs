using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entites.ToDoTask;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Status
{
    public class StatusToDoTaskRequest : IRequest<StatusToDoTaskResponse>
    {
        public Guid Id { get; set; }
        public StatusEnum Status { get; set; }
    }
}
