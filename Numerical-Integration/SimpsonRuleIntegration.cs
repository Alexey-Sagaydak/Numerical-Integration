using MathFunctions;

namespace NumericalIntegration;

public class SimpsonRuleIntegration
{
    public MathFunction mathFunction { get; }
    public float Step { get; private set; }

    private float Solution1 = 0;
    private float Solution2 = 0;

    public SimpsonRuleIntegration(MathFunction mathFunction)
    {
        if (mathFunction == null)
            throw new ArgumentNullException(nameof(mathFunction));

        this.mathFunction = mathFunction;
    }

    public float Solve(float a, float b, float epsilon)
    {
        if (a >= b)
            throw new ArgumentException("a must be less than b");

        float r = 2f, h = (b - a) / 2.0f;
        int p = 4;

        Solution2 = GetSolution(a, b, h);
        do
        {
            Solution1 = Solution2;
            Step = h;
            h /= r;
            Solution2 = GetSolution(a, b, h);
        } while (!RungeRule.Check(Solution1, Solution2, p, epsilon, r));

        return Solution1;
    }

    private float GetSolution(float a, float b, float step)
    {
        int n = (int)((b - a) / step);
        float result = mathFunction.Calculate(a) + mathFunction.Calculate(b);

        for (int i = 1; i <= n - 1; i++)
        {
            a += step;
            result += (i % 2 == 0) ? 2 * mathFunction.Calculate(a) : 4 * mathFunction.Calculate(a);
        }

        return (step / 3) * result;
    }
}
