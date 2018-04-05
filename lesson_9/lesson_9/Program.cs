using System;

namespace lesson_9
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] mass;
            byte matrSqLength = 0;  // длина массива, т.е. размерность квадратной матрицы n
            Random ran3 = new Random(); // создаем последовательность случайных чисел
            try
            {
                Console.Write("Введите рамер массива (0-255), n = ");
                matrSqLength = byte.Parse(Console.ReadLine());
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
            }
            finally
            {
                mass = new long[matrSqLength];
                Console.WriteLine("Начальный массив:");
                for (int i = 0; i < mass.Length; i++) {
                    mass[i] =ran3.Next(1,100);
                    Console.Write(" " + mass[i]);
                }
                BubbleSort(mass, mass.Length);
                Console.WriteLine();
                Console.WriteLine("Сортированый массив:");
                for (int i = 0; i < mass.Length; i++)
                {
                   
                    Console.Write(" "+mass[i]);
                }
            }
            Console.ReadKey();
         }

        static void BubbleSort(long[] a, long size) {
            long i, j;
            long x;
            for (i = 0; i < size; i++) {
               for  (j = size - 1;j > i;j-- ){
                    if (a[j - 1] > a[j]) {

                        x = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = x;
                    }


                }

            }


        }
    }
}
