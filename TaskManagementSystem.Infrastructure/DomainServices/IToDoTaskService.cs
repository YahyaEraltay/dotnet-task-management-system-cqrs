namespace TaskManagementSystem.Infrastructure.DomainServices
{
    public interface IToDoTaskService
    {
        Task<DTOs.ToDoTaskDTOs.CreateToDoTaskDTOs.ResponseModel> Create(DTOs.ToDoTaskDTOs.CreateToDoTaskDTOs.RequestModel request);
        Task<DTOs.ToDoTaskDTOs.UpdateToDoTaskDTOs.ResponseModel> Update(DTOs.ToDoTaskDTOs.UpdateToDoTaskDTOs.RequestModel request);
        Task<DTOs.ToDoTaskDTOs.DeleteToDoTaskDTOs.ResponseModel> Delete(DTOs.ToDoTaskDTOs.DeleteToDoTaskDTOs.RequestModel request);
        Task<DTOs.ToDoTaskDTOs.GetByIdToDoTaskDTOs.ResponseModel> GetById(Guid id);
        Task<List<DTOs.ToDoTaskDTOs.AllToDoTaskDTOs.ResponseModel>> All();
        Task<List<DTOs.ToDoTaskDTOs.AssignedToDoTaskDTOs.ResponseModel>> AssignedToDoTask(Guid id);
        Task<Guid> CreatorUser(Guid id);
        Task<Guid> AssignedUser(Guid id);
        Task<DTOs.ToDoTaskDTOs.UpdateStatusToDoTaskDTOs.ResponseModel> UpdateStatus(DTOs.ToDoTaskDTOs.UpdateStatusToDoTaskDTOs.RequestModel request);
    }
}
