using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _3._2
{
    internal class Program
    {
        static double GFunction(double x)
        {
            return (1 - Math.Log10(x)) / 2;
        }

        // Процедура метода простой итерации
        static void SimpleIterationMethod(double initialGuess, double epsilon)
        {
            Console.WriteLine($"{"Count",6} " +
            "| " + $"{"X(k)",10} " +
                "| " + $"{"X(k)-X(k-1)",10}|");
            int iteration = 0;
            double currentX = initialGuess;
            double eps;
            while (true)
            {
                double nextX = GFunction(currentX); // Применяем итерационную формулу
                Console.WriteLine($"{iteration,6} " +
                "| " + $"{Math.Round(nextX,5),10} " +
                "| " + $"{Math.Round(Math.Abs(nextX - currentX),5),10} |");
                // Проверяем на достижение заданной точности
                if (Math.Abs(nextX - currentX) < epsilon)
                {
                    Console.WriteLine($"Решение найдено: x = {nextX}");
                    return;
                }
                currentX = nextX;
                iteration++;
            }

        }

        static void Main()
        {
            double initialGuess = 0.5; // Начальное предположение
            double epsilon = 0.001; // Требуемая точность
            SimpleIterationMethod(initialGuess, epsilon);
            Console.ReadKey();
        }
        
    }
}
