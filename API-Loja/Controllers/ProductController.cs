using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Loja.Models;

namespace API_Loja.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        public string Get()
        {
            lojaEntities loja = new lojaEntities();
            var teste = loja.Product.First().nameProduct;

            return teste;
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
