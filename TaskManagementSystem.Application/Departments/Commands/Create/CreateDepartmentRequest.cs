﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Departments.Commands.Create
{
    public class CreateDepartmentRequest : IRequest<CreateDepartmentResponse>
    {
        public string DepartmentName { get; set; }
    }
}
