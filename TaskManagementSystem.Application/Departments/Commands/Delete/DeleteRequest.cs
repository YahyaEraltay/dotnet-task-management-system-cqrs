using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Departments.Commands.Delete
{
    public class DeleteRequest : IRequest<DeleteResponse>
    {
        public Guid Id { get; set; }
    }
}
