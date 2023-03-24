using AutoMapper;
using OnlineBookShop.Appilcation.App.Dtos;
using OnlineBookShop.Appilcation.Common.Interfaces;
using OnlineBookShop.Domain;

namespace OnlineBookShop.Appilcation.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _repository.GetAllAsync<Book>();

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return booksDto;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync<Book>(id);

            if (book == null)
            {
                throw new ArgumentNullException();
            }

            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }

        public async Task AddBookAsync(BookDto bookDto)
        {
            var book = new Book
            {
                Name = bookDto.Name,
                NumberOfPages = bookDto.NumberOfPages,
                Description = bookDto.Description,
                PublicationDate = bookDto.PublicationDate
            };

            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            await _repository.DeleteAsync<Book>(id);

            await _repository.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(int id, BookDto bookDto)
        {
            var book = await _repository.GetByIdAsync<Book>(id);

            if (book == null)
            {
                throw new ArgumentNullException();
            }

            book.Name = bookDto.Name;
            book.NumberOfPages = bookDto.NumberOfPages;
            book.Description = bookDto.Description;
            book.PublicationDate = bookDto.PublicationDate;

            await _repository.UpdateAsync(book);
        }
    }
}
