using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.DomainServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<ResponseModel>> All()
        {
            var departments = await _departmentRepository.All();
            var response = new List<ResponseModel>();

            if (departments != null)
            {
                foreach (var department in departments)
                {
                    response.Add(new ResponseModel
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

        public async Task<DTOs.DepartmentDTOs.CreateDepartmentDTOs.ResponseModel> Create(DTOs.DepartmentDTOs.CreateDepartmentDTOs.RequestModel request)
        {
            var department = new Department()
            {
                DepartmentName = request.DepartmentName,
            };

            await _departmentRepository.Create(department);

            var response = new DTOs.DepartmentDTOs.CreateDepartmentDTOs.ResponseModel()
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
            };

            return response;
        }

        public async Task<DeleteDepartmentResponseDTO> Delete(GetDepartmentIdRequestDTO request)
        {
            var department = await _departmentRepository.GetById(request.Id);
            var response = new DeleteDepartmentResponseDTO();

            if (department != null)
            {
                await _departmentRepository.Delete(department);

                response.IsDeleted = true;
                response.Message = "Department deleted";
            }
            else
            {
                response.IsDeleted = false;
                response.Message = "Department could not be deleted";
            }

            return response;
        }

        public async Task<ResponseModel> GetById(Guid id)
        {
            var department = await _departmentRepository.GetById(id);

            if (department != null)
            {
                var response = new ResponseModel()
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

        public async Task<ResponseModel> Update(UpdateDepartmentRequestDTO request)
        {
            var department = await _departmentRepository.GetById(request.Id);

            if (department != null)
            {
                department.DepartmentName = request.DepartmentName;
                await _departmentRepository.Update(department);

                var response = new ResponseModel()
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