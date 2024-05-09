﻿using MediatR;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DomainServices;
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
            var updatedTask = await _toDoTaskRepository.GetById(request.Id);
            var creatorUser = await _toDoTaskRepository.CreatorUser(updatedTask.Id);

            if (currentUser.Id == creatorUser)
            {
                updatedTask.Id = request.Id;
                updatedTask.ToDoTaskName = request.ToDoTaskName;
                updatedTask.AssignedUserId = request.AssignedUserId;
                updatedTask.DepartmentId = request.DepartmentId;

                await _toDoTaskRepository.Update(updatedTask);

                var response = new UpdateToDoTaskResponse
                {
                    Id = updatedTask.Id,
                    ToDoTaskName = updatedTask.ToDoTaskName,
                    AssignedUserName = updatedTask.AssignedUser.UserName,
                    CreatorUserName = updatedTask.CreatorUser.UserName,
                    DepartmentName = updatedTask.Department.DepartmentName,
                };

                return response;
            }
            else
            {
                throw new Exception("You can only update tasks that you have created yourself");
            }


        }
    }
}
