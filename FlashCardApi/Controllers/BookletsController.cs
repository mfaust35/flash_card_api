using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlashCardApi.Models;

namespace FlashCardApi.Controllers
{
    [Route("api/booklets")]
    [ApiController]
    public class BookletsController : ControllerBase
    {
        private readonly FlashContext _context;

        public BookletsController(FlashContext context)
        {
            _context = context;
        }

        // GET: api/Booklets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booklet>>> GetBooklet()
        {
            return await _context.Booklets.Include(b => b.Cards)
                                          .ToListAsync();
        }

        // GET: api/Booklets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booklet>> GetBooklet(long id)
        {
            var booklet = await _context.Booklets.Include(b => b.Cards)
                                                 .FirstOrDefaultAsync(b => b.BookletId == id);

            if (booklet == null)
            {
                return NotFound();
            }

            return booklet;
        }

        // PUT: api/Booklets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooklet(long id, Booklet booklet)
        {
            if (id != booklet.BookletId)
            {
                return BadRequest();
            }

            _context.Entry(booklet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookletExists(id))
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

        // POST: api/Booklets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Booklet>> PostBooklet(Booklet booklet)
        {
            _context.Booklets.Add(booklet);
            await _context.SaveChangesAsync();

            _context.Entry(booklet)
                    .Collection(b => b.Cards)
                    .Load();

            return CreatedAtAction("GetBooklet", new { id = booklet.BookletId }, booklet);
        }

        // DELETE: api/Booklets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booklet>> DeleteBooklet(long id)
        {
            var booklet = await _context.Booklets.FindAsync(id);
            if (booklet == null)
            {
                return NotFound();
            }

            _context.Booklets.Remove(booklet);
            await _context.SaveChangesAsync();

            return booklet;
        }

        private bool BookletExists(long id)
        {
            return _context.Booklets.Any(e => e.BookletId == id);
        }
    }
}
