using API_Loja.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_Loja.DAO
{
    public class ManagementDAO : ILojaDAO<Management>
    {
        public StoreEntities store { get; set; }

        public ManagementDAO()
        {
            store = new StoreEntities();
        }

        public void Add(Management management)
        {
            store.Management.Add(management);
            store.SaveChanges();
            store.Dispose();
        }

        public void Delete(int id)
        {
            Management management = store.Management.Where(m => m.idManagement == id).First();
            store.Management.Remove(management);
            store.SaveChanges();
            store.Dispose();
        }

        public IEnumerable<object> Get()
        {
            return store.Management
                .Select(m => new {
                    m.idManagement,
                    m.nameManagement
                });
        }

        public IEnumerable<object> Get(int id)
        {
            return store.Management.Where(m => m.idManagement == id)
                   .Select(m => new {
                       m.idManagement,
                       m.loginManagement,
                       m.nameManagement
                   });
        }

        public void Update(Management management)
        {
            Management oldManagement = store.Management.Where(m => m.idManagement == management.idManagement).First();
            store.Entry(oldManagement).CurrentValues.SetValues(management);
            store.SaveChanges();
            store.Dispose();
        }
    }
}