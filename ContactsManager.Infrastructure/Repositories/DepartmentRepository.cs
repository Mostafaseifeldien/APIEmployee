using Microsoft.EntityFrameworkCore;
using MyWebApi.DataAccess;
using MyWebApi.Models;
using MyWebApi.RepositoryContracts;

namespace MyWebApi.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            _db.departments.Add(department);
            await _db.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            Department? department = await _db.departments.FirstOrDefaultAsync(e => e.Id == id);
            if (department == null)
            {
                throw new Exception("Department Not found");
            }
            _db.departments.Remove(department);
            await _db.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            IQueryable<Department> query = _db.departments;
            return query.ToList();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            Department? department = await _db.departments.FindAsync(id);
            if (department == null)
            {
                throw new Exception($"Department with id {id} not found");
            }
            return department;
        }

        public async Task<Department> UpdateDepartment(int id, string name)
        {
            Department? department = await _db.departments.FirstOrDefaultAsync(e => e.Id == id);
            if (department == null)
            {
                throw new Exception("Department Not found");
            }
            department.Name = name;
            _db.departments.Update(department);
            await _db.SaveChangesAsync();
            return department;
        }
    }
}
