using AutoMapper;
using OnlineBookShop.Appilcation.App.Dtos;
using OnlineBookShop.Domain;

namespace OnlineBookShop.Appilcation.Profiles
{
    public class BookProfile  :Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
