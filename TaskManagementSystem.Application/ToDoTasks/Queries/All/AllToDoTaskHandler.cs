using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.All
{
    public class AllToDoTaskHandler : IRequestHandler<AllToDoTaskRequest, List<AllToDoTaskResponse>>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public AllToDoTaskHandler(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<List<AllToDoTaskResponse>> Handle(AllToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var tasks = await _toDoTaskRepository.All();
            var response = new List<AllToDoTaskResponse>();

            foreach (var task in tasks)
            {
                response.Add(new AllToDoTaskResponse
                {
                    Id = task.Id,
                    AssignedUserName = task.AssignedUser.UserName,
                    AssignedUserEmail = task.AssignedUser.UserEmail,
                    AssignedDepartmentName = task.Department.DepartmentName,
                    ToDoTaskName = task.ToDoTaskName,
                    CreatorUserName = task.CreatorUser.UserName,
                    Status = task.Status
                });
            }

            return response;


        }
    }
}