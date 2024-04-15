using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _4._2
{
    internal class Program
    {
        static double f(double x)
        {
            return Math.Pow(x, 3) - 3 * x + 5;
        }
        static double fdx2(double x)
        {
            return 6*x;
        }
        static double fdx1(double x)
        {
            return 3*Math.Pow(x,2)-3;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"{"count",5} | " +
                       $"{"x",10:F4} | " +
                       $"{"F(x)",10:F4} | " +
                       $"{"epsilon",10:F4}");
            int count = 0;
            double epsilon = 0.001;
            double a = -2.5, b = -2;
            double Fa = f(a), fb = f(b);
            double x_pred, newPer, newPerF, x_n = 0, Fxx;
            if (Fa > 0 || fdx2(a)<0)
            {
                x_pred = a;
            }
            else
            {
                x_pred = b;
            }
            do
            {
                if (count != 0)
                {
                    x_pred = x_n;
                }
                count++;
                x_n = x_pred - (f(x_pred) / fdx1(x_pred));
                Fxx = f(x_n);
                double zxc = f(x_n) / fdx1(x_n);
                if (Math.Abs(x_n - x_pred) >= epsilon)
                {
                    Console.WriteLine($"{count,5} | " +
                        $"{x_n,10:F4} | " +
                        $"{Fxx,10:F4} | " +
                        $"{zxc,10:F4}");
                }
            } while (Math.Abs(x_n-x_pred)>=epsilon);
            Console.WriteLine($"Ответ: X({count}) = {Math.Round(x_n,4)}");
            Console.ReadKey();
        }
    }
}
