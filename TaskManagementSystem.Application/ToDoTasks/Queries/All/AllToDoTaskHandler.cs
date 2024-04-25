using MediatR;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.All
{
    public class AllToDoTaskHandler : IRequestHandler<AllToDoTaskRequest, List<AllToDoTaskResponse>>
    {
        private readonly IToDoTaskService _toDoTaskService;

        public AllToDoTaskHandler(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        public async Task<List<AllToDoTaskResponse>> Handle(AllToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var tasks = await _toDoTaskService.All();
            var response = new List<AllToDoTaskResponse>();

            foreach (var task in tasks)
            {
                response.Add(new AllToDoTaskResponse
                {
                    Id = task.Id,
                    AssignedUserName = task.AssignedUserName,
                    AssignedUserEmail = task.AssignedUserEmail,
                    DepartmentName = task.DepartmentName,
                    ToDoTaskName = task.ToDoTaskName,
                    CreatorUserName = task.CreatorUserName,
                    Status = task.Status
                });
            }

            return response;

            
        }
    }
}
