using MyWebApi.Models;

namespace MyWebApi.RepositoryContracts
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(int id, string name);
        Task<bool> DeleteDepartment(int id);
    }
}
