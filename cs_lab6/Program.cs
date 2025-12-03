using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Основной класс программы
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine("=== котс и мяукающие объектс ===\n");

        Cat barsik = new Cat("Барсик");
        Console.WriteLine(barsik.ToString());
        barsik.Meow();
        barsik.Meow(3);

        Console.WriteLine("\n=== метод MakeAllMeow ===\n");

        Cat rizhik = new Cat("Рыжик");
        Console.WriteLine(rizhik.ToString());

        Cat bysik = new Cat("Бусик");
        Console.WriteLine(bysik.ToString());

        MeowingObject toy = new MeowingObject("игрушка");
        Console.WriteLine(toy.ToString());

        MeowingObject dog = new MeowingObject("Собака");
        Console.WriteLine(dog.ToString() + "\n");

        List<IMeowable> meowingObjects = new List<IMeowable>
        {
            barsik,
            rizhik,
            bysik,
            toy,
            dog
        };

        MeowHelper.MakeAllMeow(meowingObjects);

        Console.WriteLine("\n=== подсчет мяуканий ===\n");

        Cat murzik = new Cat("Мурзик");
        Console.WriteLine(murzik.ToString());

        CatWithCounter countingMurzik = new CatWithCounter(murzik);
        Console.WriteLine("создан шаблон для подсчета мяуканий");

        MeowHelper.MeowingCompleted += (meowCount) =>
        {
            Console.WriteLine("выполнено " + meowCount + " мяуканий в целом");
        };

        List<IMeowable> countingObjects = new List<IMeowable>
        {
            countingMurzik,
            new MeowingObject("телевизор")
        };

        Console.WriteLine("\nметод MakeAllMeow для шаблонного кота:");
        MeowHelper.MakeAllMeow(countingObjects);

        Console.WriteLine("\n" + murzik.Name + " мяукал " + countingMurzik.MeowCount + " раз");

        Console.WriteLine("\n=== несколько вызовов ===");

        countingMurzik = new CatWithCounter(murzik);

        List<IMeowable> multipleCalls = new List<IMeowable>
        {
            countingMurzik,
            countingMurzik,
            countingMurzik
        };

        MeowHelper.MakeAllMeow(multipleCalls);
        Console.WriteLine("после 3 вызовов кот " + murzik.Name + " мяукал " + countingMurzik.MeowCount + " раз");

        Console.WriteLine("\n=== обработки ошибок ===\n");

        Console.WriteLine("кот с пустым именем:");

        try
        {
            Cat invalidCat = new Cat("");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nмяуканье с неверным параметром:");

        try
        {
            Cat testCat = new Cat("тестовый кот");
            testCat.Meow(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nшаблон с null котом:");
        try
        {
            CatWithCounter nullDecorator = new CatWithCounter(null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== дроби ===\n");

        try
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(2, 3);
            Fraction f3 = new Fraction(3, 4);
            Fraction f4 = new Fraction(-1, 2);
            Fraction f5 = new Fraction(2, -4);

            Console.WriteLine("дроби:");
            Console.WriteLine("f1 = " + f1.ToString());
            Console.WriteLine("f2 = " + f2.ToString());
            Console.WriteLine("f3 = " + f3.ToString());
            Console.WriteLine("f4 = " + f4.ToString());
            Console.WriteLine("f5 = " + f5.ToString() + " (нормализация)");

            Console.WriteLine("\nоперации:");

            Fraction sumResult = f1.Add(f2);
            Console.WriteLine(f1.ToString() + " + " + f2.ToString() + " = " + sumResult.ToString());

            Fraction subResult = f2.Subtract(f1);
            Console.WriteLine(f2.ToString() + " - " + f1.ToString() + " = " + subResult.ToString());

            Fraction mulResult = f1.Multiply(f2);
            Console.WriteLine(f1.ToString() + " * " + f2.ToString() + " = " + mulResult.ToString());

            Fraction divResult = f2.Divide(f1);
            Console.WriteLine(f2.ToString() + " / " + f1.ToString() + " = " + divResult.ToString());

            Fraction intAddResult = f1.Add(2);
            Console.WriteLine(f1.ToString() + " + 2 = " + intAddResult.ToString());

            Fraction intSubResult = f1.Subtract(1);
            Console.WriteLine(f1.ToString() + " - 1 = " + intSubResult.ToString());

            Fraction intMulResult = f1.Multiply(3);
            Console.WriteLine(f1.ToString() + " * 3 = " + intMulResult.ToString());

            Fraction intDivResult = f1.Divide(2);
            Console.WriteLine(f1.ToString() + " / 2 = " + intDivResult.ToString());

            Console.WriteLine("\nперегруженные операторы:");
            Console.WriteLine("f1 + f2 = " + (f1 + f2).ToString());
            Console.WriteLine("f1 - f2 = " + (f1 - f2).ToString());
            Console.WriteLine("f1 * f2 = " + (f1 * f2).ToString());
            Console.WriteLine("f1 / f2 = " + (f1 / f2).ToString());
            Console.WriteLine("f1 + 5 = " + (f1 + 5).ToString());
            Console.WriteLine("3 * f1 = " + (3 * f1).ToString());

            Console.WriteLine("\nкалькуляция f1.sum(f2).div(f3).minus(5)");
            Fraction chainResult = ((f1 + f2) / f3) - 5;
            Console.WriteLine("((" + f1.ToString() + " + " + f2.ToString() + ") / " + f3.ToString() + ") - 5 = " + chainResult.ToString());

            Console.WriteLine("\nсравнение:");
            Fraction f6 = new Fraction(1, 2);
            Fraction f7 = new Fraction(2, 4);
            Console.WriteLine("f6 = " + f6.ToString() + ", f7 = " + f7.ToString());
            Console.WriteLine("f6.Equals(f7): " + f6.Equals(f7));
            Console.WriteLine("f6 == f7 (по ссылке): " + object.ReferenceEquals(f6, f7));

            Console.WriteLine("\nклонирование:");
            Fraction original = new Fraction(3, 5);
            Fraction cloned = (Fraction)original.Clone();
            Console.WriteLine("оригинал: " + original.ToString());
            Console.WriteLine("клон: " + cloned.ToString());
            Console.WriteLine("original.Equals(cloned): " + original.Equals(cloned));
            Console.WriteLine("original == cloned (по ссылке): " + object.ReferenceEquals(original, cloned));

            Console.WriteLine("\nкэширование:");
            Fraction fractionForCache = new Fraction(1, 3);
            CachedFraction cachedFraction = new CachedFraction(fractionForCache);

            double value1 = cachedFraction.GetRealValue();
            Console.WriteLine("1вое получение значения 1/3: " + value1);

            fractionForCache.SetNumerator(2);
            Console.WriteLine("изменена дробь на: " + fractionForCache.ToString());

            double value2 = cachedFraction.GetRealValue();
            Console.WriteLine("2рое получение значения 2/3: " + value2);

            double value3 = cachedFraction.GetRealValue();
            Console.WriteLine("3тье получение значения (из кэша): " + value3);

            Console.WriteLine("\nотрицательные значения:");
            Fraction neg1 = new Fraction(-1, 2);
            Fraction neg2 = new Fraction(1, -2);
            Fraction neg3 = new Fraction(-1, -2);
            Console.WriteLine("-1/2 = " + neg1.ToString());
            Console.WriteLine("1/-2 = " + neg2.ToString() + " (нормализация)");
            Console.WriteLine("-1/-2 = " + neg3.ToString() + " (нормализация)");

            Fraction negResult = neg1 + neg2;
            Console.WriteLine("(-1/2) + (1/-2) = " + negResult.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine("ошибка " + ex.Message);
        }

        Console.WriteLine("\nнажми любую клавишу для выхода...");
        Console.ReadKey();
    }
}