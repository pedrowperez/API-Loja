using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API_Loja.Models;

namespace API_Loja.DAO
{
    public class ProductDAO
    {
        public lojaEntities loja { get; set; }

        public ProductDAO()
        {
            loja = new lojaEntities();
        }

        public IEnumerable<object> Get()
        {
            return loja.Product
                .Select(p => new {
                    p.idProduct,
                    p.nameProduct,
                    p.descriptionProduct,
                    p.priceProduct,
                    p.discountProduct,
                    p.activeProduct,
                    p.amountProduct,
                    p.Category.nameCategory,
                    p.Management.nameManagement
                });
        }

        public IEnumerable<object> Get(int id)
        {
            return loja.Product.Where(p => p.idProduct == id)
                .Select(p => new {
                    p.idProduct,
                    p.nameProduct,
                    p.descriptionProduct,
                    p.priceProduct,
                    p.discountProduct,
                    p.activeProduct,
                    p.amountProduct,
                    p.Category.nameCategory,
                    p.Management.nameManagement
                });
        }

        public void Add(Product product)
        {
            loja.Product.Add(product);
            loja.SaveChanges();
            loja.Dispose();
        }

        public void Update(Product product)
        {
            Product oldProduct = loja.Product.Where(p => p.idProduct == product.idProduct).First();
            loja.Entry(oldProduct).CurrentValues.SetValues(product);
            loja.SaveChanges();
            loja.Dispose();
        }

        public void Delete(int id)
        {
            Product product = loja.Product.Where(p => p.idProduct == id).First();
            loja.Product.Remove(product);
            loja.SaveChanges();
            loja.Dispose();
        }
    }
}