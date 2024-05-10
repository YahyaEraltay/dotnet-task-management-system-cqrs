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

            department.DepartmentName = request.DepartmentName;

            await _departmentRepository.Update(department);

            var response = new UpdateDepartmentResponse
            {
                Id = department.Id,
                DepartmentName = request.DepartmentName
            };

            return response;
        }
    }
}
