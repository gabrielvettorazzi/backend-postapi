using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using forumApi.Models;

namespace forumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PostItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostItem>>> GetPostItem()
        {
            return await _context.PostItem.ToListAsync();
        }

        // GET: api/PostItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostItem>> GetPostItem(long id)
        {
            var postItem = await _context.PostItem.FindAsync(id);

            if (postItem == null)
            {
                return NotFound();
            }

            return postItem;
        }

        // PUT: api/PostItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostItem(long id, PostItem postItem)
        {
            if (id != postItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(postItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostItemExists(id))
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

        // POST: api/PostItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostItem>> PostPostItem(PostItem postItem)
        {
            _context.PostItem.Add(postItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostItem", new { id = postItem.Id }, postItem);
        }

        // DELETE: api/PostItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostItem(long id)
        {
            var postItem = await _context.PostItem.FindAsync(id);
            if (postItem == null)
            {
                return NotFound();
            }

            _context.PostItem.Remove(postItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostItemExists(long id)
        {
            return _context.PostItem.Any(e => e.Id == id);
        }
    }
}
