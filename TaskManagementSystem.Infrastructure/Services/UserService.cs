using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public async Task<List<UserResponseDTO>> All()
        {
            var users = await _userRepository.All();
            var response = new List<UserResponseDTO>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    response.Add(new UserResponseDTO
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        UserEmail = user.UserEmail,
                        DepartmentName = user.Department.DepartmentName
                    });
                }
                return response;
            }
            else
            {
                throw new Exception("There is no user");
            }
        }

        public async Task<CreateUserResponseDTO> Create(CreateUserRequestDTO request)
        {
            var user = new User()
            {
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                DepartmentId = request.DepartmentId,
            };

            await _userRepository.Create(user);

            var response = new CreateUserResponseDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                DepartmentName = user.Department.DepartmentName
            };

            return response;
        }

        public async Task<DeleteUserResponseDTO> Delete(GetUserIdRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);
            var response = new DeleteUserResponseDTO();

            if (user != null)
            {
                await _userRepository.Delete(user);

                response.IsDeleted = true;
                response.Message = "User deleted";
            }
            else
            {
                response.IsDeleted = false;
                response.Message = "User could not be deleted";
            }

            return response;
        }

        public async Task<UserResponseDTO> Detail(Guid id)
        {
            var user = await _userRepository.Detail(id);

            var response = new UserResponseDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                DepartmentName = user.Department.DepartmentName
            };

            return response;
        }

        public async Task<UserResponseDTO> Update(UpdateUserRequestDTO request)
        {
            var user = await _userRepository.Detail(request.Id);
            var response = new UserResponseDTO();

            if (user != null)
            {
                user.UserName = request.UserName;
                user.UserEmail = request.UserEmail;
                user.DepartmentId = request.DepartmentId;

                await _userRepository.Update(user);

                response = new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    DepartmentName = user.Department.DepartmentName
                };

                return response;
            }
            else
            {
                throw new Exception("User could not be updated");
            }
        }
    }
}
