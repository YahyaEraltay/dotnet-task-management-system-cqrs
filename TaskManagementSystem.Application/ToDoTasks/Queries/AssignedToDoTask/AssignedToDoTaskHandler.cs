using MediatR;
using TaskManagementSystem.Application.Auth;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.AssignedToDoTask
{
    public class AssignedToDoTaskHandler : IRequestHandler<AssignedToDoTaskRequest, List<AssignedToDoTaskResponse>>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IToDoTaskService _toDoTaskService;

        public AssignedToDoTaskHandler(ICurrentUserService currentUser, IToDoTaskService toDoTaskService)
        {
            _currentUser = currentUser;
            _toDoTaskService = toDoTaskService;
        }

        public async Task<List<AssignedToDoTaskResponse>> Handle(AssignedToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var assignedTasks = await _toDoTaskService.AssignedTasks(currentUser.Id);
            var response = new List<AssignedToDoTaskResponse>();

            foreach ( var assignedTask in assignedTasks )
            {
                response.Add(new AssignedToDoTaskResponse
                {
                    ToDoTaskDate = assignedTask.ToDoTaskDate.Date,
                    CreatorUserName = assignedTask.CreatorUserName,
                    AssignedUserName = assignedTask.AssignedUserName,
                    AssignedDepartmentName = assignedTask.AssignedDepartmentName,
                    ToDoTaskName = assignedTask.ToDoTaskName,
                    Status = assignedTask.Status,
                });
            }

            return response;
        }
    }
}
