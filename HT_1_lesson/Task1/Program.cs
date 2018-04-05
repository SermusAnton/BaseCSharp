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
            Console.WriteLine("Расчет Х из формулы: ax=b");
         //   Console.WriteLine();
            Console.WriteLine("Введите коэф. а и b (делитель ,)");
            decimal a = 1m;
            decimal b = 0m;

            try
            {
                Console.Write("a = ");
                a = decimal.Parse(Console.ReadLine());
                Console.Write("b = ");
                b = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Из формулы: " + a + "x = " + b + "; x = " + b / a); 
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
