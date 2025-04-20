using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebApi.Models;

namespace ContactsManager.Core.ServiceContracts
{
    public interface IDepartmentGetterService
    {
        IEnumerable<Department> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
    }
}
