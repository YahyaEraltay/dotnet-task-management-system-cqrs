using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;

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
