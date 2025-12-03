using System;

/// <summary>
/// Декоратор для кота, который подсчитывает количество мяуканий
/// </summary>
/// <remarks>
/// Использует паттерн "Декоратор" для добавления новой функциональности
/// (подсчета мяуканий) без изменения исходного класса Cat.
/// </remarks>
public class CatWithCounter : IMeowable
{
    private Cat cat;
    private int meowCount;

    /// <summary>
    /// Исходный кот (только для чтения)
    /// </summary>
    public Cat OriginalCat
    {
        get { return cat; }
    }

    /// <summary>
    /// Количество выполненных мяуканий
    /// </summary>
    public int MeowCount
    {
        get { return meowCount; }
    }

    /// <summary>
    /// Конструктор декоратора
    /// </summary>
    /// <param name="cat">Кот, для которого нужно подсчитывать мяукания</param>
    /// <exception cref="ArgumentNullException">Выбрасывается, если кот равен null</exception>
    public CatWithCounter(Cat cat)
    {
        if (cat == null)
        {
            throw new ArgumentException("кот не может быть null");
        }

        this.cat = cat;
        this.meowCount = 0;
    }

    /// <summary>
    /// Мяукает и увеличивает счетчик
    /// </summary>
    public void Meow()
    {
        cat.Meow();
        meowCount++;
    }

    /// <summary>
    /// Возвращает строковое представление декоратора
    /// </summary>
    /// <returns>Строка с информацией о декорированном коте</returns>
    public override string ToString()
    {
        return "шаблонный кот " + cat.Name + " (мяукал " + meowCount + " раз)";
    }
}