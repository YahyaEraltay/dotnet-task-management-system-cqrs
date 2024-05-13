using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entites.ToDoTask;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.Detail
{
    public class DetailToDoTaskResponse
    {
        public Guid Id { get; set; }
        public string ToDoTaskName { get; set; }
        public string AssignedUserName { get; set; }
        public string AssignedUserEmail { get; set; }
        public string AssignedDepartmentName { get; set; }
        public string CreatorUserName { get; set; }
        public StatusEnum Status { get; set; }
    }
}
