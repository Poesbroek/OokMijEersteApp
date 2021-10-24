using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OokMijnEersteApp
{
    interface IDataStore<T>
    {
        Task<bool> CreateItem(T item);
        Task<T> ReadItem();
        Task<bool> UpdateItem(T item);
        Task<bool> DeleteItem(T item);


    }
}
