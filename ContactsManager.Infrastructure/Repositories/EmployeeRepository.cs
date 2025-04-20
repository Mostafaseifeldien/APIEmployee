using Microsoft.EntityFrameworkCore;
using MyWebApi.DataAccess;
using MyWebApi.Models;
using MyWebApi.RepositoryContracts;

namespace MyWebApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _db.employees.Add(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            Employee? employee = await _db.employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee Not found");
            }
            _db.employees.Remove(employee);
            await _db.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            IQueryable<Employee> query = _db.employees.Include("Department");
            return query.ToList();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            IQueryable<Employee> query = _db.employees.Include("Department");
            query = query.Where(e => e.Id == id);
            Employee? employee = await query.FirstOrDefaultAsync();
            if (employee == null)
            {
                throw new Exception("Error");
            }
            return employee;
        }

        public async Task<Employee> UpdateEmployee(int id, string name, int departmentid)
        {
            Employee? employee =await GetEmployeeById(id);
            employee.Name = name;
            employee.DepartmentId = departmentid;
            _db.employees.Update(employee);
            await _db.SaveChangesAsync();
            Employee afterUpdate = await GetEmployeeById(id);
            return afterUpdate;
        }
    }
}
