using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Departments.Commands.Delete
{
    public class DeleteDepartmentRequest : IRequest<DeleteDepartmentResponse>
    {
        public Guid Id { get; set; }
    }
}
