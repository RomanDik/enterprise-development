using Library.Application.Contracts;
using Library.Application.Contracts.Rentals;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Host.Controllers;

/// <summary>
/// Контроллер для работы с выдачами через CRUD операции
/// </summary>
/// <param name="service">Сервис приложения для CRUD операций с выдачами</param>
/// <param name="logger">Логгер для записи информации о выполнении запросов и исключениях</param>
[Route("api/[controller]")]
[ApiController]
public class RentalController(
    IApplicationService<RentalDto, RentalCreateUpdateDto, Guid> service,
    ILogger<RentalController> logger)
    : CrudControllerBase<RentalDto, RentalCreateUpdateDto, Guid>(service, logger);