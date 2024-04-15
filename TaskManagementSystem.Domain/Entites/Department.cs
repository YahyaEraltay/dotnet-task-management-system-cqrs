using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entites
{
    public class Department
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }

        public List<User> Users { get; set; }
        public List<ToDoTask> ToDoTasks { get; set; }
    }
}
