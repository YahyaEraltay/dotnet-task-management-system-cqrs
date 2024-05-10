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
            var response = new List<AssignedToDoTaskResponse>();

            foreach ( var assignedTask in assignedTasks )
            {
                response.Add(new AssignedToDoTaskResponse
                {
                    ToDoTaskDate = assignedTask.ToDoTaskDate.Date,
                    CreatorUserName = assignedTask.CreatorUser.UserName,
                    AssignedUserName = assignedTask.AssignedUser.UserName,
                    AssignedDepartmentName = assignedTask.AssignedUser.Department.DepartmentName,
                    ToDoTaskName = assignedTask.ToDoTaskName,
                    Status = assignedTask.Status,
                });
            }

            return response;
        }
    }
}
