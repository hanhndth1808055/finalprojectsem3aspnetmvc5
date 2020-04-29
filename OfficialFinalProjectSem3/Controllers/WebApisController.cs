using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OfficialFinalProjectSem3.Data;
using OfficialFinalProjectSem3.Models;

namespace OfficialFinalProjectSem3.Controllers
{
    public class WebApisController : ApiController
    {
        private MyDBContext db = new MyDBContext();

        // GET: api/WebApis
        public IQueryable<WebApiDto> GetWebApis()
        {
            return db.WebApis.Select(p => new WebApiDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name
            });
        }

        // GET: api/WebApis/5
        [ResponseType(typeof(WebApi))]
        public async Task<IHttpActionResult> GetWebApi(int id)
        {
            WebApiDetailDto webapi = await db.WebApis.Include(p => p.Category).Select(p => new WebApiDetailDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category.Name

            }).SingleOrDefaultAsync(p => p.Id == id);
            if (webapi == null)
            {
                return NotFound();
            }

            return Ok(webapi);
        }

        // PUT: api/WebApis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWebApi(int id, WebApi webApi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != webApi.Id)
            {
                return BadRequest();
            }

            db.Entry(webApi).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebApiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WebApis
        [ResponseType(typeof(WebApi))]
        public async Task<IHttpActionResult> PostWebApi(WebApi webApi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WebApis.Add(webApi);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = webApi.Id }, webApi);
        }

        // DELETE: api/WebApis/5
        [ResponseType(typeof(WebApi))]
        public async Task<IHttpActionResult> DeleteWebApi(int id)
        {
            WebApi webApi = await db.WebApis.FindAsync(id);
            if (webApi == null)
            {
                return NotFound();
            }

            db.WebApis.Remove(webApi);
            await db.SaveChangesAsync();

            return Ok(webApi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WebApiExists(int id)
        {
            return db.WebApis.Count(e => e.Id == id) > 0;
        }
    }
}