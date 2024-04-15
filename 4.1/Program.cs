using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _4._1
{
    internal class Program
    {
        static double f(double x)
        {
            return (Math.Cos(x)+2*x-3);
        }

        static double fdx2(double X)
        {
            return -Math.Cos(X);
        }
        static void Main(string[] args)
        {
            int count = 0;
            double epsilon= 0.001;
            double a = 1,b=1.5;
            double Fa= f(a),fb=f(b);
            double x_pred, newPer, newPerF,x_n = 0,Fxx;
            if (Fa > 0 || fdx2(a) < 0)
            {
                x_pred = a;
                newPer = b;
                newPerF = fb;
            }
            else
            {
                x_pred = b;
                newPer = a;
                newPerF = fb;
            }
            Console.WriteLine($"{"Count",5} | " +
                                       $"{"x_n",10:F4} | " +
                                       $"{"F(x_n)",10:F4} | ");
            do
            {
                if (count != 0)
                {
                    x_pred = x_n;
                }
                double qqx = f(x_pred);
                x_n = x_pred - (qqx * (x_pred - newPer) / (qqx - f(newPer)));
                Fxx = f(x_n);
                if (Math.Abs(x_n -x_pred) >= epsilon)
                {
                    count++;
                    Console.WriteLine(  $"{count,5} | " +
                                        $"{x_n,10:F4} | " +
                                        $"{Fxx,10:F4} | ");
                }
            } while (Math.Abs(x_n-x_pred)>=epsilon);
            Console.WriteLine($"Ответ: X({count})={Math.Round(x_n,4)}");
            Console.ReadKey();
        }
    }
}
