using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> Create(Department department);
        Task<Department> Update(Department department);
        Task<Department> Delete(Department department);
        Task<Department> Detail(Guid id);
        Task<List<Department>> All();
    }
}
