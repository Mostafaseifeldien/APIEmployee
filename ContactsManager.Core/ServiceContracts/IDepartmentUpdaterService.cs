

using MyWebApi.Models;

namespace ContactsManager.Core.ServiceContracts
{
    public interface IDepartmentUpdaterService
    {
        Task<Department> UpdateDepartment(int id, string name);
    }
}
