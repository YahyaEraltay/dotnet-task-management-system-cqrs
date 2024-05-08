using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManagementSystem.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        Task<DTOs.UserDTOs.CurrentUserDTOs.ResponseModel> GetCurrentUser();
    }
}
