/// <summary>
/// Интерфейс для работы с дробью
/// </summary>
public interface IFractionOperations
{
    /// <summary>
    /// Получает вещественное значение дроби
    /// </summary>
    /// <returns>Вещественное значение дроби</returns>
    double GetRealValue();

    /// <summary>
    /// Устанавливает числитель дроби
    /// </summary>
    /// <param name="numerator">Новый числитель</param>
    void SetNumerator(int numerator);

    /// <summary>
    /// Устанавливает знаменатель дроби
    /// </summary>
    /// <param name="denominator">Новый знаменатель</param>
    void SetDenominator(int denominator);
}