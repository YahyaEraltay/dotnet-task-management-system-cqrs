using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.Services;

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
