using AutoMapper;
using OnlineBookStore.DTOs;
using OnlineBookStore.Entity;

namespace OnlineBookStore.Profiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
