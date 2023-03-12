using Microsoft.EntityFrameworkCore;
using WebApi_gyakorlat.Models;
using WebApi_gyakorlat.Models.ViewModel;

namespace WebApi_gyakorlat.Services
{
    public class BookService
    {
        private readonly GyakDbContext _gyakDbContext;

        public BookService(GyakDbContext gyakDbContext)
        {
            _gyakDbContext = gyakDbContext;
        }

        public async Task CreateBookAsync(BookView bookView)
        {
            Book? existedBook = await _gyakDbContext.Books.FirstOrDefaultAsync(b => b.Title == bookView.Title);
            if (existedBook == null)
            {
                Book newbook = new Book
                {
                    Title = bookView.Title,
                    Author = bookView.Author,
                };

                _gyakDbContext.Books.Add(newbook);
                await _gyakDbContext.SaveChangesAsync();
            }
            else throw new InvalidDataException("Ilyen című könyv már létezik.");
        }

        public async Task<IEnumerable<BookView>> GetAllBooksAsync()
        {
            var allBooks = await _gyakDbContext.Books
                .Where(book => book.IsDeleted == false)
                .Select(book => new BookView
                {
                    Title=book.Title,
                    Author = book.Author,
                })
                .ToListAsync();
            return allBooks;
        }
    }
}
