using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.Infrastructure.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentResponseDTO> Create(CreateDepartmentRequestDTO request);
        Task<DepartmentResponseDTO> Update(UpdateDepartmentRequestDTO request);
        Task<DeleteDepartmentResponseDTO> Delete(Guid id);
        Task<DepartmentResponseDTO> Detail(Guid id);
        Task<List<DepartmentResponseDTO>> All();
    }
}
