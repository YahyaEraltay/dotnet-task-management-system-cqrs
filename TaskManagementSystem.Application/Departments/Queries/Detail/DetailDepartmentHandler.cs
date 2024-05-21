using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Departments.Queries.Detail
{
    public class DetailDepartmentHandler : IRequestHandler<DetailDepartmentRequest, DetailDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DetailDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DetailDepartmentResponse> Handle(DetailDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetById(request.Id);

            var response = DetailDepartmentMapper.MapToResponse(department);

            return response;
        }
    }
}
