using MathFunctions;

namespace NumericalIntegration;

public class TrapezoidalIntegration
{
    public MathFunction mathFunction { get; }
    public float Step { get; private set; }

    private float Solution1 = 0;
    private float Solution2 = 0;

    public TrapezoidalIntegration(MathFunction mathFunction)
    {
        if (mathFunction == null)
            throw new ArgumentNullException(nameof(mathFunction));

        this.mathFunction = mathFunction;
    }

    public float Solve(float a, float b, float epsilon)
    {
        if (a >= b)
            throw new ArgumentException("a must be less than b");

        float r = 1.5f, h = (b - a) / 2.0f;
        int p = 2;

        Solution2 = GetSolution(a, b, h);
        do
        {
            Solution1 = Solution2;
            h /= r;
            Step = h;
            Solution2 = GetSolution(a, b, h);
        } while (!RungeRule.Check(Solution1, Solution2, p, epsilon, r));

        return Solution2;
    }

    private float GetSolution(float a, float b, float step)
    {
        float result = 0;

        for (float i = a + step; i <= b - step; i += step)
            result += mathFunction.Calculate(i);

        return step * (result + (mathFunction.Calculate(a) + mathFunction.Calculate(b)) / 2.0f);
    }
}
