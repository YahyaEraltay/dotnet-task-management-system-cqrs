using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Infrastructure.DomainServices
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly ICurrentUserService _currentUser;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository, ICurrentUserService currentUser)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _currentUser = currentUser;
        }

        public async Task<List<DTOs.ToDoTaskDTOs.AllToDoTaskDTOs.ResponseModel>> All()
        {
            var tasks = await _toDoTaskRepository.All();
            var response = new List<DTOs.ToDoTaskDTOs.AllToDoTaskDTOs.ResponseModel>();

            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    response.Add(new DTOs.ToDoTaskDTOs.AllToDoTaskDTOs.ResponseModel()
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

        public async Task<List<DTOs.ToDoTaskDTOs.AssignedToDoTaskDTOs.ResponseModel>> AssignedToDoTask(Guid id)
        {
            var assignedTasks = await _toDoTaskRepository.AssignedToDoTask(id);
            var response = new List<DTOs.ToDoTaskDTOs.AssignedToDoTaskDTOs.ResponseModel>();

            if (assignedTasks != null)
            {
                foreach (var task in assignedTasks)
                {
                    response.Add(new DTOs.ToDoTaskDTOs.AssignedToDoTaskDTOs.ResponseModel
                    {
                        ToDoTaskDate = task.ToDoTaskDate.Date,
                        CreatorUserName = task.CreatorUser.UserName,
                        AssignedUserName = task.AssignedUser.UserName,
                        AssignedDepartmentName = task.Department.DepartmentName,
                        ToDoTaskName = task.ToDoTaskName,
                        Status = task.Status
                    });
                }
                return response;
            }
            else
            {
                throw new Exception("There is no assigned task");
            }
        }

        public async Task<Guid> AssignedUser(Guid id)
        {
            var user = await _toDoTaskRepository.GetById(id);
            var assignedUser = user.AssignedUserId;

            return assignedUser;
        }

        public async Task<DTOs.ToDoTaskDTOs.CreateToDoTaskDTOs.ResponseModel> Create(DTOs.ToDoTaskDTOs.CreateToDoTaskDTOs.RequestModel request)
        {
            var currentUser = await _currentUser.GetCurrentUser();
            var task = new ToDoTask()
            {
                ToDoTaskName = request.ToDoTaskName,
                ToDoTaskDescription = request.ToDoTaskDescription,
                ToDoTaskDate = DateTime.Now.Date,
                AssignedUserId = request.AssignedUserId,
                CreatorUserId = currentUser.Id,
                DepartmentId = request.DepartmentId,
                Status = request.Status = 0,
            };

            await _toDoTaskRepository.Create(task);

            var response = new DTOs.ToDoTaskDTOs.CreateToDoTaskDTOs.ResponseModel()
            {
                Id = task.Id,
                ToDoTaskName = task.ToDoTaskName,
                ToDoTaskDescription = task.ToDoTaskDescription,
                ToDoTaskDate = task.ToDoTaskDate.Date,
                AssignedUserId = task.AssignedUserId,
                CreatorUserId = task.CreatorUserId,
                DepartmentId = task.DepartmentId,
                Status = task.Status
            };

            return response;
        }

        public async Task<Guid> CreatorUser(Guid id)
        {
            var task = await _toDoTaskRepository.GetById(id);
            var creatorUser = task.CreatorUserId;

            return creatorUser;
        }

        public async Task<DTOs.ToDoTaskDTOs.DeleteToDoTaskDTOs.ResponseModel> Delete(DTOs.ToDoTaskDTOs.DeleteToDoTaskDTOs.RequestModel request)
        {
            var task = await _toDoTaskRepository.GetById(request.Id);
            var response = new DTOs.ToDoTaskDTOs.DeleteToDoTaskDTOs.ResponseModel();

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

        public async Task<DTOs.ToDoTaskDTOs.GetByIdToDoTaskDTOs.ResponseModel> GetById(Guid id)
        {
            var task = await _toDoTaskRepository.GetById(id);

            if (task != null)
            {
                var response = new DTOs.ToDoTaskDTOs.GetByIdToDoTaskDTOs.ResponseModel
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

        public async Task<DTOs.ToDoTaskDTOs.UpdateToDoTaskDTOs.ResponseModel> Update(DTOs.ToDoTaskDTOs.UpdateToDoTaskDTOs.RequestModel request)
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

                var response = new DTOs.ToDoTaskDTOs.UpdateToDoTaskDTOs.ResponseModel
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

        public async Task<DTOs.ToDoTaskDTOs.UpdateStatusToDoTaskDTOs.ResponseModel> UpdateStatus(DTOs.ToDoTaskDTOs.UpdateStatusToDoTaskDTOs.RequestModel request)
        {
            var task = await _toDoTaskRepository.GetById(request.Id);

            if (task != null)
            {
                task.Status = request.Status;

                await _toDoTaskRepository.Update(task);

                var response = new DTOs.ToDoTaskDTOs.UpdateStatusToDoTaskDTOs.ResponseModel
                {
                    Id = task.Id,
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
