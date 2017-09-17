using System.Collections.Generic;
using System.Linq;
using API_Loja.Models;

namespace API_Loja.DAO
{
    public class ProductDAO : ILojaDAO<Product>
    {
        public StoreEntities store { get; set; }

        public ProductDAO()
        {
            store = new StoreEntities();
        }

        public IEnumerable<object> Get()
        {
            return store.Product
                .Select(p => new {
                    p.idProduct,
                    p.nameProduct,
                    p.priceProduct,
                    p.discountProduct,
                    p.activeProduct,
                    p.amountProduct
                });
        }

        public IEnumerable<object> Get(int id)
        {
            return store.Product.Where(p => p.idProduct == id)
                .Select(p => new {
                    p.idProduct,
                    p.nameProduct,
                    p.descriptionProduct,
                    p.priceProduct,
                    p.discountProduct,
                    p.activeProduct,
                    p.amountProduct,
                    p.imageProduct,
                    p.idManagement
                });
        }

        public void Add(Product product)
        {
            store.Product.Add(product);
            store.SaveChanges();
            store.Dispose();
        }

        public void Update(Product product)
        {
            Product oldProduct = store.Product.Where(p => p.idProduct == product.idProduct).First();
            store.Entry(oldProduct).CurrentValues.SetValues(product);
            store.SaveChanges();
            store.Dispose();
        }

        public void Delete(int id)
        {
            Product product = store.Product.Where(p => p.idProduct == id).First();
            store.Product.Remove(product);
            store.SaveChanges();
            store.Dispose();
        }
    }
}