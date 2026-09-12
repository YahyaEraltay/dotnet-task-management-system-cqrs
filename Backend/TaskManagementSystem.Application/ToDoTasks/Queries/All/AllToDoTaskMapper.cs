using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.All;

public class AllToDoTaskMapper
{
    public static List<AllToDoTaskResponse> MapToResponse(List<ToDoTask> tasks)
    {
        return tasks?.Select(task => new AllToDoTaskResponse
        {
            Id = task.Id,
            AssignedUserId = task.AssignedUserId,
            AssignedUserName = task.AssignedUser.UserName,
            AssignedUserEmail = task.AssignedUser.UserEmail,
            AssignedDepartmentName = task.Department.DepartmentName,
            ToDoTaskName = task.ToDoTaskName,
            ToDoTaskDescription = task.ToDoTaskDescription,
            CreatorUserName = task.CreatorUser.UserName,
            Status = task.Status
        }).ToList();
    }
}
