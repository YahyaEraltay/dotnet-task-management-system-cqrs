using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;

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

            await _departmentService.Delete(new Infrastructure.DTOs.DepartmentDTOs.DeleteDepartmentDTOs.RequestModel
            {
                Id = department.Id,
            });

            response.IsDeleted = true;
            response.Message = "Department deleted";

            return response;
        }
    }
}

