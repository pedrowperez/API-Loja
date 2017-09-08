using API_Loja.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_Loja.DAO
{
    public class ManagementDAO : ILojaDAO<Management>
    {
        public lojaEntities Loja { get; set; }

        public ManagementDAO()
        {
            Loja = new lojaEntities();
        }

        public void Add(Management management)
        {
            Loja.Management.Add(management);
            Loja.SaveChanges();
            Loja.Dispose();
        }

        public void Delete(int id)
        {
            Management management = Loja.Management.Where(m => m.idManagement == id).First();
            Loja.Management.Remove(management);
            Loja.SaveChanges();
            Loja.Dispose();
        }

        public IEnumerable<object> Get()
        {
            return Loja.Management
                .Select(m => new {
                    m.idManagement,
                    m.nameManagement
                });
        }

        public IEnumerable<object> Get(int id)
        {
            return Loja.Management.Where(m => m.idManagement == id)
                   .Select(m => new {
                       m.idManagement,
                       m.loginManagement,
                       m.nameManagement
                   });
        }

        public void Update(Management management)
        {
            Management oldManagement = Loja.Management.Where(m => m.idManagement == management.idManagement).First();
            Loja.Entry(oldManagement).CurrentValues.SetValues(management);
            Loja.SaveChanges();
            Loja.Dispose();
        }
    }
}