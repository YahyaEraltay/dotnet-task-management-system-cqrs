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
        Task<DepartmentResponseDTO> CreateDepartment(CreateDepartmentRequestDTO request);
        Task<DepartmentResponseDTO> UpdateDepartment(UpdateDepartmentRequestDTO request);
        Task<DeleteDepartmentResponseDTO> DeleteDepartment(GetDepartmentRequestDTO request);
        Task<DepartmentResponseDTO> Detail(GetDepartmentRequestDTO request);
        Task<List<DepartmentResponseDTO>> All();
    }
}
