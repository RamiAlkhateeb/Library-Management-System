using AutoMapper;
using LibraryManagementSystem.API.Dtos;
using LibraryManagementSystem.Core.Entities;

namespace LibraryManagementSystem.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Book, BookToReturnDto>();
            CreateMap<BookToAddDto, Book>();
        }
    }
}
