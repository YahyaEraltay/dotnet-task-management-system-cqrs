using MediatR;

namespace TaskManagementSystem.Application.Departments.Commands.Update
{
    public class UpdateDepartmentRequest : IRequest<UpdateDepartmentResponse>
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }  
    }
}
