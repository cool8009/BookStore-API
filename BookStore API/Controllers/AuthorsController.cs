using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore_API.Data;
using BookStore_API.Models.Author;
using AutoMapper;
using BookStore_API.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace BookStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
    
        private readonly IMapper _mapper;
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsController(IMapper mapper, IAuthorsRepository authorsRepository)
        {
            _mapper = mapper;
            _authorsRepository = authorsRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAuthorDto>>> GetAuthors()
        {
            var authors = await _authorsRepository.GetAllAsync();
            //mapping to a list of AuthorDto
            var records = _mapper.Map<List<GetAuthorDto>>(authors);
            return Ok(records);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorsRepository.GetDetails(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorDto = _mapper.Map<AuthorDto>(author);

            return Ok(author);
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutAuthor(int id, UpdateAuthorDto updateAuthorDto)
        {
            if (id != updateAuthorDto.Id)
            {
                return BadRequest();
            }
            var author = await _authorsRepository.GetAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            //we map from the left side to the right side (update inc object values into object from repo)
            _mapper.Map(updateAuthorDto, author);

            try
            {
                await _authorsRepository.UpdateAsync(author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AuthorExistsAsync(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Author>> PostAuthor(CreateAuthorDto createAuthor)
        {
            //map what came in into the author object:
            var author = _mapper.Map<Author>(createAuthor);
            await _authorsRepository.AddAsync(author);

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorsRepository.GetAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            await _authorsRepository.DeleteAsync(author.Id);
            return NoContent();
        }
        [HttpGet("search/{text}")]
        public async Task<IEnumerable<GetAuthorDto>> SearchAuthor(string text)
        {
            var authors = await _authorsRepository.SearchAsync(text);
            if (authors == null)
            {
                return null;
            }
            var records = _mapper.Map<List<GetAuthorDto>>(authors);
            return records;
        }

        private async Task<bool> AuthorExistsAsync(int id)
        {
            return await _authorsRepository.Exists(id);
        }
    }
}
