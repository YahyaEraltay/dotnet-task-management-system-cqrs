using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DomainServices;

namespace TaskManagementSystem.Application.Departments.Queries.All
{
    public class AllDepartmentHandler : IRequestHandler<AllDepartmentRequest, List<AllDepartmentResponse>>
    {
        private readonly IDepartmentService _departmentService;

        public AllDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<List<AllDepartmentResponse>> Handle(AllDepartmentRequest request, CancellationToken cancellationToken)
        {
            var departments = await _departmentService.All();
            var response = new List<AllDepartmentResponse>();

            foreach (var department in departments)
            {
                response.Add(new AllDepartmentResponse
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName
                });
            }

            return response;
        }
    }
}
