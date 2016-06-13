﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Music_History_TAEN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace Music_History_TAEN.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowDevEnvironment")]
    [Route("api/[controller]")]
    public class ArtistController : Controller
    {

        private MusicHistoryContext _context;

        public ArtistController(MusicHistoryContext context)
        {
            _context = context;
        }



        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery]int? ArtistId, [FromQuery]string ArtistName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Artist> Artist = from i in _context.Artist select i;

            if (ArtistId != null)
            {
                Artist = Artist.Where(inv => inv.ArtistId == ArtistId);
            }

            if (Artist == null)
            {
                return NotFound();
            }

            return Ok(Artist);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetARtist")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Artist artist = _context.Artist.Single(m => m.ArtistId == id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Artist.Add(artist);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ArtistExists(artist.ArtistId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetArtist", new { id = artist.ArtistId }, artist);
        }

        private bool ArtistExists(int id)
        {
            return _context.Artist.Count(e => e.ArtistId == id) > 0;
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            _context.Entry(artist).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Artist artist = _context.Artist.Single(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artist.Remove(artist);
            _context.SaveChanges();

            return Ok(artist);
        }
    }
}