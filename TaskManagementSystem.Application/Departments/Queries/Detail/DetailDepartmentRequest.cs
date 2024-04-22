using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Departments.Queries.Detail
{
    public class DetailDepartmentRequest : IRequest<DetailDepartmentResponse>
    {
        public Guid Id { get; set; }
    }
}
