using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task
{
    class Program
    {
        // 1.Дана квадратная матрица, заполненная случайными числами. Определить есть ли введенный пользователем элемент в этой матрице. 
        // 2.Дана квадратная матрица, заполненная случайными числами. Определить есть ли введенный пользователем элемент в этой матрице бинарным поиском.
        // 3.Дана квадратная матрица, заполненная случайными числами. Определить есть ли введенный пользователем элемент в верхнем левом углу данной матрицы бинарным поиском.


        static void Main(string[] args) {
            Console.WriteLine("Поиск в матрице.");
            int[,] matrSq1, matrSq2, matrSq3;  // объявляем двухмерный массив заданной размерности, т.е. это будет квадратная матрица
            byte matrSqLength1, matrSqLength2, matrSqLength3;  // длина массива, т.е. размерность квадратной матрицы n
            int findValue1, findValue2, findValue3;  // искомое значение
            int? indexFindValue1, indexFindValue2, indexFindValue3; // индекс, позиция исходного элемента

            Console.WriteLine("1. Определить, есть ли элемент в кв. матрице.");
            matrSqLength1 = InputSizeMatrix();
            matrSq1 = new int[matrSqLength1, matrSqLength1];
            matrSq1=OutputSqMatrix(matrSq1);
            findValue1 = InputFindValue();
            indexFindValue1 = SimpleFindValue(matrSq1, findValue1);
            if (indexFindValue1 != null) {
                Console.WriteLine("Позиция(индекс) первого попадания искомого элемента: " + indexFindValue1);
            } else {
                Console.WriteLine("Такого элемента нет в матрице");
            }
            Console.WriteLine();

            Console.WriteLine("2. Определить, есть ли элемент в кв. матрице, используя бинарный поиск.");
            matrSqLength2 = InputSizeMatrix();
            matrSq2 = new int[matrSqLength2, matrSqLength2];
            matrSq2 = OutputSqMatrix(matrSq2);
            findValue2 = InputFindValue();
            int[] buffArray2 = SquareToSingleArray(matrSq2);  // Преобразуем двумерную матрицу в одномерный массив
            QuickSort(buffArray2, 0, (buffArray2.Length - 1));   // Для бинарного поиска, необходимо отсортировать матрицу. Используем быструю сортировку
            OutputSortArray(buffArray2);  // Выводим сортированный массив
            indexFindValue2 = BinarySort(buffArray2, findValue2);  // Индекс элемента в сортированном массиве
            if (indexFindValue2 != null) {
                Console.WriteLine("Позиция(индекс) первого попадания искомого элемента в сортированном одномерном массиве: " + indexFindValue2);
            } else {
                Console.WriteLine("Такого элемента нет в матрице");
            }
            Console.WriteLine();

            Console.WriteLine("3. Определить, есть ли элемент в верхнем левом углу кв. матрице, используя бинарный поиск.");
            matrSqLength3 = InputSizeMatrix();
            matrSq3 = new int[matrSqLength3, matrSqLength3];
            matrSq3 = OutputSqMatrix(matrSq3);
            findValue3 = InputFindValue();
            //  SquareToSingleArrayQuarter(int[,] inSquareMatrix, int indColLeft,int indRowLeft, int indColRight, int indRowRight) ЗАДАЕМ ВЕРХНИЙ ЛЕВЫЙ УГОЛ
            int[] buffArray3 = SquareToSingleArrayAngular(matrSq3);
            // int[] buffArray3 = SquareToSingleArrayQuarter(matrSq3, 0, 0, matrSq3.GetLength(0)/2, matrSq3.GetLength(1)/2);  // Преобразуем двумерную матрицу в одномерный массив, только берем левый верхний угол
            QuickSort(buffArray3, 0, (buffArray3.Length - 1));   // Для бинарного поиска, необходимо отсортировать матрицу. Используем быструю сортировку
            OutputSortArray(buffArray3);  // Выводим сортированный массив
            indexFindValue3 = BinarySort(buffArray3, findValue3);  // Индекс элемента в сортированном массиве
            if (indexFindValue3 != null) {
                Console.WriteLine("Позиция(индекс) первого попадания искомого элемента в сортированном одномерном массиве: " + indexFindValue3);
            } else {
                Console.WriteLine("Такого элемента нет в матрице");
            }

            Console.ReadKey();
         
 
        }

        public static int? BinarySort(int [] inArray, int inFindValue) {
            if (inArray.Length == 0 || (inFindValue < inArray[0]) || (inFindValue > inArray[inArray.Length - 1])) return null;  // Отсекаем ошибки, если длинна массива 0
            int left = 0, right = inArray.Length;
            while (left<right) {
                int middle = left + (right - left) / 2;
                if (inFindValue <= inArray[middle]) {
                    right = middle;
                } else {
                    left = middle+1;
                }
               
            }
            if (inArray[left] == inFindValue) {
                return left;
            } else {
                return null;
            }

        }


        // Преобразование двумерной матрицы в одномерную и вывод на экран 
        public static void OutputSortArray(int[] inArray) {
            Console.WriteLine("Cортированный производный одномерный массив: ");
            foreach (int value in inArray) {
                Console.Write(value + "\t");
            }
            Console.WriteLine();
        }

        // Преобразование двумерной матрицы в одномерную и вывод на экран 
        public static int[] SquareToSingleArray(int [,] inSquareMatrix) {
            int[] buffMatr = new int[inSquareMatrix.Length];
            int bufI = 0;
            Console.WriteLine("Несортированный производный одномерный массив: ");
            foreach (int value in inSquareMatrix) {
                buffMatr[bufI++] = value;
                Console.Write(value + "\t");
            }
            Console.WriteLine();
            return buffMatr;
        }
        // Преобразование двумерной матрицы в одномерную и вывод на экран, берем только нужные элементы 
        public static int[] SquareToSingleArrayQuarter(int[,] inSquareMatrix, int indColLeft,int indRowLeft, int indColRight, int indRowRight) {
            int[] buffMatr = new int[(indColRight-indColLeft)*(indRowRight - indRowLeft)];
            int bufI = 0;
            Console.WriteLine("Несортированный производный одномерный массив: ");
            for (int i= indColLeft; i< indColRight; i++) {
                for (int j = indRowLeft; j < indRowRight; j++) {
                    buffMatr[bufI++] = inSquareMatrix[i, j];
                    Console.Write(inSquareMatrix[i, j] + "\t");
                }
            }
            Console.WriteLine();
            return buffMatr;
        }
        // Преобразование двумерной матрицы в одномерную и вывод на экран, левого угла  
        public static int[] SquareToSingleArrayAngular(int[,] inSquareMatrix) {
            int sumI = 0;
            for (int i = 0; i < inSquareMatrix.GetLength(0); i++) {
                sumI += i;
            }
            int[] buffMatr = new int[sumI];
            int bufI = 0;
            Console.WriteLine("Несортированный производный одномерный массив, левый угол: ");
            for (int i = 0; i < inSquareMatrix.GetLength(0); i++) {
                for (int j = 0; j < inSquareMatrix.GetLength(1); j++) {
                    if (i< (inSquareMatrix.GetLength(1)-j-1)) {
                        buffMatr[bufI++] = inSquareMatrix[i, j];
                        Console.Write(inSquareMatrix[i, j] + "\t");
                    }
                }
            }
            Console.WriteLine();
            return buffMatr;
        }
        // Ввод размера матрицы
        public static byte InputSizeMatrix() {  
            byte matrSqLength = 0;
            try {
                Console.Write("Введите рамер матрицы матрицы (0-255), n = ");
                matrSqLength = byte.Parse(Console.ReadLine());
            }
            catch (Exception ex) {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
            }
            return matrSqLength;
        }
        // Инициализация и вывод матрицы
        public static int[,] OutputSqMatrix(int [,] inSqMatrix) {
            Console.WriteLine("Исходная матрица: ");
            Random ran = new Random(); // создаем последовательность случайных чисел
            // Ввод случайных чисел
            for (int i = 0; i < inSqMatrix.GetLength(0); i++) {
                for (int j = 0; j < inSqMatrix.GetLength(1); j++) {
                    inSqMatrix[i, j] = ran.Next(-10, 10);
                    Console.Write("{0}\t", inSqMatrix[i, j]);
                }
                Console.WriteLine();
            }
            return inSqMatrix;
        }
        // Ввод искомого элемента
        public static int InputFindValue() {
            int findValue = 0;
            try {
                Console.Write("Введите искомое значение: ");
                findValue = int.Parse(Console.ReadLine());
            }
            catch (Exception ex) {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
            }
            return findValue;
        }
        // Поиск значения простым перебором
        public static int? SimpleFindValue(int[,] inSqMatrix, int inFindValue) {
            int indValue = 0;
            foreach (int value in inSqMatrix) {
                if (inFindValue == value) {
                    return indValue;
                }
                indValue++;
            }
            return null;
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
