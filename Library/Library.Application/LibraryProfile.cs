using AutoMapper;
using Library.Application.Contracts.Books;
using Library.Application.Contracts.Publishers;
using Library.Application.Contracts.Readers;
using Library.Application.Contracts.Rentals;
using Library.Entities;

namespace Library.Application;

/// <summary>
/// Профиль AutoMapper для преобразования сущностей библиотеки в DTO и обратно
/// </summary>
public class LibraryProfile : Profile
{
    /// <summary>
    /// Создаёт конфигурацию маппинга AutoMapper для сущностей Book, Publisher, Reader, Rental
    /// </summary>
    public LibraryProfile()
    {
        CreateMap<Rental, RentalDto>();
        CreateMap<RentalCreateUpdateDto, Rental>();

        CreateMap<Book, BookDto>();
        CreateMap<BookCreateUpdateDto, Book>();

        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherCreateUpdateDto, Publisher>();

        CreateMap<Reader, ReaderDto>();
        CreateMap<ReaderCreateUpdateDto, Reader>();
    }
}