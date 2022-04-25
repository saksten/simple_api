using Microsoft.EntityFrameworkCore;
using API_APP.Models;

namespace API_APP.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books {get;set;} 
    }
}