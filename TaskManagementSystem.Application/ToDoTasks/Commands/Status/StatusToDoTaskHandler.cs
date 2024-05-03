using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Status
{
    public class StatusToDoTaskHandler : IRequestHandler<StatusToDoTaskRequest, StatusToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly ICurrentUserService _currentUser;

        public StatusToDoTaskHandler(IToDoTaskService toDoTaskService, ICurrentUserService currentUser)
        {
            _toDoTaskService = toDoTaskService;
            _currentUser = currentUser;
        }

        public async Task<StatusToDoTaskResponse> Handle(StatusToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var task = await _toDoTaskService.GetById(request.Id);
            var assignedUser = await _toDoTaskService.AssignedUser(task.Id);

            if (currentUser.Id == assignedUser)
            {
                var updateStatus = await _toDoTaskService.UpdateStatus(new UpdateToDoTaskRequestDTO
                {
                    Id = request.Id,
                    Status = request.Status
                });

                var response = new StatusToDoTaskResponse
                {
                    Status = updateStatus.Status,
                };

                return response;
            }
            else
            {
                throw new Exception("You can only approve/reject the task assigned to you");
            }
        }
    }
}
