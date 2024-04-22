using MediatR;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Departments.Commands.Update
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentRequest, UpdateDepartmentResponse>
    {
        private readonly IDepartmentService _departmentService;

        public UpdateDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetById(request.Id);

            if (department != null)
            {
                var updatedDepartment = new UpdateDepartmentRequestDTO
                {
                    Id = department.Id,
                    DepartmentName = request.DepartmentName
                };

                await _departmentService.Update(updatedDepartment);
            }

            var response = new UpdateDepartmentResponse
            {
                Id = department.Id,
                DepartmentName = request.DepartmentName
            };

            return response;
        }
    }
}
