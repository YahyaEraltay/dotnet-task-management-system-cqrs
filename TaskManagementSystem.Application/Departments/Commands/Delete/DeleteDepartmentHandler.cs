using MediatR;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Departments.Commands.Delete
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentRequest, DeleteDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DeleteDepartmentResponse> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetById(request.Id);

            department = DeleteDepartmentMapper.MapToEntity(department);

            await _departmentRepository.Delete(department);

            var response = DeleteDepartmentMapper.MapToResponse(true, "Department deleted");

            return response;
        }
    }
}

