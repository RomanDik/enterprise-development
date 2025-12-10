using Library.Application.Contracts;
using Library.Application.Contracts.Readers;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Host.Controllers;

/// <summary>
/// Контроллер для работы с читателями через CRUD операции
/// </summary>
/// <param name="service">Сервис приложения для CRUD операций с читателями</param>
/// <param name="logger">Логгер для записи информации о выполнении запросов и исключениях</param>
[Route("api/[controller]")]
[ApiController]
public class ReaderController(
    IApplicationService<ReaderDto, ReaderCreateUpdateDto, Guid> service,
    ILogger<ReaderController> logger)
    : CrudControllerBase<ReaderDto, ReaderCreateUpdateDto, Guid>(service, logger);