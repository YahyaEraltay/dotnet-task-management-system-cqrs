using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Delete
{
    public class DeleteToDoTaskHandler : IRequestHandler<DeleteToDoTaskRequest, DeleteToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly ICurrentUserService _currentUser;

        public DeleteToDoTaskHandler(IToDoTaskService toDoTaskService, ICurrentUserService currentUser)
        {
            _toDoTaskService = toDoTaskService;
            _currentUser = currentUser;
        }

        public async Task<DeleteToDoTaskResponse> Handle(DeleteToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var task = await _toDoTaskService.GetById(request.Id);
            var creatorUser = await _toDoTaskService.CreatorUser(task.Id);

            var response = new DeleteToDoTaskResponse();

            if (currentUser.Id == creatorUser)
            {
                await _toDoTaskService.Delete(new Infrastructure.DTOs.ToDoTaskDTOs.DeleteToDoTaskDTOs.RequestModel
                {
                    Id = task.Id,
                });

                response.IsDeleted = true;
                response.Message = "Task deleted";

                return response;
            }
            else
            {
                throw new Exception("You can only delete the task created to you");
            }
        }
    }
}
