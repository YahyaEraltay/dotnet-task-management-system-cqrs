using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;
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
            var departmentDetail = await _departmentRepository.GetById(request.Id);

            var response = new DetailDepartmentResponse
            {
                Id = departmentDetail.Id,
                DepartmentName = departmentDetail.DepartmentName
            };

            return response;
        }
    }
}
