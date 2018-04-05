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

        static int detSum = 0;  // храним сумму значений слагаемых, для расчета определителя методом перестановок
        static int detB = 0;  // для расчета определителя через Минор
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

                
                // Расчет через СЛАГАЕМЫЕ
                // Получаем все перестановки, кол-во инверсий, слагаемые (произведения), значения слагаемых
                int[] order = new int[matrSq.GetLength(0)];
                // Инициализируем массив значениями от 1 до n
                for (int i = 1; i < matrSq.GetLength(0) + 1; i++)
                {
                    order[i - 1] = i;
                }
                Console.WriteLine("____________________");
                Console.WriteLine();
                // Сама функция перестановки
                Permutations(order, 0, matrSq.GetLength(0), matrSq); // Исходный массив от 1 до n, начальное значение перестановки, конечное значение перестановки
                Console.WriteLine();
                Console.WriteLine("Детерминат det(A)= {0} \t", detSum);
                // Конец расчета через СЛАГАЕМЫЕ
                

               
                // Принимаем, что в 1 индекс+1 = столбец, во 2 строка+индекс = строка

                /*
                int[,] MinorCur = GetMinor(matrSq, 3, 3);  
                // Вывод Минора
                Console.WriteLine("Вычеркиваем строку/столбец: 3");
                for (int i = 0; i < MinorCur.GetLength(0); i++) {
                    for (int j = 0; j < MinorCur.GetLength(1); j++) {
                       Console.Write("{0}\t", MinorCur[i, j]);
                    }
                    Console.WriteLine();
                }
              
                Console.WriteLine();
                if (MinorCur.GetLength(0)==2)
                    Console.WriteLine("Определитель матрицы 2 на 2 = " + CalcDet2x2(MinorCur));
                */

                // Расчет через МИНОР
                CalcDet(matrSq,1,1,1);
                Console.WriteLine();
                // Конец расчета через МИНОР
                Console.WriteLine("Детерминат через минор det(A) = " + detB);




                //
               
            }

            Console.ReadKey();
            Console.WriteLine();
        }


        // ---------------------------------------------------------------
        // Расчет определителя через перестановки и слагаемые
        // Рекурсия
        public static void Permutations(int[] order, int cur, int n, int[,] matrSq) // Исходный массив от 1 до n, начальное значение перестановки, конечное значение перестановки
        {

           if (cur == n) // БАЗОВЫЙ ВАРИАНТ от которого функция отталкивается, в частности когда допустим 6==6
            {
                Output(order, matrSq); // функция вывода
            }
            else
            {
                for (int i = cur; i < n; i++) // Запускаем от cur = 0 до n =6, где еще раз запускаем от cur + 1 =1 до n = 6 
                {
                    Change(order, cur, i); // переставляем
                    Permutations(order, cur + 1, n, matrSq); // вызываем сами себя, только первоначальное значение увеличиваем на 1
                    Change(order, cur, i); // переставляем еще раз для следующей последовательности, т.е. после выполнения каждого базового варианта
                }
               
            }
           
        }
        // Расчет и вывод
        public static void Output(int[] order, int[,] matrSq) // (массив с перестановкой, кв. матрица)
        {
            int countI = CountInversion(order);
            for (int i = 0; i < order.Length; i++)
            {
                Console.Write(order[i] + " ");
            }
            Console.Write(" " + countI);
            Console.Write("\t " + Math.Pow(-1, countI));

            for (int i = 0; i < order.Length; i++)
              {
                  Console.Write("*A" + (i + 1) + (order[i]).ToString());
             }
             Console.Write("= " +Math.Pow(-1, countI));
              int det =(int) Math.Pow(-1, countI);
              for (int i = 0; i < order.Length; i++)
              {
                  Console.Write("*" + matrSq[i, order[i] - 1].ToString());
                    det *= matrSq[i, order[i] - 1];
                }
              Console.Write("= " + det);
              detSum += det;
              Console.WriteLine();
        }
        // Функция перестановки
        public static void Change(int[] order, int start, int end) // входной массив, индексы переставляемых значений массива
        {
            int buff = order[start];
            order[start] = order[end];
            order[end] = buff;
        }
        // Расчет кол-ва инверсий
        public static int CountInversion(int[] order)
        {
            int count = 0;
            for (int di = 0; di < order.Length; di++)
            {
                for (int dj = di; dj < order.Length; dj++)
                {
                    if (order[di] > order[dj]) { count++; } 
                }
            }
                return count;
        }




        // ---------------------------------------------------------------
        // Расчет определителя через разложение по 1 строке (используя МИНОР)
        // Рекурсия
        public static void CalcDet(int[,] matrSq, uint curCol, uint curRow, int curMult) {
           
            if (matrSq.GetLength(0) == 2) {
                int buffDet = curMult * CalcDet2x2(matrSq);
                detB += buffDet;
                OutputMatr(matrSq, curMult, buffDet); // Выводим разложение
            } else {
                for (uint i = 0; i < matrSq.GetLength(0); i++) { // идем по столбикам, т.е. по 1 строке
                    // Рекусия(Берем минор(входной массив,идем по 1 строке,столбик+1),(столбик+1), строка, множитель)
                    // Множитель = текущий множитель * вычеркиваемый элемент * (-1)^(столбик + строка)
                    CalcDet(    GetMinor(matrSq, 1, (i + 1)),   (i + 1),  1,  curMult*matrSq[0, i] * ((int)Math.Pow(-1, (i+1 + curRow)))    );  
                }
            }

         }

        // Функция вывода матрицы
        public static void OutputMatr(int[,] outMatr, int outMult, int outDet) {   //  int outPow,
            for (int i = 0; i < outMatr.GetLength(0); i++ ) {
                if (i == 0) {
                    Console.Write(outMult + "*\t|");   // *(" + outPow + ")
                }
                else {
                    Console.Write("\t|");
                }
                for (int j = 0; j < outMatr.GetLength(1); j++) {
                    Console.Write("{0}\t", outMatr[i, j]);
                }
                if (i == 0) {
                    Console.Write("|=" + outDet );
                }
                else {
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("____________________");
        } 
        
        // Выделяем минор из квдаратной матрицы по заданному столбцу/строке
        public static int[,] GetMinor(int[,] matrSq, uint nCol, uint nRow) {  // Исходная матрица, номер вычеркиваемой строки и столбца (начинаем с 1)
            int[,] Minor = new int[matrSq.GetLength(0) - 1, matrSq.GetLength(0) - 1]; // Размер минора меньше на 1 по ст. и стр. 
            uint colMinor = 1, rowMinor = 1; // Текущие ст. и строка минора, начинаем с 1

            for (int i = 0; i < matrSq.GetLength(0); i++) {  // Идем по столбцам
                if ((i + 1) != nCol) {  // Если не равно вычеркиваемому столбцу, то идем по строкам
                    rowMinor = 1; //  
                    for (int j = 0; j < matrSq.GetLength(1); j++) {    // Идем по строкам
                        if ((j + 1) != nRow) { // Если не равно вычеркиваемому  строке, то присваиваем
                            Minor[colMinor - 1, rowMinor - 1] = matrSq[i, j]; // Для получения индексов массива - 1
                            rowMinor++;
                        }
                    }
                    colMinor++;  // увеличиваем только, когда не равно вычеркиваемому столбцу
                }
            }

            return Minor;
        }

        // Вычисляем определитель квадратной матрицы 2 на 2
        public static int CalcDet2x2(int[,] matr2x2) {
            return matr2x2[0, 0] * matr2x2[1, 1] - matr2x2[0, 1] * matr2x2[1, 0];
        }
        //




    }
}
