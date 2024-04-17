using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.Infrastructure.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentResponseDTO> Create(CreateDepartmentRequestDTO request);
        Task<DepartmentResponseDTO> Update(UpdateDepartmentRequestDTO request);
        Task<DeleteDepartmentResponseDTO> Delete(GetDepartmentRequestDTO request);
        Task<DepartmentResponseDTO> Detail(GetDepartmentRequestDTO request);
        Task<List<DepartmentResponseDTO>> All();
    }
}
