using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Delete
{
    public class DeleteToDoTaskRequest : IRequest<DeleteToDoTaskResponse>
    {
        public Guid Id { get; set; }
    }
}
