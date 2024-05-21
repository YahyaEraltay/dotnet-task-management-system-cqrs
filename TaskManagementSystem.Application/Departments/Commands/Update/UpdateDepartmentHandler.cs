using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Departments.Commands.Update
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentRequest, UpdateDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public UpdateDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetById(request.Id);

            department = UpdateDepartmentMapper.MapToEntity(request, department);

            await _departmentRepository.Update(department);

            var response = UpdateDepartmentMapper.MapToResponse(department);

            return response;
        }
    }
}
