using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Status
{
    public class StatusToDoTaskHandler : IRequestHandler<StatusToDoTaskRequest, StatusToDoTaskResponse>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly ICurrentUserService _currentUser;

        public StatusToDoTaskHandler(IToDoTaskRepository toDoTaskRepository, ICurrentUserService currentUser)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _currentUser = currentUser;
        }

        public async Task<StatusToDoTaskResponse> Handle(StatusToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var task = await _toDoTaskRepository.GetById(request.Id);
            var assignedUser = await _toDoTaskRepository.AssignedUser(task.Id);

            if (currentUser.Id == assignedUser)
            {
                task.Id = request.Id;
                task.Status = request.Status;

                await _toDoTaskRepository.UpdateStatus(task);

                var response = new StatusToDoTaskResponse
                {
                    Status = task.Status,
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
