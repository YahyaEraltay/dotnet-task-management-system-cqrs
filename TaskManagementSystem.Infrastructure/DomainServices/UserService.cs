using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.DomainServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<DTOs.UserDTOs.AllUserDTOs.ResponseModel>> All()
        {
            var users = await _userRepository.All();
            var response = new List<DTOs.UserDTOs.AllUserDTOs.ResponseModel>();

            foreach (var user in users)
            {
                response.Add(new DTOs.UserDTOs.AllUserDTOs.ResponseModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    DepartmentName = user.Department.DepartmentName
                });
            }

            return response;
        }

        public async Task<DTOs.UserDTOs.CreateUserDTOs.ResponseModel> Create(DTOs.UserDTOs.CreateUserDTOs.RequestModel request)
        {
            var user = new User()
            {
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                UserPassword = request.UserPassword,
                PhoneNumber = request.PhoneNumber,
                DepartmentId = request.DepartmentId,
                UserTitle = request.UserTitle,
            };

            await _userRepository.Create(user);

            var response = new DTOs.UserDTOs.CreateUserDTOs.ResponseModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                PhoneNumber = user.PhoneNumber,
                DepartmentId = user.DepartmentId,
                UserTitle = user.UserTitle,
            };

            return response;
        }

        public async Task<DTOs.UserDTOs.DeleteUserDTOs.ResponseModel> Delete(DTOs.UserDTOs.DeleteUserDTOs.RequestModel request)
        {
            var user = await _userRepository.GetById(request.Id);
            var response = new DTOs.UserDTOs.DeleteUserDTOs.ResponseModel();

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

        public async Task<DTOs.UserDTOs.GetByIdUserDTOs.ResponseModel> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user != null)
            {
                var response = new DTOs.UserDTOs.GetByIdUserDTOs.ResponseModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    PhoneNumber = user.PhoneNumber,
                    UserTitle = user.UserTitle,
                    DepartmentName = user.Department.DepartmentName
                };

                return response;
            }
            else
            {
                throw new Exception("User could not be find");
            }

        }

        public async Task<string> GetUserByEmail(string email)
        {
            var userEmail = await _userRepository.GetUserByEmail(email);
            var userPassword = userEmail.UserPassword;

            return userPassword;
        }

        public async Task<DTOs.UserDTOs.LoginUserDTOs.ResponseModel> Login(DTOs.UserDTOs.LoginUserDTOs.RequestModel request)
        {
            var user = await _userRepository.Login(request.UserEmail, request.UserPassword);

            if (user != null)
            {
                return new DTOs.UserDTOs.LoginUserDTOs.ResponseModel
                {
                    UserName = user.UserName,
                    UserEmail = user.UserEmail
                };
            }
            else
            {
                throw new Exception("Invalid email adress or password");
            }
        }

        public async Task<DTOs.UserDTOs.UpdateUserDTOs.ResponseModel> Update(DTOs.UserDTOs.UpdateUserDTOs.RequestModel request)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user != null)
            {
                user.UserName = request.UserName;
                user.UserEmail = request.UserEmail;
                user.UserPassword = request.UserPassword;
                user.PhoneNumber = request.PhoneNumber;
                user.UserTitle = request.UserTitle;
                user.DepartmentId = request.DepartmentId;

                await _userRepository.Update(user);

                var response = new DTOs.UserDTOs.UpdateUserDTOs.ResponseModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    PhoneNumber = user.PhoneNumber,
                    DepartmentName = user.Department.DepartmentName,
                    UserTitle = user.UserTitle
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
