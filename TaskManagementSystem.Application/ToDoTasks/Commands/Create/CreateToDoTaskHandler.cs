using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Create
{
    public class CreateToDoTaskHandler : IRequestHandler<CreateToDoTaskRequest, CreateToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;

        public CreateToDoTaskHandler(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        public async Task<CreateToDoTaskResponse> Handle(CreateToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var task = new CreateToDoTaskRequestDTO
            {
                ToDoTaskName = request.ToDoTaskName,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = request.CreatorUserId,
                DepartmentId = request.DepartmentId,
                Status = request.Status = 0
            };

            await _toDoTaskService.Create(task);

            var response = new CreateToDoTaskResponse
            {
                Id = task.Id,
                ToDoTaskName = request.ToDoTaskName,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = request.CreatorUserId,
                DepartmentId = request.DepartmentId,
                Status = request.Status
            };

            return response;
        }
    }
}
