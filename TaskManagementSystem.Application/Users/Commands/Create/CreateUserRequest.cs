﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Users.Commands.Create
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
