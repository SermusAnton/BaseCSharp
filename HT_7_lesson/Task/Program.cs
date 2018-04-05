using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task
{
    class Program
    {
        /*  Отсортировать квадратную матрицу, заполненую произвольными значениями, произвольного размера N  
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка матрицы.");
            int[,] matrSq; // объявляем двухмерный массив, т.е. это будет квадратная матрица
            int[,] matrSq4; // объявляем двухмерный массив, т.е. это будет квадратная матрица
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
                Console.WriteLine("Исходная матрица: ");
                matrSq = new int[matrSqLength, matrSqLength];   // инициализируем целочисленный квадратный массив, длинной заданной с клавиатуры
                matrSq4 = new int[matrSqLength, matrSqLength];   // инициализируем целочисленный квадратный массив, длинной заданной с клавиатуры
                // Ввод случайных чисел
                for (int i = 0; i < matrSq.GetLength(0); i++) 
                {
                    for (int j = 0; j < matrSq.GetLength(1); j++)
                    {
                        matrSq[i, j] = ran3.Next(-10, 10);
                    //    matrSq1[i, j] = matrSq[i, j];
                    //    matrSq2[i, j] = matrSq[i, j];
                    //    matrSq3[i, j] = matrSq[i, j];
                        matrSq4[i, j] = matrSq[i, j];
                       Console.Write("{0}\t", matrSq[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Способ 1. Пузырьковая сортировка. Цикл. Одномерный массив.");

                int [] buffMatr= new int [matrSq.Length];
               
                int bufI = 0;
                Console.WriteLine();
                foreach (int value in matrSq) {
                    buffMatr[bufI++] = value;
                   Console.Write(value);

                }
                // --------------------
                // Сортировка пузырьком 
                int countChange = 0;
                
                for (int i = 0; i < buffMatr.Length;i++ ) {   // Проходим по всем элементам массива 
                  //  countChange = 0;
                    for (int j = 0; j < buffMatr.Length-i-1; j++) {  // Берем на 1 элемент меньше каждую итерацию
                        if (buffMatr[j] > buffMatr[j+1]) {
                            buffMatr = Change(buffMatr, j, j + 1); // Перемещаем если этот элемент больше вперед
                            countChange++;
                        }
                    
                    }
                    if (countChange == 0) break;
                }

                Console.WriteLine();

                int curI=0, curJ = 0;
                foreach (int value in buffMatr) {
                    Console.Write(value);
                    matrSq[curI,curJ] = value;
                    curJ++;
                    if (curJ == matrSq.GetLength(1)) { curJ=0; curI++; }
                }
                Console.WriteLine();
                Console.WriteLine("Отсортированная матрица: ");
               
                // Выводим матрицу
                for (int i = 0; i < matrSq.GetLength(0); i++) {
                    for (int j = 0; j < matrSq.GetLength(1); j++) {
                        Console.Write("{0}\t", matrSq[i, j]);
                    }
                    Console.WriteLine();
                }


                Console.WriteLine();
                Console.WriteLine("Способ 2. Быстрый способ. Рекурия. Одномерный массив.");
               
                
                int[] buffMatr2 = new int[matrSq4.Length];
                bufI = 0;
                Console.WriteLine();
                foreach (int value in matrSq4) {
                    buffMatr2[bufI++] = value;
                    Console.Write(value);

                }

                QuickSort(buffMatr2,0,(buffMatr2.Length-1));
                    
                 Console.WriteLine();

                 curI = 0; curJ = 0;
                foreach (int value in buffMatr2) {
                    Console.Write(value);
                    matrSq4[curI,curJ] = value;
                    curJ++;
                    if (curJ == matrSq4.GetLength(1)) { curJ=0; curI++; }
                }
                Console.WriteLine();
                Console.WriteLine("Отсортированная матрица: ");
               
                // Выводим матрицу
                for (int i = 0; i < matrSq4.GetLength(0); i++) {
                    for (int j = 0; j < matrSq4.GetLength(1); j++) {
                        Console.Write("{0}\t", matrSq4[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
            Console.WriteLine();
 
        }

         // Функция перестановки
        public static int [,] Change(int[,] order, int startI, int startJ, int endI, int endJ) // входной массив, индексы переставляемых значений массива
        {
            int buff = order[startI,startJ];
            order[startI, startJ] = order[endI,endJ];
            order[endI, endJ] = buff;
            return order;
        }
        // Функция перестановки
        public static int[] Change(int[] order, int start, int end) // входной массив, индексы переставляемых значений массива
        {
            int buff = order[start];
            order[start] = order[end];
            order[end] = buff;
            return order;
        }
        // Алгоритм быстрой сортировки. Теория:
        // https://ru.wikipedia.org/wiki/%D0%91%D1%8B%D1%81%D1%82%D1%80%D0%B0%D1%8F_%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0
        // Используем разбиение Хоара
        // https://forkettle.ru/vidioteka/programmirovanie-i-set/108-algoritmy-i-struktury-dannykh/sortirovka-i-poisk-dlya-chajnikov/1010-metod-khoara-bystraya-sortirovka-quick-sort



        public static void QuickSort(int[] buffAr, int start, int end) {
            if (start >= end) {
                return;
            }
                int pivot = Partition(buffAr,start,end);
                QuickSort(buffAr,start,pivot-1);
                QuickSort(buffAr, pivot+1, end);
        }

        public static int Partition(int[] buffAr, int start, int end) {
           int marker = start;
           for (int i = start; i <= end; i++ ) {
                if (buffAr[i] <= buffAr[end]) {
                   buffAr = Change(buffAr,i,marker);
                   marker += 1;
               }
           }
           return marker - 1;
        }
    }
}
