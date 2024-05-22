using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Departments.Queries.All
{
    public class AllDepartmentMapper
    {
        public static List<AllDepartmentResponse> MapToResponse(List<Department> departments)
        {
            return departments?.Select(department => new AllDepartmentResponse
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            }).ToList();
        }
    }
}
