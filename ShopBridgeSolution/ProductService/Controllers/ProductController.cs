using ProductDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProductService.Controllers
{
    public class ProductController : ApiController
    {
        public async Task<IEnumerable<Product>> Get()
        {
            using (ShopBridgeEntities entities = new ShopBridgeEntities())
            {
                List<Product> products = await entities.Products.ToListAsync();
                return products;
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (ShopBridgeEntities entities = new ShopBridgeEntities())
            {
                var entity = entities.Products.FirstOrDefault(p => p.ProductID == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with Id = " + id.ToString() + " not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Product product)
        {
            try
            {
                using (ShopBridgeEntities entities = new ShopBridgeEntities())
                {
                    entities.Products.Add(product);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, product);
                    message.Headers.Location = new Uri(Request.RequestUri + product.ProductID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                using (ShopBridgeEntities entities = new ShopBridgeEntities())
                {
                    var entity = entities.Products.FirstOrDefault(p => p.ProductID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with Id =" + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Products.Remove(entity);
                        await entities.SaveChangesAsync();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}