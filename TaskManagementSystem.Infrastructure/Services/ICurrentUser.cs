using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;

namespace TaskManagementSystem.Infrastructure.Services
{
    public interface ICurrentUser
    {
        Task<UserResponseDTO> GetCurrentUser();
    }
}
