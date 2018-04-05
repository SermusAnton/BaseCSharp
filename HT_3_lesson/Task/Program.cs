using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        /*
        Составить прогрумму, которая будет считывать введенное пятизначное число.
        После чего, каждую цифру этого числа необходимо вывесть в новой строке.
         */
        static void Main(string[] args)
        {

            Console.WriteLine("Последовательно вывести каждую цифру пятизначного числа в новой строке. ");
            Console.Write("Введите пятизначное число: ");
            string strChislo5 = Console.ReadLine();
            long chislo5 = 0;
            long chislo51 = 0;
            //    int ostChislo5 = 0; 
            try
            {
                chislo5 = int.Parse(strChislo5);
                chislo51 = chislo5; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally
            {
                // Выводим цифры с конца. Любое кол-во цифр (ограничение long) 
                Console.WriteLine();
                Console.WriteLine("Обратный порядок");
                
                while (chislo5 != 0)
                {
               //     chislo5 = chislo5%(int)Math.Pow(10, i);
                 //   Console.WriteLine( chislo5%(int)Math.Pow(10, i));
                 //   chislo5 = (chislo5 - chislo5 % (int)Math.Pow(10, i)) /( chislo5 % (int)Math.Pow(10, i));
                    Console.WriteLine(chislo5 % 10);
                    chislo5 = chislo5 /10;
                   
                }

                int j = (int)Math.Ceiling(Math.Log10((double)Math.Abs(chislo51)));  // Кол-во цифр 
                Console.WriteLine();
                Console.WriteLine("Прямой порядок");
                Console.WriteLine("Кол-во цифр:" + j);
                while (j>0)
                {
                    //     chislo5 = chislo5%(int)Math.Pow(10, i);
                    //   Console.WriteLine( chislo5%(int)Math.Pow(10, i));
                    //   chislo5 = (chislo5 - chislo5 % (int)Math.Pow(10, i)) /( chislo5 % (int)Math.Pow(10, i));
                    Console.WriteLine((int)chislo51/(int)Math.Pow(10, j-1));
                    chislo51 = chislo51 % (int)Math.Pow(10, j-1);
                  
                    j--;
                }
              //  Console.WriteLine(j);
                Console.ReadKey();
            }
            


        }
    }
}
