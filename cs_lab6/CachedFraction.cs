/// <summary>
/// Декоратор для дроби с кэшированием вещественного значения
/// </summary>
public class CachedFraction : IFractionOperations
{
    private readonly IFractionOperations _fraction;
    private double? _cachedRealValue = null;
    private bool _isCacheValid = false;

    /// <summary>
    /// Конструктор декоратора с кэшированием
    /// </summary>
    /// <param name="fraction">Исходная дробь</param>
    public CachedFraction(IFractionOperations fraction)
    {
        _fraction = fraction ?? throw new ArgumentNullException("fraction");
    }

    /// <summary>
    /// Получает вещественное значение дроби с кэшированием
    /// </summary>
    /// <returns>Вещественное значение дроби</returns>
    public double GetRealValue()
    {
        if (!_isCacheValid)
        {
            _cachedRealValue = _fraction.GetRealValue();
            _isCacheValid = true;
        }
        return _cachedRealValue.Value;
    }

    /// <summary>
    /// Устанавливает числитель дроби (инвалидирует кэш)
    /// </summary>
    /// <param name="numerator">Новый числитель</param>
    public void SetNumerator(int numerator)
    {
        _fraction.SetNumerator(numerator);
        _isCacheValid = false;
    }

    /// <summary>
    /// Устанавливает знаменатель дроби (инвалидирует кэш)
    /// </summary>
    /// <param name="denominator">Новый знаменатель</param>
    public void SetDenominator(int denominator)
    {
        _fraction.SetDenominator(denominator);
        _isCacheValid = false;
    }

    /// <summary>
    /// Получает строковое представление дроби
    /// </summary>
    /// <returns>Строковое представление</returns>
    public override string ToString()
    {
        return _fraction.ToString();
    }
}