using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore_API.Data;
using BookStore_API.Contracts;
using AutoMapper;
using BookStore_API.Models.Book;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Authorization;

namespace BookStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _booksRepository.GetAllAsync();
            return Ok(_mapper.Map<List<BookDto>>(books));
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _booksRepository.GetAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutBook(int id, BookDto bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }
            var book = await _booksRepository.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, book);

            try
            {
                await _booksRepository.UpdateAsync(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BookExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Book>> PostBook(CreateBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _booksRepository.AddAsync(book);
            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _booksRepository.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _booksRepository.DeleteAsync(book.Id);
            return NoContent();
        }

        private async Task<bool> BookExists(int id)
        {
            return await _booksRepository.Exists(id);
        }
        [HttpPut("purchase/{id}")]
        [Authorize]
        public async Task<IActionResult> PurchaseBook(int id)
        {
            var isPurchaseSuccess = await _booksRepository.PurchaseBookAsync(id);
            if (!isPurchaseSuccess)
            {
                var badResult = new BadRequestObjectResult(new { message = "400 Bad Request - purchase unsucessful", currentDate = DateTime.Now });
                return badResult;
            }
            var result = new OkObjectResult(new { message = "200 Ok Purchase Successful", currentDate = DateTime.Now });
            return result;
        }
    }
}
