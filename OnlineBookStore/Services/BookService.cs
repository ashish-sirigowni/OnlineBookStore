using OnlineBookStore.Database;
using OnlineBookStore.Entity;

namespace OnlineBookStore.Services
{
    public class BookService:IBookService
    {
        private readonly MyContext _context;

        public BookService(MyContext context)
        {
            _context = context;
        }

        public void CreateBook(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteBook(int BookId)
        {
            Book book = _context.Books.Find(BookId);
            if (book != null)
            {
                try
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EditBook(int BookId, Book book)
        {
            var existingBook = _context.Books.Find(BookId);
            if (existingBook == null)
                throw new InvalidOperationException("Book Not found");
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.ISBN = book.ISBN;
            existingBook.PublishDate = book.PublishDate;
            _context.SaveChanges();
          
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                return _context.Books.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Book GetBookByBookId(int bookId)
        {
            try
            {
                return _context.Books.FirstOrDefault(book => book.BookId == bookId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Book> SearchBooksByName(string name)
        {
            return _context.Books.Where(book => book.Title.Contains(name)).ToList();
        }

        public List<Book> SearchBooksByAuthor(string author)
        {
            return _context.Books.Where(book => book.Author.Contains(author)).ToList();
        }

        public List<Book> SearchBooksByGenre(string genre)
        {
            return _context.Books.Where(book => book.Genre.Contains(genre)).ToList();
        }
    
    


    }
}
