using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.Services;

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
            var department = new CreateDepartmentRequestDTO()
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
