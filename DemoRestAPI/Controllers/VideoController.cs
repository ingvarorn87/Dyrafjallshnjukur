﻿using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomerRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Video
        [HttpGet]
        public IEnumerable<VideoBO> Get()
        {
            return facade.VideoService.GetAll();
        }

        // GET: api/Video/5
        [HttpGet("{id}", Name = "Get")]
        public VideoBO Get(int id)
        {
            return facade.VideoService.Get(id);
        }

        // POST: api/Video
        [HttpPost]
        public IActionResult Post([FromBody]VideoBO vid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.VideoService.Create(vid));
        }

        // PUT: api/Video/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]VideoBO vid)
        {
            if (id != vid.Id)
            {
                return BadRequest("Path ID does not match video ID in json object");
            }

            try
            {
                return Ok(facade.VideoService.Update(vid));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(facade.VideoService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
            
        }
    }
}
