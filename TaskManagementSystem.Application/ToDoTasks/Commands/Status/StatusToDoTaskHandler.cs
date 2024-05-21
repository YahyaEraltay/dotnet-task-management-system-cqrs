using MediatR;
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
                if (task.Status == Domain.Entites.ToDoTask.StatusEnum.Pending)
                {
                    task.Status = request.Status;

                    await _toDoTaskRepository.UpdateStatus(task);

                    var response = new StatusToDoTaskResponse
                    {
                        Status = task.Status,
                    };

                    return response;
                }
                if (task.Status == Domain.Entites.ToDoTask.StatusEnum.Approved || task.Status == Domain.Entites.ToDoTask.StatusEnum.Denied)
                {
                    throw new Exception("This task has already been approved or denied");
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("You can only approve/reject the task assigned to you");
            }
        }
    }
}
