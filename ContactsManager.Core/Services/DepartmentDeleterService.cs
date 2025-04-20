using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsManager.Core.ServiceContracts;
using MyWebApi.RepositoryContracts;

namespace ContactsManager.Core.Services
{
    public class DepartmentDeleterService : IDepartmentDeleterService
    {
        private readonly IDepartmentRepository _idepartmentRepository;
        public DepartmentDeleterService(IDepartmentRepository idepartmentRepository)
        {
            _idepartmentRepository = idepartmentRepository;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            bool department = await _idepartmentRepository.DeleteDepartment(id);
            return department;
        }
    }
}
