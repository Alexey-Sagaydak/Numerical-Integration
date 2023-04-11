using MathFunctions;

namespace NumericalIntegration;

public static class Program
{
    public static void Main()
    {
        Run();
    }

    public static void Run()
    {
        float Function(float x) => (float)((1 + x) / (Math.Pow(2 + 3 * x, 2) * Math.Sqrt(2 + x)));
        int a = 5, b = 15;
        float e1 = 0.001f, e2 = 0.0001f;

        MathFunction mathFunction = new MathFunction(Function);

        RectangleMethodIntegration rectangleMethodIntegration = new RectangleMethodIntegration(mathFunction);

        Console.WriteLine($"{rectangleMethodIntegration.Solve(a, b, e1, RectangleType.Left)} {rectangleMethodIntegration.Step}");
        Console.WriteLine($"{rectangleMethodIntegration.Solve(a, b, e2, RectangleType.Left)} {rectangleMethodIntegration.Step}");

        Console.WriteLine($"{rectangleMethodIntegration.Solve(a, b, e1, RectangleType.Right)} {rectangleMethodIntegration.Step}");
        Console.WriteLine($"{rectangleMethodIntegration.Solve(a, b, e2, RectangleType.Right)} {rectangleMethodIntegration.Step}");

        Console.WriteLine($"{rectangleMethodIntegration.Solve(a, b, e1, RectangleType.Middle)} {rectangleMethodIntegration.Step}");
        Console.WriteLine($"{rectangleMethodIntegration.Solve(a, b, e2, RectangleType.Middle)} {rectangleMethodIntegration.Step}");

    }
}