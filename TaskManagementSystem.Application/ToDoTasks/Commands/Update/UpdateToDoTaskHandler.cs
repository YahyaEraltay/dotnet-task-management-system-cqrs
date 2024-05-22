using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Update
{
    public class UpdateToDoTaskHandler : IRequestHandler<UpdateToDoTaskRequest, UpdateToDoTaskResponse>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly ICurrentUserService _currentUser;

        public UpdateToDoTaskHandler(IToDoTaskRepository toDoTaskRepository, ICurrentUserService currentUser)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _currentUser = currentUser;
        }

        public async Task<UpdateToDoTaskResponse> Handle(UpdateToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var task = await _toDoTaskRepository.GetById(request.Id);
            var creatorUser = await _toDoTaskRepository.CreatorUser(task.Id);

            if (currentUser.Id != creatorUser)
            {
                throw new Exception("You can only update tasks that you have created yourself");
            }

            task = UpdateToDoTaskMapper.MapToEntity(task, request);

            await _toDoTaskRepository.Update(task);

            var response = UpdateToDoTaskMapper.MapToResponse(task);

            return response;
        }
    }
}
