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
    public class DepartmentAdderService : IDepartmentAdderService
    {
        private readonly IDepartmentRepository _iDepartmentRepository;
        public DepartmentAdderService(IDepartmentRepository departmentrepository)
        {
            _iDepartmentRepository = departmentrepository;
        }
        public async Task<Department> AddDepartment(Department department)
        {
           Department departmentt = await _iDepartmentRepository.AddDepartment(department);
           return department;
        }
    }
}
