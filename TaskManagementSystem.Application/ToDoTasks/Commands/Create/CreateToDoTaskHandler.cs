using MediatR;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DomainServices;
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

            var task = new ToDoTask
            {
                ToDoTaskName = request.ToDoTaskName,
                ToDoTaskDescription = request.ToDoTaskDescription,
                ToDoTaskDate = DateTime.Now.Date,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = currentUser.Id,
                DepartmentId = request.DepartmentId,
                Status = request.Status = 0
            };

            await _toDoTaskRepository.Create(task);

            var response = new CreateToDoTaskResponse
            {
                Id = task.Id,
                ToDoTaskName = request.ToDoTaskName,
                ToDoTaskDescription = request.ToDoTaskDescription,
                ToDoTaskDate = task.ToDoTaskDate.Date,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = request.CreatorUserId,
                DepartmentId = request.DepartmentId,
                Status = request.Status
            };

            return response;
        }
    }
}
