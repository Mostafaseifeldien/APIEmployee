using MyWebApi.Models;

namespace MyWebApi.RepositoryContracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id, string name, int departmentid);
        Task<bool> DeleteEmployee(int id);
    }
}
