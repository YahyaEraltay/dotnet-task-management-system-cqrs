using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentResponseDTO>> All()
        {
            var departments = await _departmentRepository.All();
            var response = new List<DepartmentResponseDTO>();

            if (departments != null)
            {
                foreach (var department in departments)
                {
                    response.Add(new DepartmentResponseDTO
                    {
                        Id = department.Id,
                        DepartmentName = department.DepartmentName
                    });
                }
                return response;
            }
            else
            {
                throw new Exception("There is no department");
            }
        }

        public async Task<DepartmentResponseDTO> Create(CreateDepartmentRequestDTO request)
        {
            var department = new Department()
            {
                DepartmentName = request.DepartmentName,
            };

            await _departmentRepository.Create(department);

            var response = new DepartmentResponseDTO()
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
            };

            return response;
        }

        public async Task<DeleteDepartmentResponseDTO> Delete(GetDepartmentIdRequestDTO request)
        {
            var department = await _departmentRepository.Detail(request.Id);
            var response = new DeleteDepartmentResponseDTO();

            if (department != null)
            {
                await _departmentRepository.Delete(department);

                response.IsDeleted = true;
                response.Message = "Department is deleted";
            }
            else
            {
                response.IsDeleted = false;
                response.Message = "Department could not be deleted";
            }

            return response;
        }

        public async Task<DepartmentResponseDTO> Detail(GetDepartmentIdRequestDTO request)
        {
            var department = await _departmentRepository.Detail(request.Id);

            if (department != null)
            {
                var response = new DepartmentResponseDTO()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName,
                };
                return response;
            }
            else
            {
                throw new Exception("Department could not be find");
            }
        }

        public async Task<DepartmentResponseDTO> Update(UpdateDepartmentRequestDTO request)
        {
            var department = await _departmentRepository.Detail(request.Id);

            if (department != null)
            {
                department.DepartmentName = request.DepartmentName;
                await _departmentRepository.Update(department);

                var response = new DepartmentResponseDTO()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName,
                };

                return response;
            }
            else
            {
                throw new Exception("Department could not be updated");
            }
        }
    }
}