using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL.BusinessObjects;

namespace CustomerRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/Genre
        [HttpGet]
        public IEnumerable<GenreBO> Get()
        {
            return facade.GenreService.GetAll();
        }

        // GET: api/Genre/5
        [HttpGet("{id}", Name = "GetGenre")]
        public GenreBO Get(int id)
        {
            return facade.GenreService.Get(id);
        }

        // POST: api/Genre
        [HttpPost]
        public IActionResult Post([FromBody]GenreBO genre)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.GenreService.Create(genre));
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GenreBO genre)
        {
            if (id != genre.Id)
            {
                return BadRequest("Path Id does not match the Genre Id");
            }
            try
            {
                var genreUpdated = facade.GenreService.Update(genre);
                return Ok(genreUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.GenreService.Delete(id);
        }
    }
}
