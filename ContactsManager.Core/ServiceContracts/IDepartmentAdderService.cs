
using MyWebApi.Models;

namespace ContactsManager.Core.ServiceContracts
{
    public interface IDepartmentAdderService
    {
        Task<Department> AddDepartment(Department department);
    }
}
