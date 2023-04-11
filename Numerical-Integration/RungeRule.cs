namespace NumericalIntegration;

public static class RungeRule
{
    public static bool Check(float Solution1, float Solution2, int p, float epsilon, float r = 2)
    {
        return (Math.Abs(Solution1 - Solution2) / (Math.Pow(r, p) - 1)) < epsilon;
    }
}
