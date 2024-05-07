namespace TaskManagementSystem.Infrastructure.DomainServices
{
    public interface IDepartmentService
    {
        Task<DTOs.DepartmentDTOs.CreateDepartmentDTOs.ResponseModel> Create(DTOs.DepartmentDTOs.CreateDepartmentDTOs.RequestModel request);
        Task<DTOs.DepartmentDTOs.UpdateDepartmentDTOs.ResponseModel> Update(DTOs.DepartmentDTOs.UpdateDepartmentDTOs.RequestModel request);
        Task<DTOs.DepartmentDTOs.DeleteDepartmentDTOs.ResponseModel> Delete(DTOs.DepartmentDTOs.DeleteDepartmentDTOs.RequestModel request);
        Task<DTOs.DepartmentDTOs.GetByIdDepartmentDTOs.ResponseModel> GetById(Guid id);
        Task<List<DTOs.DepartmentDTOs.AllDepartmentDTOs.ResponseModel>> All();
    }
}
