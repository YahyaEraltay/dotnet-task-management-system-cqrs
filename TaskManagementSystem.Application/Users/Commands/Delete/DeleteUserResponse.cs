using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Users.Commands.Delete
{
    public class DeleteUserResponse
    {
        public bool IsDeleted { get; set; }
        public string Message { get; set; }
    }
}
