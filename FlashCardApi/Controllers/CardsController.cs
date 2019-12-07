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
    [Route("api/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly FlashContext _context;

        public CardsController(FlashContext context)
        {
            _context = context;
        }

        // GET: api/FlashCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetFlashCards()
        {
            return await _context.FlashCards.ToListAsync();
        }

        // GET: api/FlashCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetFlashCard(long id)
        {
            var flashCard = await _context.FlashCards.FindAsync(id);

            if (flashCard == null)
            {
                return NotFound();
            }

            return flashCard;
        }

        // PUT: api/FlashCards/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlashCard(long id, Card flashCard)
        {
            if (id != flashCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(flashCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlashCardExists(id))
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

        // POST: api/FlashCards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Card>> PostFlashCard(Card flashCard)
        {
            _context.FlashCards.Add(flashCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlashCard), new { id = flashCard.Id }, flashCard);
        }

        // DELETE: api/FlashCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Card>> DeleteFlashCard(long id)
        {
            var flashCard = await _context.FlashCards.FindAsync(id);
            if (flashCard == null)
            {
                return NotFound();
            }

            _context.FlashCards.Remove(flashCard);
            await _context.SaveChangesAsync();

            return flashCard;
        }

        private bool FlashCardExists(long id)
        {
            return _context.FlashCards.Any(e => e.Id == id);
        }
    }
}
