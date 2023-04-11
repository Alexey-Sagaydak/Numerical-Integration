using MathFunctions;
using NumericalIntegration;

namespace Numerical_Integration;

public class Menu
{
    private RectangleMethodIntegration _rectangleMethodIntegration;
    private TrapezoidalIntegration _trapezoidalIntegration;
    private SimpsonRuleIntegration _simpsonRuleIntegration;
    private float A;
    private float B;
    private float E;

    public Menu(MathFunction mathFunction)
    {
        _rectangleMethodIntegration = new RectangleMethodIntegration(mathFunction);
        _trapezoidalIntegration = new TrapezoidalIntegration(mathFunction);
        _simpsonRuleIntegration = new SimpsonRuleIntegration(mathFunction);
        InitializeConfiguration();
    }

    public void Run()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Меню");
            Console.WriteLine(
                "1) Изменить характеристики.\n2) Решение методом прямоугольников.\n3) Решение методом трапеций.\n4) Решение методом симсона.\n5) Решение всеми методами.");
            try
            {
                GetOption();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadLine();
            Console.Clear();
        }
    }

    private void GetOption()
    {
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                EditConfiguration();
                break;
            case "2":
                PrintRectangleSolution();
                break;
            case "3":
                PrintTrapezoidalSolution();
                break;
            case "4":
                PrintSimpsonSolution();
                break;
            case "5":
                PrintAllSolutions();
                break;
            default:
                Console.WriteLine("Введено неверное значение!");
                break;
        }
    }

    private void EditConfiguration()
    {
        Console.Clear();
        Console.WriteLine("Изменение конфигурации");
        Console.WriteLine(
            "1) Изменить левую границу.\n2) Изменить правую границу.\n3) Изменить точность.");

        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                GetLeftBorder();
                break;
            case "2":
                GetRightBorder();
                break;
            case "3":
                GetAccuracy();
                break;
            default:
                Console.WriteLine("Введено неверное значение!");
                break;
        }
    }


    private void GetLeftBorder()
    {
        Console.WriteLine("Введите левый предел интегрирования: ");

        while (!float.TryParse(Console.ReadLine(), out A))
        {
            Console.WriteLine("Введено неверное значение!");
        }
    }

    private void GetRightBorder()
    {
        Console.WriteLine("Введите правый предел интегрирования: ");

        while (!float.TryParse(Console.ReadLine(), out B) || B <= A)
        {
            Console.WriteLine("Введено неверное значение!");
        }
    }

    private void GetAccuracy()
    {
        Console.WriteLine("Введите требуемую точность: ");

        while (!float.TryParse(Console.ReadLine(), out E) || E <= 0)
        {
            Console.WriteLine("Введено неверное значение!");
        }
    }

    private void PrintRectangleSolution()
    {
        Console.WriteLine(
            $"Решение методом левых прямоугольников: {_rectangleMethodIntegration.Solve(A, B, E, RectangleType.Left)} Шаг: {_rectangleMethodIntegration.Step}");
        Console.WriteLine(
            $"Решением методом правых прямоугольников: {_rectangleMethodIntegration.Solve(A, B, E, RectangleType.Right)} Шаг: {_rectangleMethodIntegration.Step}");
        Console.WriteLine(
            $"Решение методом средних прямоугольников: {_rectangleMethodIntegration.Solve(A, B, E, RectangleType.Middle)} Шаг: {_rectangleMethodIntegration.Step}");
    }

    private void PrintTrapezoidalSolution()
    {
        Console.WriteLine(
            $"Решение методом трапеций: {_trapezoidalIntegration.Solve(A, B, E)} Шаг: {_trapezoidalIntegration.Step}");
    }

    private void PrintSimpsonSolution()
    {
        Console.WriteLine(
            $"Решение методом Симпсона: {_simpsonRuleIntegration.Solve(A, B, E)} Шаг: {_simpsonRuleIntegration.Step}");
    }

    private void InitializeConfiguration()
    {
        GetLeftBorder();
        GetRightBorder();
        GetAccuracy();
    }

    private void PrintAllSolutions()
    {
        PrintRectangleSolution();
        PrintTrapezoidalSolution();
        PrintSimpsonSolution();
    }
}