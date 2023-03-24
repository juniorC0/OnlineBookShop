using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Appilcation.App.Dtos;
using OnlineBookShop.Appilcation.Common.Interfaces;

namespace OnlineBookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            return await _bookService.GetAllBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            try
            {
                var bookDto = await _bookService.GetBookByIdAsync(id);

                return Ok(bookDto);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest($"Book with id: {id} is not found");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
        {
            try
            {
                await _bookService.AddBookAsync(bookDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Book with id: {id} is not found");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookUpdateDto)
        {
            try
            {
                await _bookService.UpdateBookAsync(id, bookUpdateDto);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Book with id: {id} is not found");
            }
        }

        [HttpGet("books-per-year")]
        public async Task<IActionResult> GetBooksPerYear()
        {
            var booksPerYear = await _bookService.GetBooksPerYearAsync();

            return Ok(booksPerYear);
        }
    }
}
