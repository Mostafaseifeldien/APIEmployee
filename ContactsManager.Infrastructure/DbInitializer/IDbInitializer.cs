using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Infrastructure.DbInitializer
{
    public interface IDbInitializer
    {
        void Initialize();
    }
}
