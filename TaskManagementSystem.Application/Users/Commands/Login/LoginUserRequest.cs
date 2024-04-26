using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Users.Commands.Login
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string UserEmail { get; set; }
    }
}
