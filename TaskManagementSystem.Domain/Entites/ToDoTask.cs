using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entites
{
    public class ToDoTask
    {
        public Guid Id { get; set; }
        public string ToDoTaskName { get; set; }
        public string ToDoTaskDescription { get; set; }
        public DateTime ToDoTaskDate { get; set; }

        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }

        public User CreatorUser { get; set; }
        public Guid CreatorUserId { get; set; }
        public User AssignedUser { get; set; }
        public Guid AssignedUserId { get; set; }

        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Pending = 0,
            Approved = 1,
            Denied = 2
        }
    }
}
