using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Create
{
    public class CreateToDoTaskHandler : IRequestHandler<CreateToDoTaskRequest, CreateToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly ICurrentUserService _currentUser;

        public CreateToDoTaskHandler(IToDoTaskService toDoTaskService, ICurrentUserService currentUser)
        {
            _toDoTaskService = toDoTaskService;
            _currentUser = currentUser;
        }

        public async Task<CreateToDoTaskResponse> Handle(CreateToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();

            var task = new Infrastructure.DTOs.ToDoTaskDTOs.CreateToDoTaskDTOs.RequestModel
            {
                ToDoTaskName = request.ToDoTaskName,
                ToDoTaskDescription = request.ToDoTaskDescription,
                ToDoTaskDate = DateTime.Now.Date,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = currentUser.Id,
                DepartmentId = request.DepartmentId,
                Status = request.Status = 0
            };

            await _toDoTaskService.Create(task);

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
