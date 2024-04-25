using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Delete
{
    public class DeleteToDoTaskHandler : IRequestHandler<DeleteToDoTaskRequest, DeleteToDoTaskResponse>
    {
        private readonly IToDoTaskService _toDoTaskService;

        public DeleteToDoTaskHandler(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        public async Task<DeleteToDoTaskResponse> Handle(DeleteToDoTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _toDoTaskService.GetById(request.Id);
            var response = new DeleteToDoTaskResponse();

            await _toDoTaskService.Delete(new GetToDoTaskIdRequestDTO
            {
                Id = task.Id,
            });

            response.IsDeleted = true;
            response.Message = "Task deleted";

            return response;
        }
    }
}
