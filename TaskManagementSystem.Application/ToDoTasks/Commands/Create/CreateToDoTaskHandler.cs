using MediatR;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Create
{
    public class CreateToDoTaskHandler : IRequestHandler<CreateToDoTaskRequest, CreateToDoTaskResponse>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly ICurrentUserService _currentUser;

        public CreateToDoTaskHandler(IToDoTaskRepository toDoTaskRepository, ICurrentUserService currentUser)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _currentUser = currentUser;
        }

        public async Task<CreateToDoTaskResponse> Handle(CreateToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();

            var task = CreateToDoTaskMapper.MapToEntity(request, currentUser.Id, currentUser.DepartmentId);

            await _toDoTaskRepository.Create(task);

            var response = CreateToDoTaskMapper.MapToResponse(task);

            return response;
        }
    }
}
