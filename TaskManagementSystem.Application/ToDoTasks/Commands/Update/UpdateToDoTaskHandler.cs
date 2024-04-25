using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Update
{
    public class UpdateToDoTaskHandler : IRequestHandler<UpdateToDoTaskRequest, UpdateToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;

        public UpdateToDoTaskHandler(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        public async Task<UpdateToDoTaskResponse> Handle(UpdateToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var updatedUser = await _toDoTaskService.Update(new UpdateToDoTaskRequestDTO
            {
                Id = request.Id,
                ToDoTaskName = request.ToDoTaskName,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = request.CreatorUserId,
                DepartmentId = request.DepartmentId,
                Status = request.Status
            });

            var response = new UpdateToDoTaskResponse
            {
                Id = updatedUser.Id,
                ToDoTaskName = updatedUser.ToDoTaskName,
                AssignedUserName = updatedUser.AssignedUserName,
                CreatorUserName = updatedUser.CreatorUserName,
                DepartmentName = updatedUser.DepartmentName,
                Status = updatedUser.Status
            };

            return response;
        }
    }
}
