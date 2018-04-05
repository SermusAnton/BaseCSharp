using System;

namespace lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {   /*
            Console.WriteLine("1. Транспорирование матрицы");
            int[,] matrSq; // объявляем двухмерный массив, т.е. это будет квадратная матрица
            byte matrSqLengthM = 0;  // Столбцы M
            byte matrSqLengthN = 0;  // Строки N
            Random ran3 = new Random(); // создаем последовательность случайных чисел
            try
            {
                Console.Write("Введите кол-во столбцов  матрицы(0-255),  m= ");
                matrSqLengthM = byte.Parse(Console.ReadLine());
                Console.Write("Введите кол-во строк  матрицы(0-255),  n= ");
                matrSqLengthN = byte.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Массив: ");
                Console.WriteLine("____________________");
                matrSq = new int[matrSqLengthM, matrSqLengthN];   // инициализируем целочисленный массив, длинной заданной с клавиатуры

                // Ввод случайных чисел
                for (int i = 0; i < matrSq.GetLength(0); i++)
                {
                    for (int j = 0; j < matrSq.GetLength(1); j++)
                    {
                        matrSq[i, j] = ran3.Next(-10, 10);
                        Console.Write("{0}\t", matrSq[i, j]);
                    }
                    Console.WriteLine();
                }

                matrSq= Permutations(matrSq); 
                Console.WriteLine("Вывод транспонированной матрицы");
                // Вывод матрицы
                for (int i = 0; i < matrSq.GetLength(0); i++)
                {
                    for (int j = 0; j < matrSq.GetLength(1); j++)
                    {
                       Console.Write("{0}\t", matrSq[i, j]);
                    }
                    Console.WriteLine();
                }

            }
            Console.ReadKey();

            Console.WriteLine("2. Главная диагональ");
            int[,] matrSq2; // объявляем двухмерный массив, т.е. это будет квадратная матрица
            byte matrSqLength = 0;  // Столбцы M
            Random ran4 = new Random(); // создаем последовательность случайных чисел
            try
            {
                Console.Write("Введите размерность квадратной матрицы(0-255),  N= ");
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
                matrSq2 = new int[matrSqLength, matrSqLength];   // инициализируем целочисленный массив, длинной заданной с клавиатуры

                // Ввод случайных чисел
                for (int i = 0; i < matrSq2.GetLength(0); i++)
                {
                    for (int j = 0; j < matrSq2.GetLength(1); j++)
                    {
                        matrSq2[i, j] = ran4.Next(-10, 10);
                        Console.Write("{0}\t", matrSq2[i, j]);
                    }
                    Console.WriteLine();
                }

                int sledMatr = GetSled(matrSq2);
                Console.WriteLine("След матрицы " + sledMatr);
                

            }
            Console.ReadKey();

             */
            Console.WriteLine("3. Ниже диагонали 1");
            int[,] matrSq; // объявляем двухмерный массив, т.е. это будет квадратная матрица
            byte matrSqLength = 0;  // Столбцы M
            Random ran3 = new Random(); // создаем последовательность случайных чисел
            try
            {
                Console.Write("Введите кол-во столбцов  матрицы(0-255),  N= ");
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
                matrSq = new int[matrSqLength, matrSqLength];   // инициализируем целочисленный массив, длинной заданной с клавиатуры

                // Ввод случайных чисел
                for (int i = 0; i < matrSq.GetLength(0); i++)
                {
                    for (int j = 0; j < matrSq.GetLength(1); j++)
                    {
                        matrSq[i, j] = ran3.Next(-10, 10);
                        Console.Write("{0}\t", matrSq[i, j]);
                    }
                    Console.WriteLine();
                }

                matrSq = Diag1(matrSq);
                Console.WriteLine("Вывод матрицы, заполненой ниже диагонали 1");
                // Вывод матрицы
                for (int i = 0; i < matrSq.GetLength(0); i++)
                {
                    for (int j = 0; j < matrSq.GetLength(1); j++)
                    {
                        Console.Write("{0}\t", matrSq[i, j]);
                    }
                    Console.WriteLine();
                }

            }
            Console.ReadKey();


        }

        /*  public static int GetSled(int [,] matrIn) {
              int sled = 0;
              for (int i = 0; i < matrIn.GetLength(0); i++)
              {

                      sled += matrIn[i, i];


              }

              return sled;
          }*/

        public static int[,] Diag1(int[,] matrIn)
        {
            int [,] matrOut =new int [matrIn.GetLength(0), matrIn.GetLength(1)];
            for (int i = 0; i < matrIn.GetLength(0); i++)
            {
                for (int j = 0; j < matrIn.GetLength(0); j++)
                {
                    if (i > j)
                    {
                        matrOut[i, j] = 1;
                    }
                    else {
                        matrOut[i, j] = matrIn[i,j];
                    }
                }

            }

            return matrOut;
        }












    }
}
