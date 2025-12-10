using Library.Application.Contracts;
using Library.Application.Contracts.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Host.Controllers;

/// <summary>
/// Контроллер для работы с издательствами через CRUD операции
/// </summary>
/// <param name="service">Сервис приложения для CRUD операций с издательствами</param>
/// <param name="logger">Логгер для записи информации о выполнении запросов и исключениях</param>
[Route("api/[controller]")]
[ApiController]
public class PublisherController(
    IApplicationService<PublisherDto, PublisherCreateUpdateDto, Guid> service,
    ILogger<PublisherController> logger)
    : CrudControllerBase<PublisherDto, PublisherCreateUpdateDto, Guid>(service, logger);