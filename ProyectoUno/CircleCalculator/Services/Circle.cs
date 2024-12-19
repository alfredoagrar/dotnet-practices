namespace CircleCalculator.Services;

public sealed class Circle
{
    private readonly double _radius;
    public Circle(double radius)
    {
        _radius = radius;
    }
    public double Calculate(Func<double, double> op)
    {
        return op(_radius);
    }
}

