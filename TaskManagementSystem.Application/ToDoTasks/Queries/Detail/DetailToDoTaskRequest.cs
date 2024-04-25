using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.Detail
{
    public class DetailToDoTaskRequest : IRequest<DetailToDoTaskResponse>
    {
        public Guid Id { get; set; }
    }
}
