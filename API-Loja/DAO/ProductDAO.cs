using System.Collections.Generic;
using System.Linq;
using API_Loja.Models;

namespace API_Loja.DAO
{
    public class ProductDAO : ILojaDAO<Product>
    {
        public lojaEntities Loja { get; set; }

        public ProductDAO()
        {
            Loja = new lojaEntities();
        }

        public IEnumerable<object> Get()
        {
            return Loja.Product
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
            return Loja.Product.Where(p => p.idProduct == id)
                .Select(p => new {
                    p.idProduct,
                    p.nameProduct,
                    p.descriptionProduct,
                    p.priceProduct,
                    p.discountProduct,
                    p.activeProduct,
                    p.amountProduct,
                    p.imageProduct,
                    p.idCategory,
                    p.idManagement
                });
        }

        public void Add(Product product)
        {
            Loja.Product.Add(product);
            Loja.SaveChanges();
            Loja.Dispose();
        }

        public void Update(Product product)
        {
            Product oldProduct = Loja.Product.Where(p => p.idProduct == product.idProduct).First();
            Loja.Entry(oldProduct).CurrentValues.SetValues(product);
            Loja.SaveChanges();
            Loja.Dispose();
        }

        public void Delete(int id)
        {
            Product product = Loja.Product.Where(p => p.idProduct == id).First();
            Loja.Product.Remove(product);
            Loja.SaveChanges();
            Loja.Dispose();
        }
    }
}