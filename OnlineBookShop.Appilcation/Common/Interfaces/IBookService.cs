using OnlineBookShop.Appilcation.App.Dtos;

namespace OnlineBookShop.Appilcation.Common.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();

        Task<BookDto> GetBookByIdAsync(int id);

        Task AddBookAsync(BookDto bookDto);

        Task DeleteBookAsync(int id);

        Task UpdateBookAsync(int id, BookDto bookDto);
    }
}
