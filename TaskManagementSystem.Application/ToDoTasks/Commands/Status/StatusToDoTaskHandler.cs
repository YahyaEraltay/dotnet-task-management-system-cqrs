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

            if (currentUser.Id != assignedUser)
            {
                throw new Exception("You can only approve/reject the task assigned to you");
            }

            if (task.Status != Domain.Entites.ToDoTask.StatusEnum.Pending)
            {
                throw new Exception("This task has already been approved or denied");
            }

            var statusTask = StatusToDoTaskMapper.MapToEntity(task, request);

            await _toDoTaskRepository.Update(statusTask);

            var response = StatusToDoTaskMapper.MapToResponse(task);

            return response;
        }
    }
}
