namespace Library.RentalGenerator;

/// <summary>
/// Настройки генерации контрактов аренды
/// </summary>
public class RentalGenerationOptions
{
    /// <summary>
    /// Размер пакета генерируемых контрактов за одну итерацию
    /// </summary>
    public int BatchSize { get; set; } = 5;

    /// <summary>
    /// Задержка между генерацией пакетов в миллисекундах
    /// </summary>
    public int BatchDelayMs { get; set; } = 1000;
}