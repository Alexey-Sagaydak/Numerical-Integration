namespace MathFunctions;

public class MathFunction
{
    private readonly Func<float, float> function;

    public MathFunction(Func<float, float> _function)
    {
        function = _function;
    }

    public float Calculate(float x)
    {
        return function(x);
    }

    public float CalculateDerivative(float x, int power, float step)
    {
        if (power == 0) return Calculate(x);
        return (CalculateDerivative(x + step, power - 1, step)
            - CalculateDerivative(x - step, power - 1, step)) / (2.0f * step);
    }
}
