using MathFunctions;

namespace NumericalIntegration;

public enum RectangleType
{
    Left, Right, Middle
}

public class RectangleMethodIntegration
{
    public MathFunction mathFunction { get; }
    public float Step { get; private set; }

    private delegate float GetSolution(float a, float b, float step);
    private float Solution1 = 0;
    private float Solution2 = 0;

    public RectangleMethodIntegration(MathFunction mathFunction)
    {
        if (mathFunction == null)
            throw new ArgumentNullException(nameof(mathFunction));

        this.mathFunction = mathFunction;
    }

    public float Solve(float a, float b, float epsilon, RectangleType rectangleType)
    {
        if (a >= b)
            throw new ArgumentException("a must be less than b");

        float result = 0, r = 1.1f, h = 4;
        GetSolution getSolution;

        switch (rectangleType)
        {
            case RectangleType.Left:
                getSolution = SolveLeft;
                break;
            case RectangleType.Right:
                getSolution = SolveRight;
                break;
            case RectangleType.Middle:
                getSolution = SolveMiddle;
                break;
            default:
                throw new ArgumentException(nameof(RectangleType));
        }

        Solution2 = getSolution(a, b, h);
        do
        {
            Solution1 = Solution2;
            Step = h;
            h /= r;
            Solution2 = getSolution(a, b, h);
        } while (!RungeRule.Check(Solution1, Solution2, 2, epsilon, r));

        return Solution1;
    }

    private float SolveLeft(float a, float b, float step)
    {
        float result = 0;

        for (; a < b - step; a += step)
            result += mathFunction.Calculate(a);

        return result * step;
    }

    private float SolveRight(float a, float b, float step)
    {
        float result = 0;

        for (a += step; a < b; a += step)
            result += mathFunction.Calculate(a);

        return result * step;
    }

    private float SolveMiddle(float a, float b, float step)
    {
        float result = 0;

        for (; a < b - step; a += step)
            result += mathFunction.Calculate((2 * a + step) / 2.0f);

        return result * step;
    }
}
