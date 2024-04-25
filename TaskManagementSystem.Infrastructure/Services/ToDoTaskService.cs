using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<List<GetToDoTaskResponseDTO>> All()
        {
            var tasks = await _toDoTaskRepository.All();
            var response = new List<GetToDoTaskResponseDTO>();

            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    response.Add(new GetToDoTaskResponseDTO()
                    {
                        Id = task.Id,
                        AssignedUserName = task.AssignedUser.UserName,
                        AssignedUserEmail = task.AssignedUser.UserEmail,
                        DepartmentName = task.Department.DepartmentName,
                        ToDoTaskName = task.ToDoTaskName,
                        CreatorUserName = task.CreatorUser.UserName,
                        Status = task.Status
                    });
                }

                return response;
            }
            else
            {
                throw new Exception("There is no to do task");
            }
        }

        public async Task<CreateToDoTaskResponseDTO> Create(CreateToDoTaskRequestDTO request)
        {
            var task = new ToDoTask()
            {
                ToDoTaskName = request.ToDoTaskName,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = request.CreatorUserId,
                DepartmentId = request.DepartmentId,
                Status = request.Status = 0,
            };

            await _toDoTaskRepository.Create(task);

            var response = new CreateToDoTaskResponseDTO()
            {
                Id = task.Id,
                ToDoTaskName = task.ToDoTaskName,
                AssignedUserId = task.AssignedUserId,
                CreatorUserId = task.CreatorUserId,
                DepartmentId = task.DepartmentId,
                Status = task.Status
            };

            return response;
        }

        public async Task<DeleteToDoTaskResponseDTO> Delete(GetToDoTaskIdRequestDTO request)
        {
            var task = await _toDoTaskRepository.GetById(request.Id);
            var response = new DeleteToDoTaskResponseDTO();

            if (task != null)
            {
                await _toDoTaskRepository.Delete(task);

                response.IsDeleted = true;
                response.Message = "Task deleted";

                return response;
            }
            else
            {
                throw new Exception("Task could not be deleted");
            }
        }

        public async Task<GetToDoTaskResponseDTO> GetById(Guid id)
        {
            var task = await _toDoTaskRepository.GetById(id);

            if (task != null)
            {
                var response = new GetToDoTaskResponseDTO
                {
                    Id = task.Id,
                    AssignedUserName = task.AssignedUser.UserName,
                    AssignedUserEmail = task.AssignedUser.UserEmail,
                    DepartmentName = task.Department.DepartmentName,
                    ToDoTaskName = task.ToDoTaskName,
                    CreatorUserName = task.CreatorUser.UserName,
                    Status = task.Status
                };

                return response;
            }
            else
            {
                throw new Exception("Task not found");
            }
        }

        public async Task<UpdateToDoTaskResponseDTO> Update(UpdateToDoTaskRequestDTO request)
        {
            var task = await _toDoTaskRepository.GetById(request.Id);

            if (task != null)
            {
                task.ToDoTaskName = request.ToDoTaskName;
                task.DepartmentId = request.DepartmentId;
                task.CreatorUserId = request.CreatorUserId;
                task.AssignedUserId = request.AssignedUserId;
                task.Status = request.Status;

                await _toDoTaskRepository.Update(task);

                var response = new UpdateToDoTaskResponseDTO
                {
                    Id = task.Id,
                    ToDoTaskName = task.ToDoTaskName,
                    DepartmentName = task.Department.DepartmentName,
                    CreatorUserName = task.CreatorUser.UserName,
                    AssignedUserName = task.AssignedUser.UserName,
                    Status = task.Status
                };

                return response;
            }
            else
            {
                throw new Exception("Task not found");
            }
        }
    }
}
