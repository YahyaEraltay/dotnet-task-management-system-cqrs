using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel
{
    public class DeleteToDoTaskResponseDTO
    {
        public Guid IsDeleted { get; set; }
        public string Message { get; set; }
    }
}
