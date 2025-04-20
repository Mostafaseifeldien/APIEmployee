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
    public class EmployeeAdderService : IEmployeeAdderService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeAdderService(IEmployeeRepository employeeAdderService)
        {
            _employeeRepository = employeeAdderService;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            Employee employeee = await _employeeRepository.AddEmployee(employee);
            return employeee;
        }
    }
}
