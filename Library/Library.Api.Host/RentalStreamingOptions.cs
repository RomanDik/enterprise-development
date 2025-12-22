namespace Library.Api.Host;

/// <summary>
/// Настройки для сервиса потоковой генерации аренды
/// </summary>
public class RentalStreamingOptions
{
    /// <summary>
    /// Количество запрашиваемых контрактов за один раз
    /// </summary>
    public int RequestCount { get; set; } = 10;

    /// <summary>
    /// Интервал между запросами в миллисекундах
    /// </summary>
    public int RequestIntervalMs { get; set; } = 3000;
}