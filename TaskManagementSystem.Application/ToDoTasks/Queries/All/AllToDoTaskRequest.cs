using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.All
{
    public class AllToDoTaskRequest : IRequest<List<AllToDoTaskResponse>>
    {
    }
}
