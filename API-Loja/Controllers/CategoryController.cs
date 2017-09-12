using API_Loja.DAO;
using API_Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Loja.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("Api/Category")]
        public HttpResponseMessage Get()
        {
            try
            {
                CategoryDAO categoryDAO = new CategoryDAO();
                var categorys = categoryDAO.Get();
                return Request.CreateResponse(HttpStatusCode.OK, categorys);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("Api/Category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                CategoryDAO categoryDAO = new CategoryDAO();
                var categorys = categoryDAO.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, categorys);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Product of id {id} not found");
            }
        }

        [HttpPost]
        [Route("Api/Category/{category}")]
        public HttpResponseMessage Post([FromBody]Category category)
        {
            try
            {
                CategoryDAO categoryDAO = new CategoryDAO();
                categoryDAO.Add(category);
                return Request.CreateResponse(HttpStatusCode.OK, $"{category.nameCategory} added successfully");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        [Route("Api/Category/{category}")]
        public HttpResponseMessage Put([FromBody]Category category)
        {
            try
            {
                CategoryDAO categoryDAO = new CategoryDAO();
                categoryDAO.Update(category);
                return Request.CreateResponse(HttpStatusCode.OK, $"{category.nameCategory} updated successfully");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("Api/Category/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                CategoryDAO productDAO = new CategoryDAO();
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