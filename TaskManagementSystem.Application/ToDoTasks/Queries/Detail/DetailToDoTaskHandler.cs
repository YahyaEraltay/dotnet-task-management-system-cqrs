using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.ToDoTasks.Queries.All;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel;
using TaskManagementSystem.Infrastructure.Services;
using static TaskManagementSystem.Domain.Entites.ToDoTask;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.Detail
{
    public class DetailToDoTaskHandler : IRequestHandler<DetailToDoTaskRequest, DetailToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;

        public DetailToDoTaskHandler(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        public async Task<DetailToDoTaskResponse> Handle(DetailToDoTaskRequest request, CancellationToken cancellationToken)
        {
            //var task = await _toDoTaskService.GetById(request.Id);

            //var response = new DetailToDoTaskResponse
            //{
            //    Id = task.Id,
            //    AssignedUserName = task.AssignedUserName,
            //    AssignedUserEmail = task.AssignedUserEmail,
            //    DepartmentName = task.DepartmentName,
            //    ToDoTaskName = task.ToDoTaskName,
            //    CreatorUserName = task.CreatorUserName,
            //    Status = task.Status
            //};

            //return response;

            var toDoTask = await _toDoTaskService.GetById(request.Id);

            if (toDoTask != null)
            {
                var toDoTaskDTO = new DetailToDoTaskResponse()
                {
                    Id = toDoTask.Id,
                    ToDoTaskName = toDoTask.ToDoTaskName,
                    DepartmentName = toDoTask.DepartmentName,
                    CreatorUserName = toDoTask.CreatorUserName,
                    AssignedUserName = toDoTask.AssignedUserName,
                    AssignedUserEmail = toDoTask.AssignedUserEmail,
                    Status = toDoTask.Status,
                };

                return toDoTaskDTO;
            }
            else
            {
                throw new Exception("Task not found");
            }
        }
    }
}
