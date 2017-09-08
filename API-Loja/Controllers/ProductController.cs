using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Loja.Models;
using API_Loja.DAO;

namespace API_Loja.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("Api/Product")]
        public HttpResponseMessage Get()
        {
            try
            {
                ProductDAO productDAO = new ProductDAO();
                var products = productDAO.Get();
                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("Api/Product/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                ProductDAO productDAO = new ProductDAO();
                var products = productDAO.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Product of id {id} not found");
            }
        }

        [HttpPost]
        [Route("Api/Product/{product}")]
        public HttpResponseMessage Post([FromBody]Product product)
        {
            try
            {
                ProductDAO productDAO = new ProductDAO();
                productDAO.Add(product);
                return Request.CreateResponse(HttpStatusCode.OK, $"{product.nameProduct} added successfully");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        [Route("Api/Product/{product}")]
        public HttpResponseMessage Put([FromBody]Product product)
        {
            try
            {
                ProductDAO productDAO = new ProductDAO();
                productDAO.Update(product);
                return Request.CreateResponse(HttpStatusCode.OK, $"{product.nameProduct} updated successfully");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("Api/Product/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ProductDAO productDAO = new ProductDAO();
                productDAO.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
