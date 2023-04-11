using MathFunctions;
using Numerical_Integration;

namespace NumericalIntegration;

public static class Program
{
    public static void Main()
    {
        Run();
    }

    private static void Run()
    {
        float Function(float x) => (float)((1 + x) / (Math.Pow(2 + 3 * x, 2) * Math.Sqrt(2 + x)));
        int a = 5, b = 15;
        float e1 = 0.001f, e2 = 0.0001f;
        
        MathFunction mathFunction = new MathFunction(Function);
        Menu menu = new Menu(mathFunction);
        menu.Run();
    }
}