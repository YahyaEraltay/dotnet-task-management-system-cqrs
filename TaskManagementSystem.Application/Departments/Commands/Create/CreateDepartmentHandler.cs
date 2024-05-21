using MediatR;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Departments.Commands.Create
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public CreateDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<CreateDepartmentResponse> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = CreateDepartmentMapper.MapToEntity(request);

            await _departmentRepository.Create(department);

            var response = CreateDepartmentMapper.MapToResponse(department);

            return response;
        }
    }
}
