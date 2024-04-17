using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.RelationalDb;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> All()
        {
            var departments = await _context.Departments.ToListAsync();

            return departments;
        }

        public async Task<Department> Create(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return department;
        }

        public async Task<Department> Delete(Department department)
        {
            var deletedDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Id == department.Id);

            _context.Remove(deletedDepartment);
            await _context.SaveChangesAsync();

            return deletedDepartment;
        }

        public async Task<Department> Detail(Guid id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);

            return department;
        }

        public async Task<Department> Update(Department department)
        {
            var updatedDepartment = await _context.Departments.FirstOrDefaultAsync(x=>x.Id == department.Id);

            _context.Departments.Update(updatedDepartment);
            await _context.SaveChangesAsync();

            return updatedDepartment;
        }
    }
}
