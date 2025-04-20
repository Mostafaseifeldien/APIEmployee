using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Core.ServiceContracts
{
    public interface IEmployeeDeleterService
    {
        Task<bool> DeleteEmployee(int id);
    }
}
