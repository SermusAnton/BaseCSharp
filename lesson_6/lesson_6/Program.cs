using System;

namespace lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrSq; // объявляем двухмерный массив, т.е. это будет квадратная матрица
            byte matrSqLength = 0;  // длина массива, т.е. размерность квадратной матрицы n
            Random ran3 = new Random(); // создаем последовательность случайных чисел
            Console.WriteLine("Hello World!");

            try
            {
                Console.Write("Введите рамер матрицы (0-255), n = ");
                matrSqLength = byte.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Массив: ");
                Console.WriteLine("____________________");
                matrSq = new double[matrSqLength, matrSqLength];   // инициализируем целочисленный квадратный массив, длинной заданной с клавиатуры

                // Ввод случайных чисел
                for (int i = 0; i < matrSq.GetLength(0); i++)
                {
                    for (int j = 0; j < matrSq.GetLength(1); j++)
                    {
                        matrSq[i, j] = ran3.Next(0, 10);
                        Console.Write("{0}\t", matrSq[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Минор: ");
                Console.WriteLine("____________________");

                double[,] Minor = GetMinor(matrSq,1);

                // Ввод случайных чисел
                for (int i = 0; i < Minor.GetLength(0); i++)
                {
                    for (int j = 0; j < Minor.GetLength(1); j++)
                    {
                     //   Minor[i, j] = ran3.Next(-10, 10);
                        Console.Write("{0}\t", Minor[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();

            }
        }
        private static double[,] GetMinor(double[,] matrix, int n) {
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i=1; i<matrix.GetLength(0);i++)
            {
                for (int j = 0; j < n; j++)
                    result[i - 1, j] = matrix[i,j];
                for (int j = n + 1; j < matrix.GetLength(0); j++)
                    result[i - 1, j - 1] = matrix[i,j];

            }

            return result;
        }
    }
}
