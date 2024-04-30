using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.AssignedToDoTask
{
    public class AssignedToDoTaskRequest : IRequest<List<AssignedToDoTaskResponse>>
    {
    }
}
