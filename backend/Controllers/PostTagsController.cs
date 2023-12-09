using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTagsController : ControllerBase
    {
        private readonly CatalogDBContext _context;

        public PostTagsController(CatalogDBContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostTag>>> GetPostTag()
        {
            if (_context.Post == null)
            {
                return NotFound();
            }
            return await _context.PostTag!.Include(p => p.Post).Include(t => t.Tag).ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<PostTag> GetPostTag(int id)
        {

            var post = _context.PostTag!
                .Include(p => p.Post)
                .Include(t => t.Tag)
                .FirstOrDefault(pt => pt.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostTag(int id, PostTagCreateDTO postTagDTO)
        {
            if (id != postTagDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(postTagDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostTagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostTag>> PostTagPost(PostTagCreateDTO postTagDTO)
        {
            if (_context.PostTag == null)
            {
                return Problem("Entity set 'CatalogDBContext.PostTag' is null.");
            }

            // Map PostTagCreateDTO to PostTag
            var postTag = new PostTag
            {
                PostId = postTagDTO.PostId,
                TagId = postTagDTO.TagId
                // You can set other properties if needed
            };

            _context.PostTag.Add(postTag);
            await _context.SaveChangesAsync();

            // Return the created PostTag
            return CreatedAtAction("GetPostTag", new { id = postTag.Id }, postTag);
        }


        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostTag(int id)
        {
            if (_context.PostTag == null)
            {
                return NotFound();
            }
            var postTag = await _context.PostTag.FindAsync(id);
            if (postTag == null)
            {
                return NotFound();
            }

            _context.PostTag.Remove(postTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool PostTagExists(int id)
        {
            return (_context.PostTag?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
