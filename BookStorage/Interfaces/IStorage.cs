using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookStorage.Interfaces
{
    interface IStorage<T>
    {
        List<T> Read();
        void Write(List<T> obj);
        void AppendToFile(T book);
    }
}
