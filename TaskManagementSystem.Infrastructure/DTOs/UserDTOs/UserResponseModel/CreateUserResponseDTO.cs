using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel
{
    public class CreateUserResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DepartmentId { get; set; }
        public string UserTitle { get; set; }
    }
}
