﻿using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Departments.Queries.All
{
    public class AllDepartmentHandler : IRequestHandler<AllDepartmentRequest, List<AllDepartmentResponse>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public AllDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<AllDepartmentResponse>> Handle(AllDepartmentRequest request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.All();

            var response = AllDepartmentMapper.MapToResponse(departments);

            return response;
        }
    }
}
