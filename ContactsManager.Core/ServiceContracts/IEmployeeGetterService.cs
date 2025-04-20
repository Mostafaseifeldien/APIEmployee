using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebApi.Models;

namespace ContactsManager.Core.ServiceContracts
{
    public interface IEmployeeGetterService
    {
        IEnumerable<Employee> GetAllEmployee();
        Task<Employee> GetEmployeeById(int id);
    }
}
