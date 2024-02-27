using System.Diagnostics;
using System.Security.Cryptography;
using AIContinuous;

double RosenbrockFunction(double[] x)
{
    var n = x.Length - 1;
    double sum = 0.0;

    for (int i = 0; i < n; i++)
        sum += 100 * ((x[i + 1] - x[i] * x[i]) * (x[i + 1] - x[i] * x[i])) + ((1 - x[i]) * (1 - x[i]));

    return sum;
} 

double Restriction(double[] x)
{
    return x[0] * x[0] + x[1] * x[1] - 2.0;
}

// double MyDer(double x)
//     => (2 * (x - 1)) + Math.Cos(x * x * x) * (3 * x * x);

// double[] sol;
// var date = DateTime.Now;

// date = DateTime.Now;
// sol = Root.Bisection(MyFunction, -10.0, 10.0);
// Console.WriteLine($"Solution: {sol} | Time: {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Root.FalsePosition(MyFunction, -10.0, 10.0);
// Console.WriteLine($"Solution: {sol} | Time: {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Root.Newton(MyFunction, MyDer, 10.0);
// Console.WriteLine($"Solution: {sol} | Time: {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Root.Newton(MyFunction, double (double x) => Diff.Differentiate(MyFunction, x), 100.0);
// Console.WriteLine($"Solution: {sol} | Time: {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Optimize.Newton(MyFunction, 0.0);
// Console.WriteLine($"Solution: {sol} | Time: {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Optimize.GradientDescent(RosenbrockFunction, new[] { 1.0, 1.0 });
// Console.WriteLine($"X:{sol[0]}, Y:{sol[1]}  | Time: {(DateTime.Now - date).TotalMilliseconds}");

List<double[]> bounds = new()
{
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0}
};


var sw = new Stopwatch();

sw.Restart();
var diffEvolution = new DiffEvolution(RosenbrockFunction, bounds, 200, restriction: Restriction);
var res = diffEvolution.Optimize(10000);

sw.Stop();
Console.WriteLine($"res :{res[0]}, {res[1]}  | Time: {sw.ElapsedMilliseconds}");

