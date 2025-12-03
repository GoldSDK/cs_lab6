using System;

/// <summary>
/// Другой объект, который умеет мяукать (для демонстрации полиморфизма)
/// </summary>
public class MeowingObject : IMeowable
{
    private string objectName;

    /// <summary>
    /// Конструктор для создания другого мяукающего объекта
    /// </summary>
    /// <param name="name">Название объекта</param>
    /// <exception cref="ArgumentException">Выбрасывается, если имя null или пустое</exception>
    
    public MeowingObject(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Название объекта не может быть пустым", nameof(name));
        }

        this.objectName = name;
    }

    /// <summary>
    /// Объект издает мяукающий звук
    /// </summary>
    public void Meow()
    {
        Console.WriteLine(objectName + ": мяяяууу!");
    }

    /// <summary>
    /// Возвращает строковое представление объекта
    /// </summary>
    /// <returns>Строка с названием объекта</returns>
    public override string ToString()
    {
        return "Объект: " + objectName;
    }
}