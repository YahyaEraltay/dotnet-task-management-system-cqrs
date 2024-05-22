using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.AssignedToDoTask
{
    public class AssignedToDoTaskMapper
    {
        public static List<AssignedToDoTaskResponse> MapToResponse(List<ToDoTask> assignedTasks)
        {
            return assignedTasks.Select(assignedTask => new AssignedToDoTaskResponse
            {
                Id = assignedTask.Id,
                ToDoTaskDate = assignedTask.ToDoTaskDate.Date,
                CreatorUserName = assignedTask.CreatorUser.UserName,
                AssignedUserName = assignedTask.AssignedUser.UserName,
                AssignedDepartmentName = assignedTask.CreatorUser.Department.DepartmentName,
                ToDoTaskName = assignedTask.ToDoTaskName,
                Status = assignedTask.Status,
            }).ToList();
        }
    }
}
