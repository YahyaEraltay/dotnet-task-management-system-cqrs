using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.AssignedToDoTask
{
    public class AssignedToDoTaskHandler : IRequestHandler<AssignedToDoTaskRequest, List<AssignedToDoTaskResponse>>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public AssignedToDoTaskHandler(ICurrentUserService currentUser, IToDoTaskRepository toDoTaskRepository)
        {
            _currentUser = currentUser;
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<List<AssignedToDoTaskResponse>> Handle(AssignedToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var assignedTasks = await _toDoTaskRepository.AssignedToDoTask(currentUser.Id);

            var response = AssignedToDoTaskMapper.MapToResponse(assignedTasks);

            return response;
        }
    }
}
