using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entites
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }

        public List<ToDoTask> ToDoTasks { get; set; }
    }
}
