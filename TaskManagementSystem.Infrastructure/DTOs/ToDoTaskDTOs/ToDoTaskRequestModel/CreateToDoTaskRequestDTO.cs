using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entites.ToDoTask;

namespace TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel
{
    public class CreateToDoTaskRequestDTO
    {
        public string ToDoTaskName { get; set; }
        public int DepartmentId { get; set; }
        public int CreatorUserId { get; set; }
        public int AssignedUserId { get; set; }
        public StatusEnum Status { get; set; }
    }
}
