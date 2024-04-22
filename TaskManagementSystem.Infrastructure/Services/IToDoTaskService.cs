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
        Task<DeleteToDoTaskResponseDTO> Delete(GetToDoTaskIdRequestDTO request);
        Task<GetToDoTaskResponseDTO> Detail(Guid id);
        Task<List<GetToDoTaskResponseDTO>> All();
    }
}
