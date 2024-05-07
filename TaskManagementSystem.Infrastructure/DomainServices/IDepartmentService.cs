using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.Infrastructure.DomainServices
{
    public interface IDepartmentService
    {
        Task<DTOs.DepartmentDTOs.CreateDepartmentDTOs.ResponseModel> Create(DTOs.DepartmentDTOs.CreateDepartmentDTOs.RequestModel request);
        Task<ResponseModel> Update(UpdateDepartmentRequestDTO request);
        Task<DeleteDepartmentResponseDTO> Delete(GetDepartmentIdRequestDTO request);
        Task<ResponseModel> GetById(Guid id);
        Task<List<ResponseModel>> All();
    }
}
