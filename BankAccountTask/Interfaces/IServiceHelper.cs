using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTask.Interfaces
{
    interface IServiceHelper<T>
    {
            List<T> GetAll();
            T GetOne(int id);
    }
}
