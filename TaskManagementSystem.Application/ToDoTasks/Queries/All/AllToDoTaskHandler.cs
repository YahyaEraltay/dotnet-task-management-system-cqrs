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

            var response = AllToDoTaskMapper.MapToResponse(tasks);

            return response;
        }
    }
}