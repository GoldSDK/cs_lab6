using System;

/// <summary>
/// Класс, представляющий кота
/// </summary>
public class Cat : IMeowable
{
    private string name;

    /// <summary>
    /// Имя кота (только для чтения)
    /// </summary>
    public string Name
    {
        get { return name; }
    }

    /// <summary>
    /// Конструктор для создания кота
    /// </summary>
    /// <param name="name">Имя кота</param>
    /// <exception cref="ArgumentException">Выбрасывается, если имя null или пустое</exception>
    public Cat(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("кот не может быть безымянным");
        }

        this.name = name;
    }

    /// <summary>
    /// Возвращает строковое представление кота
    /// </summary>
    /// <returns>Строка в формате "кот: Имя"</returns>
    public override string ToString()
    {
        return "кот: " + Name;
    }

    /// <summary>
    /// Кот мяукает один раз
    /// </summary>
    public void Meow()
    {
        Console.WriteLine(Name + ": мяу!");
    }

    /// <summary>
    /// Кот мяукает указанное количество раз
    /// </summary>
    /// <param name="count">Количество мяуканий</param>
    /// <exception cref="ArgumentException">Выбрасывается, если count меньше или равен 0</exception>
    public void Meow(int count)
    {
        if (count <= 0)
        {
            throw new ArgumentException("я не думаю что кот может мяукнуть отрицательное кол-во раз");
        }

        string meowString = "мяу";

        for (int i = 1; i < count; i++)
        {
            meowString = meowString + "-мяу";
        }

        Console.WriteLine(Name + ": " + meowString + "!");
    }
}