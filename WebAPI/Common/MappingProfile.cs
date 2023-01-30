using WebAPI.Operations.BookOperations.Commands;
using WebAPI.Operations.BookOperations.Queries;

namespace WebAPI.Common;

public class MappingProfile : Profile {
    public MappingProfile(){
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book, GetBookByIdViewModel>()
            .ForMember(dest => dest.Genre, option => option.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
            .ForMember(dest => dest.PublishDate, option => option.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy")));
        CreateMap<Book, GetBooksViewModel>()
            .ForMember(dest => dest.Genre, option => option.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
            .ForMember(dest => dest.PublishDate, option => option.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy")));
        CreateMap<Book, FilterBooksViewModel>()
            .ForMember(dest => dest.Genre, option => option.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
            .ForMember(dest => dest.PublishDate, option => option.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy")));
    }
}