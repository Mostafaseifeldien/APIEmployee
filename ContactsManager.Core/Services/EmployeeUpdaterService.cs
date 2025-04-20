using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsManager.Core.ServiceContracts;
using MyWebApi.Models;
using MyWebApi.RepositoryContracts;

namespace ContactsManager.Core.Services
{
    public class EmployeeUpdaterService : IEmployeeUpdaterService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeUpdaterService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> UpdateEmployee(int id, string name, int departmentid)
        {
           Employee employee = await _employeeRepository.UpdateEmployee(id, name, departmentid);
           return employee;
        }
    }
}
