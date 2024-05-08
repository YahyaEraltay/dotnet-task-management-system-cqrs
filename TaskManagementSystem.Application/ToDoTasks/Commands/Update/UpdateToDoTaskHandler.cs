using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Update
{
    public class UpdateToDoTaskHandler : IRequestHandler<UpdateToDoTaskRequest, UpdateToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly ICurrentUserService _currentUser;

        public UpdateToDoTaskHandler(IToDoTaskService toDoTaskService, ICurrentUserService currentUser)
        {
            _toDoTaskService = toDoTaskService;
            _currentUser = currentUser;
        }

        public async Task<UpdateToDoTaskResponse> Handle(UpdateToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();

            if (currentUser.Id == request.CreatorUserId)
            {
                var updatedUser = await _toDoTaskService.Update(new Infrastructure.DTOs.ToDoTaskDTOs.UpdateToDoTaskDTOs.RequestModel
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
            else
            {
                throw new Exception("You can only update tasks that you have created yourself");
            }


        }
    }
}
