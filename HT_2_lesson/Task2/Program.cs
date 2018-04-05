using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        /*
         1.разобрать матчасть тех двух примеров,что были на первом тестировании.:
        Реализуйте решение следующего выражения (найти X):
        ax = b
        Реализуйте решение следующего выражения (найти X):
        ax2 + bx + c = 0
        2.Реализовать два приложения. В первом применить все заявленные на уроке методы класса Console. 
        Во втором приложении задать значения всем заявленным свойствам класса COnsole. Иными словами: пощупать, поиграть параметрами класса.
        3*.(Задание со звездочкой) реализовать решение (найти X):
        ax = b
         
         */
        static void Main(string[] args){
            Console.WriteLine("Расчет x из формулы: ax2+bx+c=0");
         //   Console.WriteLine();
            Console.WriteLine("Введите коэф. а,b и c (делитель ,)");
            decimal a, b, c, D;

            try
            {
                Console.Write("a!=0, a = ");
                a = decimal.Parse(Console.ReadLine());
                Console.Write("b = ");
                b = decimal.Parse(Console.ReadLine());
                Console.Write("c = ");
                c = decimal.Parse(Console.ReadLine());
                // Расчет дискриминанта
                D = b * b - 4 * a * c;
                Console.WriteLine("Дискриминант D = " + b +" * "+ b +" - 4 * " + a + " * " +c+" = "+ D);
                Console.WriteLine("Из формулы: " + a + " x2 + " + b + "x + " + c + " = 0;");
                if (D > 0)
                {
                    Console.WriteLine("D > 0, два корня : x1 = " + ((-b + (decimal)Math.Sqrt((double)D)) / (2 * a)) + " x2 = " + ((-b - (decimal)Math.Sqrt((double)D)) / (2 * a)));
                }
                else
                {
                    if (D == 0)
                    {
                        Console.WriteLine("D = 0, один корень : x1 = x2 = " + (-b / (2 * a)));
                    }
                    else
                    {
                       Console.WriteLine("D < 0, корней нет!");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены коэффициенты {0}", ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        
        
        
        }
    }
}
