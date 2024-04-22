using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;

namespace TaskManagementSystem.Infrastructure.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDTO> Create(CreateUserRequestDTO request);
        Task<UserResponseDTO> Update(UpdateUserRequestDTO request);
        Task<DeleteUserResponseDTO> Delete(GetUserIdRequestDTO request);
        Task<UserResponseDTO> Detail(Guid id);
        Task<List<UserResponseDTO>> All();
    }
}
