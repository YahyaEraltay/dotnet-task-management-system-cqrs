﻿using MediatR;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Delete
{
    public class DeleteToDoTaskHandler : IRequestHandler<DeleteToDoTaskRequest, DeleteToDoTaskResponse>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly ICurrentUserService _currentUser;

        public DeleteToDoTaskHandler(IToDoTaskRepository toDoTaskRepository, ICurrentUserService currentUser)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _currentUser = currentUser;
        }

        public async Task<DeleteToDoTaskResponse> Handle(DeleteToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var task = await _toDoTaskRepository.GetById(request.Id);
            var creatorUser = await _toDoTaskRepository.CreatorUser(task.Id);

            if (currentUser.Id != creatorUser)
            {
                throw new Exception("You can only delete the task created to you");

            }
            task = DeleteToDoTaskMapper.MapToEntity(task);

            await _toDoTaskRepository.Delete(task);

            var response = DeleteToDoTaskMapper.MapToResponse(true, "Task deleted");

            return response;
        }
    }
}
