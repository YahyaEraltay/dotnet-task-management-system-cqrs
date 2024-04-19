﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Departments.Queries.All
{
    public class AllRequest : IRequest<AllResponse>
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
