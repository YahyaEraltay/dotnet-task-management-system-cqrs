namespace TaskManagementSystem.Infrastructure.DomainServices
{
    public interface IUserService
    {
        Task<DTOs.UserDTOs.CreateUserDTOs.ResponseModel> Create(DTOs.UserDTOs.CreateUserDTOs.RequestModel request);
        Task<DTOs.UserDTOs.UpdateUserDTOs.ResponseModel> Update(DTOs.UserDTOs.UpdateUserDTOs.RequestModel request);
        Task<DTOs.UserDTOs.DeleteUserDTOs.ResponseModel> Delete(DTOs.UserDTOs.DeleteUserDTOs.RequestModel request);
        Task<DTOs.UserDTOs.GetByIdUserDTOs.ResponseModel> GetById(Guid id);
        Task<List<DTOs.UserDTOs.AllUserDTOs.ResponseModel>> All();
        Task<DTOs.UserDTOs.LoginUserDTOs.ResponseModel> Login(DTOs.UserDTOs.LoginUserDTOs.RequestModel request);
        Task<string> GetUserByEmail(string email);
    }
}
