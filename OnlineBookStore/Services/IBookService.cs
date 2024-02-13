using OnlineBookStore.Entity;

namespace OnlineBookStore.Services
{
    public interface IBookService
    {
        void CreateBook(Book book);
        List<Book> GetAllBooks();
        void EditBook(int BookId, Book book);
        void DeleteBook(int BookId);
        Book GetBookByBookId(int bookId);

        List<Book> SearchBooksByName(string name);
        List<Book> SearchBooksByAuthor(string author);
        List<Book> SearchBooksByGenre(string genre);

    }
}
