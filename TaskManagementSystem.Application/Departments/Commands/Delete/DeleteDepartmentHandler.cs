using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.Application.Departments.Commands.Delete
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentRequest, DeleteDepartmentResponse>
    {
        private readonly IDepartmentService _departmentService;

        public DeleteDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<DeleteDepartmentResponse> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetById(request.Id);
            var response = new DeleteDepartmentResponse();

            await _departmentService.Delete(new GetDepartmentIdRequestDTO
            {
                Id = department.Id,
            });

            response.IsDeleted = true;
            response.Message = "Department deleted";

            return response;
        }
    }
}

