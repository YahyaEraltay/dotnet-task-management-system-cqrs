using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel;

namespace TaskManagementSystem.Application.Departments.Commands.Update
{
    public class UpdateRequest : IRequest<UpdateResponse>
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }  
    }
}
