using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.UserDTOs.LoginUserDTOs
{
    public class RequestModel
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
