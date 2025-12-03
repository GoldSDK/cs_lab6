/// <summary>
/// Класс, представляющий дробь
/// </summary>
public class Fraction : ICloneable, IFractionOperations, IEquatable<Fraction>
{
    private int _numerator;
    private int _denominator;
    private double? _cachedRealValue = null;

    /// <summary>
    /// Числитель дроби
    /// </summary>
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; _cachedRealValue = null; }
    }

    /// <summary>
    /// Знаменатель дроби
    /// </summary>
    public int Denominator
    {
        get { return _denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }

            if (value < 0)
            {
                _numerator = -_numerator;
                _denominator = -value;
            }
            else
            {
                _denominator = value;
            }
            _cachedRealValue = null;
        }
    }

    /// <summary>
    /// Конструктор дроби
    /// </summary>
    /// <param name="numerator">Числитель</param>
    /// <param name="denominator">Знаменатель</param>
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("ты на ноль делить собрался?");
        }

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        _numerator = numerator;
        _denominator = denominator;

        Normalize();
    }

    /// <summary>
    /// Нормализует дробь (сокращает)
    /// </summary>
    private void Normalize()
    {
        int gcd = GetGreatestCommonDivisor(Math.Abs(_numerator), Math.Abs(_denominator));
        _numerator /= gcd;
        _denominator /= gcd;
    }

    /// <summary>
    /// Вычисляет наибольший общий делитель
    /// </summary>
    /// <param name="a">Первое число</param>
    /// <param name="b">Второе число</param>
    /// <returns>НОД</returns>
    private int GetGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    /// <summary>
    /// Получает строковое представление дроби
    /// </summary>
    /// <returns>Строковое представление</returns>
    public override string ToString()
    {
        return _numerator + "/" + _denominator;
    }

    // Операции с дробями

    /// <summary>
    /// Сложение двух дробей
    /// </summary>
    /// <param name="other">Вторая дробь</param>
    /// <returns>Новая дробь - результат сложения</returns>
    public Fraction Add(Fraction other)
    {
        int newNumerator = _numerator * other._denominator + other._numerator * _denominator;
        int newDenominator = _denominator * other._denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Сложение дроби с целым числом
    /// </summary>
    /// <param name="number">Целое число</param>
    /// <returns>Новая дробь - результат сложения</returns>
    public Fraction Add(int number)
    {
        int newNumerator = _numerator + number * _denominator;
        return new Fraction(newNumerator, _denominator);
    }

    /// <summary>
    /// Вычитание дробей
    /// </summary>
    /// <param name="other">Вторая дробь</param>
    /// <returns>Новая дробь - результат вычитания</returns>
    public Fraction Subtract(Fraction other)
    {
        int newNumerator = _numerator * other._denominator - other._numerator * _denominator;
        int newDenominator = _denominator * other._denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Вычитание целого числа из дроби
    /// </summary>
    /// <param name="number">Целое число</param>
    /// <returns>Новая дробь - результат вычитания</returns>
    public Fraction Subtract(int number)
    {
        int newNumerator = _numerator - number * _denominator;
        return new Fraction(newNumerator, _denominator);
    }

    /// <summary>
    /// Умножение дробей
    /// </summary>
    /// <param name="other">Вторая дробь</param>
    /// <returns>Новая дробь - результат умножения</returns>
    public Fraction Multiply(Fraction other)
    {
        int newNumerator = _numerator * other._numerator;
        int newDenominator = _denominator * other._denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Умножение дроби на целое число
    /// </summary>
    /// <param name="number">Целое число</param>
    /// <returns>Новая дробь - результат умножения</returns>
    public Fraction Multiply(int number)
    {
        int newNumerator = _numerator * number;
        return new Fraction(newNumerator, _denominator);
    }

    /// <summary>
    /// Деление дробей
    /// </summary>
    /// <param name="other">Вторая дробь</param>
    /// <returns>Новая дробь - результат деления</returns>
    public Fraction Divide(Fraction other)
    {
        if (other._numerator == 0)
        {
            throw new DivideByZeroException("деление на ноль невозможно. вроде. попробуй еще раз");
        }

        int newNumerator = _numerator * other._denominator;
        int newDenominator = _denominator * other._numerator;
        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Деление дроби на целое число
    /// </summary>
    /// <param name="number">Целое число</param>
    /// <returns>Новая дробь - результат деления</returns>
    public Fraction Divide(int number)
    {
        if (number == 0)
        {
            throw new DivideByZeroException("деление на ноль невозможно. вроде. попробуй еще раз");
        }

        int newDenominator = _denominator * number;
        return new Fraction(_numerator, newDenominator);
    }

    /// <summary>
    /// Перегрузка оператора сложения для двух дробей
    /// </summary>
    public static Fraction operator +(Fraction a, Fraction b)
    {
        return a.Add(b);
    }

    /// <summary>
    /// Перегрузка оператора сложения для дроби и целого числа
    /// </summary>
    public static Fraction operator +(Fraction a, int b)
    {
        return a.Add(b);
    }

    /// <summary>
    /// Перегрузка оператора сложения для целого числа и дроби
    /// </summary>
    public static Fraction operator +(int a, Fraction b)
    {
        return b.Add(a);
    }

    /// <summary>
    /// Перегрузка оператора вычитания для двух дробей
    /// </summary>
    public static Fraction operator -(Fraction a, Fraction b)
    {
        return a.Subtract(b);
    }

    /// <summary>
    /// Перегрузка оператора вычитания для дроби и целого числа
    /// </summary>
    public static Fraction operator -(Fraction a, int b)
    {
        return a.Subtract(b);
    }

    /// <summary>
    /// Перегрузка оператора умножения для двух дробей
    /// </summary>
    public static Fraction operator *(Fraction a, Fraction b)
    {
        return a.Multiply(b);
    }

    /// <summary>
    /// Перегрузка оператора умножения для дроби и целого числа
    /// </summary>
    public static Fraction operator *(Fraction a, int b)
    {
        return a.Multiply(b);
    }

    /// <summary>
    /// Перегрузка оператора умножения для целого числа и дроби
    /// </summary>
    public static Fraction operator *(int a, Fraction b)
    {
        return b.Multiply(a);
    }

    /// <summary>
    /// Перегрузка оператора деления для двух дробей
    /// </summary>
    public static Fraction operator /(Fraction a, Fraction b)
    {
        return a.Divide(b);
    }

    /// <summary>
    /// Перегрузка оператора деления для дроби и целого числа
    /// </summary>
    public static Fraction operator /(Fraction a, int b)
    {
        return a.Divide(b);
    }

    // Реализация ICloneable

    /// <summary>
    /// Создает копию объекта дроби
    /// </summary>
    /// <returns>Новый объект дроби с теми же значениями</returns>
    public object Clone()
    {
        return new Fraction(_numerator, _denominator);
    }

    // Реализация IFractionOperations

    /// <summary>
    /// Получает вещественное значение дроби
    /// </summary>
    /// <returns>Вещественное значение дроби</returns>
    public double GetRealValue()
    {
        if (_cachedRealValue == null)
        {
            _cachedRealValue = (double)_numerator / _denominator;
        }
        return _cachedRealValue.Value;
    }

    /// <summary>
    /// Устанавливает числитель дроби
    /// </summary>
    /// <param name="numerator">Новый числитель</param>
    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
        _cachedRealValue = null;
        Normalize();
    }

    /// <summary>
    /// Устанавливает знаменатель дроби
    /// </summary>
    /// <param name="denominator">Новый знаменатель</param>
    public void SetDenominator(int denominator)
    {
        Denominator = denominator; // Используем свойство для проверки
        _cachedRealValue = null;
        Normalize();
    }

    /// <summary>
    /// Проверяет равенство двух дробей по состоянию
    /// </summary>
    /// <param name="other">Другая дробь</param>
    /// <returns>true, если дроби равны</returns>
    public bool Equals(Fraction other)
    {
        if (other == null) return false;
        return _numerator == other._numerator && _denominator == other._denominator;
    }

    /// <summary>
    /// Проверяет равенство объектов
    /// </summary>
    /// <param name="obj">Объект для сравнения</param>
    /// <returns>true, если объекты равны</returns>
    public override bool Equals(object obj)
    {
        if (obj is Fraction fraction)
        {
            return Equals(fraction);
        }
        return false;
    }

    /// <summary>
    /// Получает хэш-код объекта
    /// </summary>
    /// <returns>Хэш-код</returns>
    public override int GetHashCode()
    {
        return Tuple.Create(_numerator, _denominator).GetHashCode();
    }
}