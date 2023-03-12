using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_gyakorlat.Models;
using WebApi_gyakorlat.Models.ViewModel;
using WebApi_gyakorlat.Services;

namespace WebApi_gyakorlat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        //// GET: api/Books/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Book>> GetBook(string id)
        //{
        //  if (_context.Books == null)
        //  {
        //      return NotFound();
        //  }
        //    var book = await _context.Books.FindAsync(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        //// PUT: api/Books/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBook(string id, Book book)
        //{
        //    if (id != book.BookId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookView bookView)
        {
            try
            {
                await _bookService.CreateBookAsync(bookView);
            }
            catch (InvalidDataException e)
            {

                return BadRequest(e.Message);
            }
            return Ok("A mentés sikeres!");
        }

        //// DELETE: api/Books/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBook(string id)
        //{
        //    if (_context.Books == null)
        //    {
        //        return NotFound();
        //    }
        //    var book = await _context.Books.FindAsync(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Books.Remove(book);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BookExists(string id)
        //{
        //    return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        //}
    }
}
