using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.Detail
{
    public class DetailToDoTaskHandler : IRequestHandler<DetailToDoTaskRequest, DetailToDoTaskResponse>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public DetailToDoTaskHandler(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<DetailToDoTaskResponse> Handle(DetailToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var toDoTask = await _toDoTaskRepository.GetById(request.Id);

            if (toDoTask != null)
            {
                var toDoTaskDTO = new DetailToDoTaskResponse()
                {
                    Id = toDoTask.Id,
                    ToDoTaskName = toDoTask.ToDoTaskName,
                    AssignedDepartmentName = toDoTask.Department.DepartmentName,
                    CreatorUserName = toDoTask.CreatorUser.UserName,
                    AssignedUserName = toDoTask.AssignedUser.UserName,
                    AssignedUserEmail = toDoTask.AssignedUser.UserEmail,
                    Status = toDoTask.Status,
                };

                return toDoTaskDTO;
            }
            else
            {
                throw new Exception("Task not found");
            }
        }
    }
}
