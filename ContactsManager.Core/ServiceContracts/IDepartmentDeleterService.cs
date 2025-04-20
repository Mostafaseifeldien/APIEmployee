using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Core.ServiceContracts
{
    public interface IDepartmentDeleterService
    {
        Task<bool> DeleteDepartment(int id);
    }
}
