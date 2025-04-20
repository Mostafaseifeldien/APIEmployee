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
    public class EmployeeGetterService : IEmployeeGetterService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeGetterService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public  IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> allemployee =  _employeeRepository.GetAllEmployee().ToList();
            return allemployee;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
           Employee employee = await _employeeRepository.GetEmployeeById(id);
          return employee;
        }
    }
}
