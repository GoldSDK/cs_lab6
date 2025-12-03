using System;
using System.Collections.Generic;

/// <summary>
/// Вспомогательный класс для работы с мяукающими объектами
/// </summary>
public static class MeowHelper
{
    /// <summary>
    /// Делегат для события завершения мяуканья
    /// </summary>
    /// <param name="meowCount">Общее количество выполненных мяуканий</param>
    public delegate void MeowingCompletedHandler(int meowCount);

    /// <summary>
    /// Событие, возникающее после завершения всех мяуканий
    /// </summary>
    public static event MeowingCompletedHandler MeowingCompleted;

    /// <summary>
    /// Вызывает мяуканье у каждого объекта в коллекции
    /// </summary>
    /// <param name="meowingObjects">Коллекция объектов, способных мяукать</param>
    /// <exception cref="ArgumentNullException">Выбрасывается, если коллекция null</exception>
    public static void MakeAllMeow(IEnumerable<IMeowable> meowingObjects)
    {
        if (meowingObjects == null)
        {
            throw new ArgumentNullException(nameof(meowingObjects), "Коллекция не может быть null");
        }

        int totalMeows = 0;

        foreach (var obj in meowingObjects)
        {
            obj.Meow();
            totalMeows++;
        }

        // Вызываем событие после завершения всех мяуканий
        OnMeowingCompleted(totalMeows);
    }

    /// <summary>
    /// Вызывает событие MeowingCompleted
    /// </summary>
    /// <param name="meowCount">Количество выполненных мяуканий</param>
    private static void OnMeowingCompleted(int meowCount)
    {
        MeowingCompleted?.Invoke(meowCount);
    }
}