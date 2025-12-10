using Library.Application.Contracts;
using Library.Application.Contracts.Analytics;
using Library.Application.Contracts.Books;
using Library.Application.Contracts.Readers;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Host.Controllers;

/// <summary>
/// Контроллер для получения аналитической информации по данным библиотеки
/// </summary>
/// <param name="analyticsService">Сервис аналитики библиотеки</param>
/// <param name="logger">Логгер для записи информации о выполнении запросов и исключениях</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService analyticsService, ILogger<AnalyticsController> logger) : ControllerBase
{
    /// <summary>
    /// Получает информацию о выданных и не возвращённых книгах, упорядоченных по названию
    /// </summary>
    /// <returns>Список BookDto выданных книг</returns>
    [HttpGet("rented-books")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<BookDto>>> GetRentedBooksOrderedByTitle()
    {
        logger.LogInformation("{method} method of {controller} is called", nameof(GetRentedBooksOrderedByTitle), GetType().Name);
        try
        {
            var res = await analyticsService.GetRentedBooksOrderedByTitle();
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetRentedBooksOrderedByTitle), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(GetRentedBooksOrderedByTitle), GetType().Name);
            return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получает информацию о читателях с активными выдачами, упорядоченных по ФИО
    /// </summary>
    /// <returns>Список ReaderDto читателей</returns>
    [HttpGet("active-readers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<ReaderDto>>> GetReadersWithActiveRentalsOrderedByName()
    {
        logger.LogInformation("{method} method of {controller} is called", nameof(GetReadersWithActiveRentalsOrderedByName), GetType().Name);
        try
        {
            var res = await analyticsService.GetReadersWithActiveRentalsOrderedByName();
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetReadersWithActiveRentalsOrderedByName), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(GetReadersWithActiveRentalsOrderedByName), GetType().Name);
            return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получает информацию о читателях, бравших книги на максимальный срок, упорядоченных по ФИО
    /// </summary>
    /// <returns>Список ReaderDto читателей</returns>
    [HttpGet("longest-rental-readers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<ReaderDto>>> GetReadersWithLongestRentalPeriodOrderedByName()
    {
        logger.LogInformation("{method} method of {controller} is called", nameof(GetReadersWithLongestRentalPeriodOrderedByName), GetType().Name);
        try
        {
            var res = await analyticsService.GetReadersWithLongestRentalPeriodOrderedByName();
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetReadersWithLongestRentalPeriodOrderedByName), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(GetReadersWithLongestRentalPeriodOrderedByName), GetType().Name);
            return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получает топ 5 наиболее популярных издательств за период, начиная с указанной даты
    /// </summary>
    /// <param name="fromDate">Дата начала периода</param>
    /// <returns>Список DTO издательств с количеством выдач</returns>
    [HttpGet("top-publishers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<TopPublisherAnalyticsDto>>> GetTop5PopularPublishers([FromQuery] DateTime fromDate)
    {
        logger.LogInformation("{method} method of {controller} is called with {fromDate} parameter", nameof(GetTop5PopularPublishers), GetType().Name, fromDate);

        try
        {
            if (fromDate == default)
                return BadRequest("fromDate is required");

            var res = await analyticsService.GetTop5PopularPublishers(fromDate);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetTop5PopularPublishers), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(GetTop5PopularPublishers), GetType().Name);
            return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получает топ 5 наименее популярных книг за период, начиная с указанной даты
    /// </summary>
    /// <param name="fromDate">Дата начала периода</param>
    /// <returns>Список DTO книг с количеством выдач</returns>
    [HttpGet("least-popular-books")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<BookPopularityAnalyticsDto>>> GetTop5LeastPopularBooks([FromQuery] DateTime fromDate)
    {
        logger.LogInformation("{method} method of {controller} is called with {fromDate} parameter", nameof(GetTop5LeastPopularBooks), GetType().Name, fromDate);

        try
        {
            if (fromDate == default)
                return BadRequest("fromDate is required");

            var res = await analyticsService.GetTop5LeastPopularBooks(fromDate);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetTop5LeastPopularBooks), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(GetTop5LeastPopularBooks), GetType().Name);
            return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}