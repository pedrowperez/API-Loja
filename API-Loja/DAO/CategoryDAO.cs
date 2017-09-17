using API_Loja.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_Loja.DAO
{
    public class CategoryDAO : ILojaDAO<Category>
    {
        public StoreEntities store { get; set; }

        public CategoryDAO()
        {
            store = new StoreEntities();
        }

        public IEnumerable<object> Get()
        {
            return store.Category
                .Select(c => new {
                    c.idCategory,
                    c.nameCategory
                });
        }

        public IEnumerable<object> Get(int id)
        {
            return store.Category.Where(c => c.idCategory == id)
                .Select(c => new {
                    c.idCategory,
                    c.nameCategory,
                    c.descriptionCateogira
                });
        }

        public void Add(Category category)
        {
            store.Category.Add(category);
            store.SaveChanges();
            store.Dispose();
        }

        public void Update(Category category)
        {
            Category oldCategory = store.Category.Where(c => c.idCategory == category.idCategory).First();
            store.Entry(oldCategory).CurrentValues.SetValues(category);
            store.SaveChanges();
            store.Dispose();
        }

        public void Delete(int id)
        {
            Category category = store.Category.Where(c => c.idCategory == id).First();
            store.Category.Remove(category);
            store.SaveChanges();
            store.Dispose();
        }
    }
}