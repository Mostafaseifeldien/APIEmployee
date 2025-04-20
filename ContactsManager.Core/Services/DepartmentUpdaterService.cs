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
    public class DepartmentUpdaterService:IDepartmentUpdaterService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentUpdaterService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> UpdateDepartment(int id, string name)
        {
            Department department = await _departmentRepository.UpdateDepartment(id, name);
            return department;
        }
    }
}
