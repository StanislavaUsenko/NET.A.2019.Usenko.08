using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTask.Interfaces
{
    interface IRepository<T>
    {
        void Write(List<T> listObj);
        void AppendToEnd(T obj);
        List<T> Read();
    }
}
