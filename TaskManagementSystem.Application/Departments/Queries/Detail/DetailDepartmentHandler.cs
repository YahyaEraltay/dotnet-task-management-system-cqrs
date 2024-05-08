using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;

namespace TaskManagementSystem.Application.Departments.Queries.Detail
{
    public class DetailDepartmentHandler : IRequestHandler<DetailDepartmentRequest, DetailDepartmentResponse>
    {
        private readonly IDepartmentService _departmentService;

        public DetailDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<DetailDepartmentResponse> Handle(DetailDepartmentRequest request, CancellationToken cancellationToken)
        {
            var departmentDetail = await _departmentService.GetById(request.Id);

            var response = new DetailDepartmentResponse
            {
                Id = departmentDetail.Id,
                DepartmentName = departmentDetail.DepartmentName
            };

            return response;
        }
    }
}
