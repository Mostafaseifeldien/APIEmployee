using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsManager.Core.ServiceContracts;
using MyWebApi.RepositoryContracts;

namespace ContactsManager.Core.Services
{
    public class EmployeeDeleterService : IEmployeeDeleterService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeDeleterService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            bool employee = await _employeeRepository.DeleteEmployee(id);
            return employee;
        }
    }
}
