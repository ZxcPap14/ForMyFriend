using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static double F(double x)
        { 
            return 3*x-2;
        }
        static void Main(string[] args)
        {
            int count = 0;
            double a = 0, b = 10;
            double eps = 0.1;
            double x = 0, Fxx, Fa, Fb;
            Console.WriteLine("\n" +
            $"{"Count",6} " +
            "| " + $"{"Fa",10} " +
            "| " + $"{"A",10} " +
            "| " + $"{"B",10} " +
            "| " + $"{"Fb",10} " +
            "| " + $"{"C",10} " +
            "| " + $"{"Fc",10} " +
            "| " + $"{"B-A",10} ");

            while (Math.Abs(a-b)>eps)
            {
                x = (a + b) / 2;
                Fxx = F(x);
                if (count > 0)
                {
                    if ((a / Fxx) > (b / Fxx))
                    {
                        a = x;
                    }
                    else
                    {
                        b = x;
                    }
                }
                Fa = F(a);
                Fb = F(b);
                Console.WriteLine($"{count,6} | " +
                $"{Fa,10:F3} | " +
                $"{a,10:F3} | " +
                $"{b,10:F3} | " +
                $"{Fb,10:F3} | " +
                $"{x,10:F3} | " +
                $"{Fxx,10:F3} | " +
                $"{(b - a),10:F3}");
                count++;
            }
            Console.WriteLine($"Ответ: c={Math.Round(x, 3)}");
            Console.ReadKey();
        }
    }
}
