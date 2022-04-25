using API_APP.Models;

namespace API_APP.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> CreateBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
