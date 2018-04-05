using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task
{

    // ДЗ: есть квадратная матрица (ее размерность указывает пользователь),которая заполнена произвольными числами. 
    // Необходимо отсортировать каждую ее строку (не всю матрицу вцелом, а каждую строчку отсортировать в порядке возрастания).
    public class MatrixSqure {
        long[,] matrSq;

        public long[,] MatrSq {
            get { return matrSq; }
            set { matrSq = value; }
        }

        //public byte NMatrSq {   // Длина матрицы
        //    get { return (byte)matrSq.GetLength(0); }
        //    set { matrSq = value; }
        //}

        public MatrixSqure() {          // Конструктор по умолчанию
            matrSq = new long [0,0];    // первоначальная инициализация 0 
        }

        public MatrixSqure(byte n){     // Конструктор для инициализации массива определенной длиной 
            matrSq = new long[n, n];    // Квадратная матрица  
            InitMartix(); // Инициализация
        }

        private void InitMartix() {
           Random ran = new Random(); // создаем последовательность случайных чисел
           for (int i = 0; i < matrSq.GetLength(0); i++) {
               for (int j = 0; j < matrSq.GetLength(1); j++) {
                   matrSq[i, j] = ran.Next(0, 100);    // Ввод случайных чисел
                }
            }
        }

        public void OutputMartix() {   // Вывод матрицы
            for (int i = 0; i < matrSq.GetLength(0); i++) {
                for (int j = 0; j < matrSq.GetLength(1); j++) {
                   Console.Write("{0}\t", matrSq[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void SortRow() {
            long[] buffA;   // Объявляем буфферный массив для записи промежуточных значений

            for (int i = 0; i < matrSq.GetLength(0); i++) {   // Строки
                buffA = new long[matrSq.GetLength(1)];
                for (int j = 0; j < matrSq.GetLength(1); j++) {
                    buffA[j] = matrSq[i, j];
                }
                buffA = BubbleSort(buffA);
                for (int j = 0; j < matrSq.GetLength(1); j++) {
                     matrSq[i, j]=buffA[j];
                }
           }
        }

        public long[] BubbleSort(long[] a) {
            for (long i = 0; i < a.Length; i++) {
                for (long j = a.Length - 1; j > i; j--) {
                    if (a[j - 1] > a[j]) {
                        Change(a, j - 1, j);
                    }
                }
            }
            return a;
        }
        // Функция перестановки
        public void Change(long[] order, long start, long end) // входной массив, индексы переставляемых значений массива
        {
            long buff = order[start];
            order[start] = order[end];
            order[end] = buff;
        }
    
    }

    class Program {
        static void Main(string[] args) {
           MatrixSqure matrSqCur;
           byte matrSqLength = 0;  // размерность квадратной матрицы n
           try {
                Console.Write("Введите рамер матрицы (0-255), n = ");
                matrSqLength = byte.Parse(Console.ReadLine());

            }
            catch (Exception ex) {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
            }
            finally {
               matrSqCur = new MatrixSqure(matrSqLength); // Инициализируем длиной N
               Console.WriteLine();
               Console.WriteLine("Исходная матрица:");
               matrSqCur.OutputMartix(); // Выводим матрицу
               matrSqCur.SortRow();
               Console.WriteLine();
               Console.WriteLine("Сортированная матрица:");
               matrSqCur.OutputMartix(); // Выводим матрицу
                
            }
            Console.ReadKey();
        }

       
    }
   
}
