using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task
{
    class Program
    {
        /*  Курсовое задание: 
         *  1-реализовать умножение матрицы на матрицу. 
         *  2-реализовать ООП структуру телефонного справочника,чтоб в него можно было добавлять и удалять записи.
         */    
        static void Main(string[] args)
        {
            // Теория умножения матриц:
            // https://ru.wikipedia.org/wiki/%D0%A3%D0%BC%D0%BD%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D0%B5_%D0%BC%D0%B0%D1%82%D1%80%D0%B8%D1%86
            Console.WriteLine("1. Умножение матрицы на матрицу.");
            int[,] matrTerm1; // Матрица 1
            int matrN1 = 2;  // Кол-во строк матрицы 1
            int matrM1 = 2;  // Кол-во стролбцов матрицы 1
            int[,] matrTerm2; // Матрица 2
            int matrN2 = 2;  // Кол-во строк матрицы 2
            int matrM2 = 2;  // Кол-во столбцов матрицы 2
            // Искомая, производная матрица
            int[,] matrMulti;
            int[,] matrMultiStrassen;
            try {
                Console.Write("Матрица 1, введите кол-во строк , n1 = ");
                matrN1 = int.Parse(Console.ReadLine());
                Console.Write("Матрица 1, введите кол-во столбцов , m1 = ");
                matrM1 = int.Parse(Console.ReadLine());
                matrN2 = matrM1;
                Console.WriteLine("Матрица 2, у согласованной матрицы кол-во строк д.б. равно, n2 = m1 = " + matrN2);
                Console.Write("Матрица 2, введите кол-во столбцов , m2 = ");
                matrM2 = int.Parse(Console.ReadLine());
                if (matrN1 < 2 || matrM1 < 2 || matrM2 < 2) {
                    matrN1 = 2; matrM1 = 2; matrN2 = 2; matrM2 = 2;
                    throw new ArgumentException("Значение длины матрицы укажите больше или равное 2.");                     
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Некорректно введены данные. Ошибка: " + ex.Message);
            }
            finally {
                Console.WriteLine("Матрица 1");
                matrTerm1 = InitMatr(new int[matrN1, matrM1], 0, 10);   // инициализируем матрицу 1 случайными значениями от 0 до 10
                OutputMatr(matrTerm1);  // выводим матрицу 1
                Console.WriteLine("Матрица 2");
                matrTerm2 = InitMatr(new int[matrN2, matrM2], 0, 10);   // инициализируем матрицу 2 случайными значениями от 0 до 10
                OutputMatr(matrTerm2);  // выводим матрицу 2
                //Размерность производной матрицы  matrN1 на  matrM2
                Console.WriteLine("Производная матрица");
                matrMulti = MultiplicationMatr(matrTerm1, matrTerm2);
                OutputMatr(matrMulti);  // выводим производную матрицу

                int eqLength = (new List<int> { matrN1, matrM1, matrN2, matrM2 }).Max(); // Берем самое большое значение длины
                eqLength = (Math.Log(eqLength, 2) % 1 == 0) ?  eqLength: (int)Math.Pow(2,((int)(Math.Log(eqLength, 2)) + 1));

             //   Console.WriteLine("Матрица 1 после выравнивания");
                matrTerm1 = MatrNewLog2(matrTerm1, eqLength);   
             //   OutputMatr(matrTerm1);  // выводим матрицу 1
             //   Console.WriteLine("Матрица 2 после выравнивания");
                matrTerm2 = MatrNewLog2(matrTerm2, eqLength);
                //   OutputMatr(matrTerm2);  // выводим матрицу 2
                Console.WriteLine("Производная матрица, алгоритм Штрассена");
                matrMultiStrassen = MultiStrassen(matrTerm1, matrTerm2);  // Алгоритм Штрассена, рекурсивная функция 
                matrMultiStrassen = MatrOldLength(matrMultiStrassen, matrN1, matrM2);  // Восстанавливаем размер матрицы
                OutputMatr(matrMultiStrassen);
            }

            Console.WriteLine("Для завершения нажмите любую клавишу...");
            Console.ReadKey();
            
        }
        // Функция умножения матриц по алгоритму Штрассена
        // https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%A8%D1%82%D1%80%D0%B0%D1%81%D1%81%D0%B5%D0%BD%D0%B0
        public static int[,] MultiStrassen(int[,] inA, int[,] inB) {
            if (inA.GetLength(0) <= 2) {   // На самом деле, если меньше 64 
                return MultiplicationMatr(inA, inB);
            }
            int n = inA.GetLength(0) / 2;
            int[,] a11 = new int[n, n];
            int[,] a12 = new int[n, n];
            int[,] a21 = new int[n, n];
            int[,] a22 = new int[n, n];

            int[,] b11 = new int[n, n];
            int[,] b12 = new int[n, n];
            int[,] b21 = new int[n, n];
            int[,] b22 = new int[n, n];

            SplitMatr(inA, a11, a12, a21, a22);
            SplitMatr(inB, b11, b12, b21, b22);

            int[,] p1 = MultiStrassen(SumMatr(a11, a22), SumMatr(b11, b22));
            int[,] p2 = MultiStrassen(SumMatr(a21, a22), b11);
            int[,] p3 = MultiStrassen(a11, SubMatr(b12, b22));
            int[,] p4 = MultiStrassen(a22, SubMatr(b21, b11));
            int[,] p5 = MultiStrassen(SumMatr(a11, a12), b22);
            int[,] p6 = MultiStrassen(SubMatr(a21, a11), SumMatr(b11, b12));
            int[,] p7 = MultiStrassen(SubMatr(a12, a22), SumMatr(b21, b22));

            int[,] c11 = SumMatr(SumMatr(p1, p4), SubMatr(p7, p5));
            int[,] c12 = SumMatr(p3, p5);
            int[,] c21 = SumMatr(p2, p4);
            int[,] c22 = SumMatr(SubMatr(p1, p2), SumMatr(p3, p6));

            return MergeMatr(c11, c12, c21, c22);

        }
        // Разбиваем матрицу
        public static void SplitMatr(int[,] inMatr, int[,] inMatr11, int[,] inMatr12, int[,] inMatr21, int[,] inMatr22) {
            for (int i = 0; i < inMatr.GetLength(0)/2; i++) {
                for (int j = 0; j < inMatr.GetLength(1)/2; j++) {
                    inMatr11[i, j] = inMatr[i, j];
                    inMatr12[i, j] = inMatr[i, j+ inMatr.GetLength(1) / 2];
                    inMatr21[i, j] = inMatr[i + inMatr.GetLength(0) / 2, j];
                    inMatr22[i, j] = inMatr[i + inMatr.GetLength(0) / 2, j + inMatr.GetLength(1) / 2];
                }
            }
        }
        // Собираем матрицу
        public static int[,] MergeMatr(int[,] inMatr11, int[,] inMatr12, int[,] inMatr21, int[,] inMatr22) {
            int[,] outMatr = new int[inMatr11.GetLength(0)*2, inMatr11.GetLength(1) * 2];
            for (int i = 0; i < outMatr.GetLength(0) / 2; i++) {
                for (int j = 0; j < outMatr.GetLength(1) / 2; j++) {
                    outMatr[i, j] = inMatr11[i, j];
                    outMatr[i, j + outMatr.GetLength(1) / 2]= inMatr12[i, j];
                    outMatr[i + outMatr.GetLength(0) / 2, j] = inMatr21[i, j];
                    outMatr[i + outMatr.GetLength(0) / 2, j + outMatr.GetLength(1) / 2] = inMatr22[i, j];
                }
            }
            return outMatr;
        }
        // Функция выравнивания матрицы до длины n^2
        public static int[,] MatrNewLog2(int[,] inMatr, int inLength) {
            int[,] outMatr = new int[inLength, inLength];
            for (int i = 0; i < outMatr.GetLength(0); i++) {
                for (int j = 0; j < outMatr.GetLength(1); j++) {
                    if (i < inMatr.GetLength(0) && j < inMatr.GetLength(1)) {
                        outMatr[i, j] = inMatr[i, j];
                    } else {
                        outMatr[i, j] = 0;
                    }
                }
            }
            return outMatr;
        }
        // Функция восстановления матрицы 
        public static int[,] MatrOldLength(int[,] inMatr, int inN, int inM) {
            int[,] outMatr = new int[inN, inM];
            for (int i = 0; i < outMatr.GetLength(0); i++) {
                for (int j = 0; j < outMatr.GetLength(1); j++) {
                    outMatr[i, j] = inMatr[i, j];             
                }
            }
            return outMatr;
        }
        // Сложение двух матриц одинаковой размерности
        public static int[,] SumMatr(int[,] inMatr1, int[,] inMatr2) {
            int[,] outMatr = new int[inMatr1.GetLength(0), inMatr1.GetLength(1)];
            for (int i = 0; i < outMatr.GetLength(0); i++) {
                for (int j = 0; j < outMatr.GetLength(1); j++) {
                    outMatr[i, j] = inMatr1[i, j] + inMatr2[i, j];
                }
            }
            return outMatr;

        }
        // Вычитание двух матриц одинаковой размерности
        public static int[,] SubMatr(int[,] inMatr1, int[,] inMatr2) {
            int[,] outMatr = new int[inMatr1.GetLength(0), inMatr1.GetLength(1)];
            for (int i = 0; i < outMatr.GetLength(0); i++) {
                for (int j = 0; j < outMatr.GetLength(1); j++) {
                    outMatr[i, j] = inMatr1[i, j] - inMatr2[i, j];
                }
            }
            return outMatr;

        }
        // Функция неоптимизированного умножения матриц 
        public static int[,] MultiplicationMatr(int[,] inMatr1, int[,] inMatr2) {
            int[,] outMatr = new int [inMatr1.GetLength(0), inMatr2.GetLength(1)];
            for (int i = 0; i < outMatr.GetLength(0); i++) {
                for (int j = 0; j < outMatr.GetLength(1); j++) {
                    outMatr[i, j] = 0;
                    for (int k = 0; k < inMatr1.GetLength(1); k++) {   // Идем по общей стороне, м.б. inMatr2.GetLength(2)
                        outMatr[i, j] += inMatr1[i, k] * inMatr2[k, j];
                    }
                }              
            }
            return outMatr;
        }
        // Функция инициализации матрицы
        public static int[,] InitMatr(int[,] outMatr, int fromInt, int toInt) {  
            Random ranInt = new Random(); // создаем последовательность случайных чисел           
            for (int i = 0; i < outMatr.GetLength(0); i++) {
               for (int j = 0; j < outMatr.GetLength(1); j++) {
                    outMatr[i, j] = ranInt.Next(fromInt, toInt);
               }               
            }
            return outMatr;
        }
        // Функция вывода матрицы
        public static void OutputMatr(int[,] outMatr) {   
            for (int i = 0; i < outMatr.GetLength(0); i++ ) {
                Console.Write("\t|");
                for (int j = 0; j < outMatr.GetLength(1); j++) {
                    Console.Write("{0}\t", outMatr[i, j]);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine();   // "____________________"
        } 
    }
}
