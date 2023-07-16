using AutoMapper;
using LibraryManagementSystem.API.Dtos;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<List<BookToReturnDto>>> GetBooks([FromQuery] string? title)
        {
            var books = await _bookRepository.ListAllAsync(title);
            return _mapper.Map<List<Book>, List<BookToReturnDto>>(books);
        }

        // GET: api/Books/2
        [HttpGet("{id}")]
        public async Task<ActionResult<BookToReturnDto>> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<Book, BookToReturnDto>(book);
        }

        // POST: api/Books
        [HttpPost]
        public ActionResult AddBook(BookToAddDto book)
        {
            var newBook = _mapper.Map<BookToAddDto, Book>(book);
            _bookRepository.Add(newBook);
            return Ok("Book added successfully");
        }

        // POST: api/Books/2
        [HttpPut("{id}")]
        public ActionResult<BookToReturnDto> UpdateBook(int id,BookToAddDto updatedBook)
        {
            var newBookData = _mapper.Map<BookToAddDto, Book>(updatedBook);
            _bookRepository.Update(id, newBookData);
            return _mapper.Map<Book, BookToReturnDto>(newBookData);
        }

        // DELETE: api/Books 
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            _bookRepository.Delete(id);
            return Ok();
        }
    }
}
