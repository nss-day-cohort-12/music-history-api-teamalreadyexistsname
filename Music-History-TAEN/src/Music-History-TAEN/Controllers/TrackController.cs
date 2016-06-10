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
    public class TrackController : Controller
    {

        private MusicHistoryContext _context;

        public TrackController(MusicHistoryContext context)
        {
            _context = context;
        }

        // GET: api/Track
        [HttpGet]
        public IActionResult Get([FromQuery]int? TrackId, [FromQuery]string TrackTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Track> Track = from i in _context.Track select i;

            if (TrackId != null)
            {
                Track = Track.Where(inv => inv.TrackId == TrackId);
            }

            if (Track == null)
            {
                return NotFound();
            }

            return Ok(Track);
        }

        // GET api/values/5
        [HttpGet("{id}", Name ="GetTrack")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Track track = _context.Track.Single(m => m.TrackId == id);

            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Track.Add(track);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrackExists(track.TrackId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTrack", new { id = track.TrackId }, track);
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Count(e => e.TrackId == id) > 0;
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
