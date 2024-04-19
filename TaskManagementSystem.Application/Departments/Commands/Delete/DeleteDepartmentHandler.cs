using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Departments.Commands.Delete
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteRequest, DeleteResponse>
    {
        private readonly IDepartmentService _departmentService;

        public DeleteDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<DeleteResponse> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.Delete(new GetDepartmentIdRequestDTO
            {
                Id = request.Id
            });

            var response = new DeleteResponse
            {
                IsDeleted = true,
                Message = "abc"
            };

            return response;
        }
    }
}

