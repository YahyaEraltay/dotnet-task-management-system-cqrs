using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel;

namespace TaskManagementSystem.Infrastructure.Services
{
    public interface IToDoTaskService
    {
        Task<CreateToDoTaskResponseDTO> Create(CreateToDoTaskRequestDTO request);
        Task<UpdateToDoTaskResponseDTO> Update(UpdateToDoTaskRequestDTO request);
        Task<DeleteToDoTaskResponseDTO> Delete(DeleteToDoTaskRequestDTO request);
        Task<GetToDoTaskResponseDTO> GetById(Guid id);
        Task<List<GetToDoTaskResponseDTO>> All();
        Task<List<AssignedTasksResponseDTO>> AssignedTasks(Guid id);
        Task<Guid> CreatorUser(Guid id);
        Task<Guid> AssignedUser(Guid id);
        Task<UpdateToDoTaskResponseDTO> UpdateStatus(UpdateToDoTaskRequestDTO request);
    }
}
