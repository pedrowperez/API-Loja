using API_Loja.Models;
using System.Collections.Generic;

namespace API_Loja.DAO
{
    interface ILojaDAO<T>
    {
        StoreEntities store { get; set; }
        IEnumerable<object> Get();
        IEnumerable<object> Get(int id);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
