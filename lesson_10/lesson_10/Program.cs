using System;

namespace lesson_10
{
    class Program
    {  
        /*  Шейкер-сортировка*/

        static void ShakerSort(int[] myint) {
            int left = 0, // левая граница
               right = myint.Length - 1;
            int count = 0;
            while (left<=right) {
                for (int i = left; i < right; i++) {  // Сдвигаем  к концу массива "тяжелые элементы"
                    count++;
                    if (myint[i] > myint[i + 1])
                        Swap(myint, i, i + 1);

                }
                right--; // уменьшаем правую границу

           
                for (int i = right; i > left; i--)  // Сдвигаем к началу массива "легкие элементы"
                {
                    count++;
                    if (myint[i - 1] > myint[i])
                        Swap(myint, i-1,i);

                }
                left++;
            }
            Console.WriteLine("\nКоличество сравнений = {0}", count.ToString());    
        }

        // функция перестановки
        public static void Swap(int[] m, int n, int k) // входной массив, индексы переставляемых значений массива
        {
            int c = m[n];
            m[n] = m[k];
            m[k] = c;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1. Шейкерная-сортировка.");
            int[] matrSq; // объявляем двухмерный массив, т.е. это будет квадратная матрица
            byte matrSqLength = 0;  // длина массива, т.е. размерность квадратной матрицы n
            Random ran3 = new Random(); // создаем последовательность случайных чисел
            try
            {
                Console.Write("Введите рамер (0-255), n = ");
                matrSqLength = byte.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Массив: ");

                matrSq = new int[matrSqLength];   // инициализируем целочисленный квадратный массив, длинной заданной с клавиатуры

                // Ввод случайных чисел
                for (int i = 0; i < matrSq.GetLength(0); i++)
                {
                    
                        matrSq[i] = ran3.Next(0, 10);
                        Console.Write("{0}\t", matrSq[i]);
                   
                }
                Console.WriteLine();
                ShakerSort(matrSq);  // Получаем все перестановки, кол-во инверсий, слагаемые (произведения), значения слагаемых
                                     // Ввод случайных чисел
                for (int i = 0; i < matrSq.GetLength(0); i++)
                {

                    Console.Write("{0}\t", matrSq[i]);

                }

            }
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("2. Ханойская башня.");

            const int K = 4;
            Console.WriteLine("Решение для {0}", K);
            SolutionHanoibns(K,'A','В','C');
            
        }

        private static void SolutionHanoibns(int k, char a, char b, char c) {
            if (k > 1){
                SolutionHanoibns(k - 1, a, c, b);
                Console.WriteLine("Переложить диска из {0} в {1}", a, b);
                SolutionHanoibns(k - 1, c, b, a);
            }

        }
    }
}
