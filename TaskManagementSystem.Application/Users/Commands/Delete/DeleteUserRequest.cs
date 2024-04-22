using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Users.Commands.Delete
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public Guid Id { get; set; }
    }
}
