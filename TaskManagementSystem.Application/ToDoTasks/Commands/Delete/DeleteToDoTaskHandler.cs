﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Auth;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Delete
{
    public class DeleteToDoTaskHandler : IRequestHandler<DeleteToDoTaskRequest, DeleteToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly ICurrentUser _currentUser;

        public DeleteToDoTaskHandler(IToDoTaskService toDoTaskService, ICurrentUser currentUser)
        {
            _toDoTaskService = toDoTaskService;
            _currentUser = currentUser;
        }

        public async Task<DeleteToDoTaskResponse> Handle(DeleteToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var task = await _toDoTaskService.GetById(request.Id);
            var response = new DeleteToDoTaskResponse();

            if (currentUser.Id == request.CreatorUserId)
            {
                await _toDoTaskService.Delete(new GetToDoTaskIdRequestDTO
                {
                    Id = task.Id,
                });

                response.IsDeleted = true;
                response.Message = "Task deleted";

                return response;
            }
            else
            {
                throw new Exception("You can only delete tasks that you have created yourself");
            }
        }
    }
}
