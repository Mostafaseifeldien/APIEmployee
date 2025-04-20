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
    public class DepartmentGetterService : IDepartmentGetterService
    {
        private readonly IDepartmentRepository _idepartmentRepositroy;
        public DepartmentGetterService(IDepartmentRepository idepartmentRepositroy)
        {
            _idepartmentRepositroy = idepartmentRepositroy;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> allDepartment = _idepartmentRepositroy.GetAllDepartments().ToList();
            return allDepartment;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            Department department = await _idepartmentRepositroy.GetDepartmentById(id);
            return department;
        }
    }
}
