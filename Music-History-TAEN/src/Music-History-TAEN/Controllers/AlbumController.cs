using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Music_History_TAEN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Music_History_TAEN.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowDevEnvironment")]
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {

        private MusicHistoryContext _context;

        public AlbumController(MusicHistoryContext context)
        {
            _context = context;
        }


        // GET: api/values
        // GET: api/Track
        [HttpGet]
        public IActionResult Get([FromQuery]int? AlbumId, [FromQuery]string AlbumTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Album> Album = from i in _context.Album select i;

            if (AlbumId != null)
            {
                Album = Album.Where(inv => inv.AlbumId == AlbumId);
            }

            if (Album == null)
            {
                return NotFound();
            }

            return Ok(Album);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetAlbum")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Album album = _context.Album.Single(m => m.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Album.Add(album);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AlbumExists(album.AlbumId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetAlbum", new { id = album.AlbumId }, album);
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Count(e => e.AlbumId == id) > 0;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
