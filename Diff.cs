using System.Net;

namespace AIContinuous;

public static class Diff 
{
    public static double Differentiate(Func<double, double> function, double x, double h = 1e-2)
        => (function(x + h) - function(x - h)) / (2.0 * h); 

    public static double Differentiate5P(Func<double, double> function, double x, double h = 1e-2)
        => (function(x - 2.0 * h) - 8.0 * function(x - h) + 8.0 * function(x + h) - function(x + 2.0 * h) ) / (12.0 * h); 

    public static double[] Gradient(Func<double[], double> function, double[] x, double h = 1e-2)
    {
        var dim = x.Length;
        var grad = new double[dim];

        for (int i = 0; i < dim; i++)
        {
            var xp1 = (double[]) x.Clone();
            var xp2 = (double[]) x.Clone();

            xp1[i] += h;
            xp2[i] -= h;

            grad[i] = (function(xp1) - function(xp2)) / (2.0 * h); 
        }

        return grad;
    }
}