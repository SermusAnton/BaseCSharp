using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task
{
    class Program
    {
        /*  1-есть матрица размера 3 на 3,она заполнена случайными числами в диапазоне от 0 до 5. Посчитать и вывести на экран количество цифр 3 в этой матрице.
            2-есть одномерный целочисленный массив (его длинна вводится с клавиатуры,массив заполняется случайными числами). Поменять в нем первый и последний элементы.
            3*- есть матрица размером 2 на 2 (заполняется случайными числами). Вычислить ее определитель.https://ru.m.wikipedia.org/wiki/Определитель
         */
        static void Main(string[] args)
        {
            
            // Задание 1.
            int matrX = 3; // Длина 
            int matrY = 3; // и ширина матрицы
            int count3=0;  // Кол-во цифр 3 
            Console.WriteLine("1. Матрица " + matrX + " на " + matrY);
            int[,] matrArr = new int[matrX, matrY]; // объявляем двухмерный массив типа байт
            Random ran = new Random(); // создаем последовательность случайных чисел

            for (int i = 0; i < matrX; i++)
            {
                for (int j = 0; j < matrY; j++)
                {
                    if ((matrArr[i, j] = ran.Next(0, 5))==3) count3++;
                    Console.Write("{0}\t", matrArr[i, j]);
                }
                Console.WriteLine();
            }  
            Console.WriteLine("Кол-во цифр 3: {0}\t", count3);
            /*
             Console.WriteLine();
             Console.WriteLine("Длина массива: {0}\t ", matrArr.Length);
             Console.WriteLine("Длина массива во всех измерениях: {0}\t ", matrArr.LongLength);
             Console.WriteLine("Размерность (ранг) массива: {0}\t ", matrArr.Rank);
             Console.WriteLine("Длина по X: {0}\t", matrArr.GetLength(0));
             Console.WriteLine("Длина по Y: {0}\t", matrArr.GetLength(1));  */

            Console.ReadKey();
            Console.WriteLine();

            // Задание 2. 
            // Есть одномерный целочисленный массив (его длина вводится с клавиатуры, массив заполняется случайными числами). 
            // Поменять в нем первый и последний элементы.
            Console.WriteLine("2. Одномерный массив.");
            int[] singleArr; // объявляем одномерный массив
            int singleLength = 0;
            Random ran2 = new Random(); // создаем последовательность случайных чисел
            try
            {
                Console.Write("Введите длину массива: ");
                singleLength = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
            }
            finally {
                if (singleLength > 0)
                {
                    Console.Write("Массив заполнен: ");
                    singleArr = new int[singleLength];   // инициализируем целочисленный массив, длинной заданной с клавиатуры
                    // Ввод случайных чисел
                    for (int i = 0; i < singleArr.Length; i++) // Можно использовать singleLength
                    {
                        singleArr[i] = ran2.Next(0, 100);
                        Console.Write("{0}\t", singleArr[i]);
                    }

                    // Меняем первый и последний элемент
                    int bufInt = singleArr[0];
                    singleArr[0] = singleArr[singleArr.Length - 1];
                    singleArr[singleArr.Length - 1] = bufInt;

                    // Выводим новый массив
                    Console.WriteLine();
                    Console.Write("Новый массив:    ");
                    for (int i = 0; i < singleArr.Length; i++) // Можно использовать singleLength
                    {
                        Console.Write("{0}\t", singleArr[i]);
                    }
                }
            }

            Console.ReadKey();
            Console.WriteLine();

            // Задание 3. 
            // Теория расчета http://www.cleverstudents.ru/matrix/computation_of_determinant.html
            // http://ru.solverbook.com/spravochnik/matricy/opredelitel-determinant-matricy/
            // Есть матрица размером 2 на 2 (заполняется случайными числами).
            // Вычислить ее определитель.https://ru.m.wikipedia.org/wiki/Определитель 
            Console.WriteLine();
            Console.WriteLine("3. Расчет определителя.");
            int[,] matrSq; // объявляем двухмерный массив, т.е. это будет квадратная матрица
            byte matrSqLength = 0;  // длина массива, т.е. размерность квадратной матрицы n
            Random ran3 = new Random(); // создаем последовательность случайных чисел
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
                matrSq = new int[matrSqLength, matrSqLength];   // инициализируем целочисленный квадратный массив, длинной заданной с клавиатуры
               
                // Ввод случайных чисел
                for (int i = 0; i < matrSq.GetLength(0); i++) 
                {
                    for (int j = 0; j < matrSq.GetLength(1); j++)
                    {
                        matrSq[i,j] = ran3.Next(-10, 10);
                        Console.Write("{0}\t", matrSq[i, j]);
                    }
                    Console.WriteLine();
                }

                permutations(matrSq);  // Получаем все перестановки, кол-во инверсий, слагаемые (произведения), значения слагаемых
               
            }

            Console.ReadKey();
            Console.WriteLine();
        }
       static int detSum = 0;  // храним значения слагаемых
        public static void permutations(int[,] matrSq) 
        {
            int n = matrSq.GetLength(0); // длина массива
            int[] m = new int[n];
          //  Determinate ij = new Determinate();
            // Инициализируем массив значениями от 1 до n
            for (int i = 1; i < n + 1; i++)
            {
                m[i - 1] = i;
            }
            Console.WriteLine("____________________");
            Console.WriteLine();
            // Сама функция перестановки
           perestanovka(m, 0, n, matrSq); // Исходный массив от 1 до n, начальное значение перестановки, конечное значение перестановки
           Console.WriteLine("Детерминат det(A)= {0} \t", detSum);
           // Console.ReadKey();
        }
        // рекурсивная функция
        public static void perestanovka(int[] m, int a, int n, int[,] matrSq) // Исходный массив от 1 до n, начальное значение перестановки, конечное значение перестановки
        {

           if (a == n) // БАЗОВЫЙ ВАРИАНТ от которого функция отталкивается, в частности когда допустим 6==6
            {
                    output(m, matrSq); // функция вывода
            }
            else
            {

                for (int i = a; i < n; i++) // Запускаем от a = 0 до n =6, где еще раз запускаем от a + 1 =1 до n = 6 
                {

                    exchange(m, a, i); // переставляем
                    perestanovka(m, a + 1, n, matrSq); // вызываем сами себя, только первоначальное значение увеличиваем на 1
                    exchange(m, a, i); 
                }
               
            }
           
        }

        // расчет и вывод
        public static void output(int[] m, int[,] matrSq)
        {
           int countI = countInversion(m);
            for (int i = 0; i < m.Length; i++)
            {
             //   if (m[i] < max_m) { ++countInversion; max_m = m[i]; }
                Console.Write( m[i] + " ");
            }
            Console.Write(" " + countI);
            Console.Write("\t " + Math.Pow(-1, countI));

              for (int i = 0; i < m.Length; i++)
              {
                Console.Write("*A" + (i+1) +  (m[i]).ToString());
             }
             Console.Write("= " +Math.Pow(-1, countI));
              int det =(int) Math.Pow(-1, countI);
              for (int i = 0; i < m.Length; i++)
              {
                    Console.Write("*"+matrSq[i, m[i] - 1].ToString() );
                    det *= matrSq[i, m[i] - 1];
                }
              Console.Write("= " + det);
              detSum += det;
              Console.WriteLine();
        }

        // функция перестановки
        public static void exchange(int[] m, int n, int k) // входной массив, индексы переставляемых значений массива
        {
            int c = 0;
            c = m[n];
            m[n] = m[k];
            m[k] = c;
        }
        // Расчет кол-ва инверсий
        public static int countInversion(int[] m) {
            int count = 0;
            for (int di = 0; di < m.Length; di++) {
                for (int dj = di; dj < m.Length; dj++) {
                    if (m[di] > m[dj]) { count++; } 
                }
            }
                return count;
        }
    }
}
