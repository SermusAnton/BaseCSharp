using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        /*
         Домашнее задание: 
         1 - с клавиатуры вводятся два числа, найти их среднее арифметическое. 
         2 - с клавиатуры вводится целое число, определите является ли оно четным. 
         3 - задание со звездочкой, с клавиатуры вводится число, вывести на экран элементы последовательности Фибоначчи, начиная с 1 элемента по введенное число.  
         */
        static void Main(string[] args){

            // Задание 1
            Console.WriteLine("Расчет среднего арифмитического значения. ");
            Console.Write("х1 = ");
                string x1Str = Console.ReadLine();
                x1Str = x1Str.Length == 0 ? "0" : x1Str;
            Console.Write("х2 = ");
                string x2Str = Console.ReadLine();
                x2Str = x2Str.Length == 0 ? "0" : x2Str;
            try {
                Console.WriteLine("(" + x1Str + "+" + x2Str + ")/2 = {0}", (decimal.Parse(x1Str) + decimal.Parse(x2Str)) / 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
            // Задание 2
            Console.WriteLine("Определение четности числа. ");
            Console.Write("Введите целое число: ");
            try
            {
                Console.WriteLine(int.Parse(Console.ReadLine()) % 2 != 0 ? "не четное" : "четное");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
            // Задание 3
            /* Чи́сла Фибона́ччи (также Фибона́чи) — элементы числовой последовательности
                 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, … (последовательность A000045 в OEIS),
                в которой первые два числа равны либо 1 и 1, либо 0 и 1, а каждое последующее число равно сумме двух предыдущих чисел. Названы в честь средневекового математика Леонардо Пизанского (известного как Фибоначчи)
             */
            Console.WriteLine("Расчет числа Фибоначи. ");
            Console.Write("Введите длину (целое число) последовательности Фибоначи. n = ");   // Длина у нас с 0
            int nFibonachi=0;
            ulong Fibonachi1 = 0;  // Первое число из ряда
            ulong Fibonachi2 = 1;  // Второе число из ряда
           ulong Fibonachi = 0; 
            try
            {
                nFibonachi=int.Parse(Console.ReadLine()) ;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally
            {   
                int i = 0;
                while ( i <= nFibonachi )
                {
                    if (i == 0)
                    {
                        Console.WriteLine("n = " + i + ", Ч.Фибоначчи = " + Fibonachi1);
                    }
                    else if (i == 1)
                    {
                        Console.WriteLine("n = " + i + ", Ч.Фибоначчи = " + Fibonachi2);
                     }
                    else
                    {
                        /*    Fibonachi = Fibonachi1 + Fibonachi2;
                            Fibonachi1 = Fibonachi2;
                            Fibonachi2 = Fibonachi;
                         //   Fibonachi2 -= (-Fibonachi2);
                          //  Console.WriteLine("Fibonachi1 = " + Fibonachi1 + ", Fibonachi2 = " + Fibonachi2);
                            Console.WriteLine("n = " + i + ", Ч.Фибоначчи = " + Fibonachi);*/
                        Fibonachi = Fibonachi1 + Fibonachi2;
                        Console.WriteLine("n = " + i + ", Ч.Фибоначчи = " + Fibonachi);
                        Fibonachi1 = Fibonachi2;
                        Fibonachi2 = Fibonachi;
                       
                    }
                    i++;
                }
                Console.ReadKey();
            }
            
           
        }
    }
}
