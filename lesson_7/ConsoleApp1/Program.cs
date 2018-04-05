using System;

namespace ConsoleApp1
{
    class RevStr {
        public void DisplayRev(string str)
        {
            if (str.Length > 0)
            {
                DisplayRev(str.Substring(1, str.Length - 1));
            }
            else
                return;
            Console.Write(str[0]);

        }
      
    }
    class Program
    {

        static int factorial(int i)
        {
            int result;
            if (i == 1) return 1;
            try
            {
                result = factorial(i - 1) * i;
            }
            catch (Exception ex)
            {
                Console.WriteLine("При расчете факториала произошла ошибка", ex);
                result = 0;
            }
            return result;
        }

       static void Main(string[] args)
        {
            /*   Console.WriteLine("Введите число: ");
               try
               {
                   int i = int.Parse(Console.ReadLine());
                   Console.WriteLine("{0}! = {1}", i, factorial(i));
               }
               catch (FormatException)
               {
                   Console.WriteLine("Некорректное число");
               }
               Console.ReadLine();

       */
            int I = 0;
            string s = "Это текст!";
            RevStr rsOb = new RevStr();
            Console.WriteLine("Исходная строка:"+s);
            Console.Write("Перевернутая строка: ");
            rsOb.DisplayRev(s);
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
