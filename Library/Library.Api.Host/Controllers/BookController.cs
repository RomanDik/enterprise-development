using Library.Application.Contracts;
using Library.Application.Contracts.Books;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Host.Controllers;

/// <summary>
/// Контроллер для работы с книгами через CRUD операции
/// </summary>
/// <param name="service">Сервис приложения для CRUD операций с книгами</param>
/// <param name="logger">Логгер для записи информации о выполнении запросов и исключениях</param>
[Route("api/[controller]")]
[ApiController]
public class BookController(
    IApplicationService<BookDto, BookCreateUpdateDto, Guid> service, 
    ILogger<BookController> logger)
    : CrudControllerBase<BookDto, BookCreateUpdateDto, Guid>(service, logger);