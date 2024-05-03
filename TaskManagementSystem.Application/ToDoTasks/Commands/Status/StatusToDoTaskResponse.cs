using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entites.ToDoTask;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Status
{
    public class StatusToDoTaskResponse
    {
        public StatusEnum Status { get; set; }
    }
}
