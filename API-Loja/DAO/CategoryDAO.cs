using API_Loja.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_Loja.DAO
{
    public class CategoryDAO : ILojaDAO<Category>
    {
        public lojaEntities Loja { get; set; }

        public CategoryDAO()
        {
            Loja = new lojaEntities();
        }

        public IEnumerable<object> Get()
        {
            return Loja.Category
                .Select(c => new {
                    c.idCategory,
                    c.nameCategory
                });
        }

        public IEnumerable<object> Get(int id)
        {
            return Loja.Category.Where(c => c.idCategory == id)
                .Select(c => new {
                    c.idCategory,
                    c.nameCategory,
                    c.descriptionCateogira
                });
        }

        public void Add(Category category)
        {
            Loja.Category.Add(category);
            Loja.SaveChanges();
            Loja.Dispose();
        }

        public void Update(Category category)
        {
            Category oldCategory = Loja.Category.Where(c => c.idCategory == category.idCategory).First();
            Loja.Entry(oldCategory).CurrentValues.SetValues(category);
            Loja.SaveChanges();
            Loja.Dispose();
        }

        public void Delete(int id)
        {
            Category category = Loja.Category.Where(c => c.idCategory == id).First();
            Loja.Category.Remove(category);
            Loja.SaveChanges();
            Loja.Dispose();
        }
    }
}