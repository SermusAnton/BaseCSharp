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
        Во втором приложении задать значения всем заявленным свойствам класса Console. Иными словами: пощупать, поиграть параметрами класса.
        3*.(Задание со звездочкой) реализовать решение (найти X):
        ax = b
         
         */
        static void Main(string[] args){
            Console.Write("Окно консоли назовем: ");
                string inputTitle = Console.ReadLine();
                inputTitle = inputTitle.Length == 0 ? "Работа со свойствами" : inputTitle;
            Console.Write("Введите цвет фона консоли (по умолчанию: 'Red'): ");
                string inputColorBack=Console.ReadLine();
                inputColorBack = inputColorBack.Length == 0 ? "Red" : inputColorBack;
            Console.Write("Введите цвет фона текста (по умолчанию: 'White'): ");
                string inputColorFore = Console.ReadLine();
                inputColorFore = inputColorFore.Length == 0 ? "White" : inputColorFore;
            Console.Write("Введите высоту буфера консоли: ");
                string inputHeightBuf=Console.ReadLine();
                inputHeightBuf = inputHeightBuf.Length == 0 ? "50" : inputHeightBuf;
            Console.Write("Введите ширину буфера консоли: ");
            string inputWidthBuf=Console.ReadLine();
                inputWidthBuf = inputWidthBuf.Length == 0 ? "100" : inputWidthBuf;
       //     Console.Write("Введите высоту консоли: ");
       //         string inputHeight = Console.ReadLine();
       //         inputHeight = inputHeight.Length == 0 ? "100" : inputHeight;
       //     Console.Write("Введите ширину консоли: ");
       //         string inputWidth = Console.ReadLine();
       //         inputWidth = inputWidth.Length == 0 ? "100" : inputWidth;

            Console.WriteLine("Применим значения!!!");
            try {
                Console.Title=inputTitle;
                Console.BackgroundColor=(ConsoleColor)Enum.Parse(typeof(ConsoleColor), inputColorBack);   // 
                Console.ForegroundColor=(ConsoleColor)Enum.Parse(typeof(ConsoleColor), inputColorFore);
                Console.WriteLine("Фон - " + inputColorBack + ", текст - " + inputColorFore);
                Console.BufferHeight = int.Parse(inputHeightBuf);
                Console.BufferWidth = int.Parse(inputWidthBuf);
                Console.WriteLine("Буффер высота - " + inputHeightBuf + ", ширина - " + inputWidthBuf);
              //  Console.WindowHeight=int.Parse(inputHeight);
              //  Console.WindowWidth = int.Parse(inputWidth);
              //  Console.SetWindowSize(int.Parse(inputWidth), int.Parse(inputHeight));
              //  Console.WriteLine("Консоль высота - " + inputHeight + ", ширина - " + inputWidth);
                Console.WriteLine("Консоль высота - " + Console.WindowHeight + ", ширина - " + Console.WindowWidth);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
            


        /*    Console.WriteLine("Расчет x из формулы: ax2+bx+c=0");
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
                    Console.WriteLine("D > 0, два корня : x1 = " + ((-b + (decimal)Math.Sqrt((double)D)) / (2 * a)) + "x2 = " + ((-b - (decimal)Math.Sqrt((double)D)) / (2 * a)));
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
        */
        
        
        }
    }
}
