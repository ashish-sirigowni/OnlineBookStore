using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.DTOs;
using OnlineBookStore.Entity;
using OnlineBookStore.Services;

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private readonly ILog _logger;

        public BookController(IBookService bookService, IMapper mapper, IConfiguration configuration, ILog logger)
        {
            this.bookService = bookService;
            _mapper = mapper;
            this.configuration = configuration;
            _logger = logger;
        }
   

        [HttpGet, Route("GetAllBooks")]
        // [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetAll()
        {
            try
            {
                List<Book> Books = bookService.GetAllBooks();
                List<BookDto> booksDto = _mapper.Map<List<BookDto>>(Books);
                return StatusCode(200, booksDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
       
        //[Authorize(Roles = "Admin")]
        [HttpPost, Route("AddBook")]
        public IActionResult Add([FromBody] BookDto bookDto)
        {
            try
            {
                Book book = _mapper.Map<Book>(bookDto);
                bookService.CreateBook(book);
                _logger.Info(book);
                return StatusCode(200, book);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpPut, Route("EditBook/{BookId}")]
        // [Authorize(Roles = "Admin")]
        public IActionResult EditBook(int BookId, [FromBody] BookDto bookDto)
        {
            try
            {
                Book existingBook = bookService.GetBookByBookId(BookId);
                if (existingBook == null)
                {
                    return StatusCode(404, $"Book with ID {BookId} not found");
                }

              
                existingBook.Title = bookDto.Title;
                existingBook.Author = bookDto.Author;
                existingBook.Genre = bookDto.Genre;
                existingBook.ISBN = bookDto.ISBN;
                existingBook.PublishDate = bookDto.PublishDate;

                bookService.EditBook(BookId, existingBook);

                _logger.Info($"Book with ID {BookId} updated successfully.");
                return StatusCode(200, existingBook);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    
       
        [HttpDelete, Route("DeleteBook/{bookId}")]
        // [Authorize(Roles = "Admin")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                bookService.DeleteBook(bookId);
                return StatusCode(200, new JsonResult($"Product with Id {bookId} is Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        [HttpGet, Route("GetBookByBookId/{bookId}")]
        //  [Authorize(Roles ="Admin")]
        public IActionResult GetBookByBookId(int bookId)
        {
            try
            {
                Book book = bookService.GetBookByBookId(bookId);
                if (book == null)
                {
                    return StatusCode(404, "Book not found");
                }
                return StatusCode(200, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
       
        [HttpGet, Route("SearchBooksByName")]
        public IActionResult SearchBooksByName(string name)
        {
            try
            {
                List<Book> books = bookService.SearchBooksByName(name);
                List<BookDto> booksDto = _mapper.Map<List<BookDto>>(books);
                return StatusCode(200, booksDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

       
        [HttpGet, Route("SearchBooksByAuthor")]
        public IActionResult SearchBooksByAuthor(string author)
        {
            try
            {
                List<Book> books = bookService.SearchBooksByAuthor(author);
                List<BookDto> booksDto = _mapper.Map<List<BookDto>>(books);
                return StatusCode(200, booksDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

       
        [HttpGet, Route("SearchBooksByGenre")]
        public IActionResult SearchBooksByGenre(string genre)
        {
            try
            {
                List<Book> books = bookService.SearchBooksByGenre(genre);
                List<BookDto> booksDto = _mapper.Map<List<BookDto>>(books);
                return StatusCode(200, booksDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }





    }
}
