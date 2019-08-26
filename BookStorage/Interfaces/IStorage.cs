using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookStorage.Interfaces
{
    interface IStorage<T>
    {
        /// <summary>
        /// read from some storage
        /// </summary>
        /// <returns>list of objects</returns>
        List<T> Read();
        /// <summary>
        /// write all objects in some storege
        /// </summary>
        /// <param name="obj">list of some objects what need to write</param>
        void Write(List<T> obj);
        /// <summary>
        /// write one object in some storage in last position
        /// </summary>
        /// <param name="book">some object what need to write</param>
        void AppendToFile(T book);
    }
}
