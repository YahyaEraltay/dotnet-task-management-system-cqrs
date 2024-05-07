using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;

namespace TaskManagementSystem.Application.Departments.Commands.Create
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
    {
        private readonly IDepartmentService _departmentService;

        public CreateDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<CreateDepartmentResponse> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = new Infrastructure.DTOs.DepartmentDTOs.CreateDepartmentDTOs.RequestModel()
            {
                DepartmentName = request.DepartmentName
            };

            await _departmentService.Create(department);

            var response = new CreateDepartmentResponse()
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };

            return response;
        }
    }
}
