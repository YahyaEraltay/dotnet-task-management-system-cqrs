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
            var task = await _toDoTaskRepository.GetById(request.Id);

            var response = DetailToDoTaskMapper.MapToResponse(task);

            return response;
        }
    }
}
