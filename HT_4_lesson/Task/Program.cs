using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task2;   // Указываем потому, что разное пространство имен

namespace Task1
{
    class Program
    {
        /*
         * 1. С клавиатуры вводятся цифры, собрать их в целое число и вывести на экран. 
         * 2. С клавиатуры вводятся два целых числа a и b . Возвести a в степень b. (не использовать pow) 
         * 3. Определить день недели по введенному числу (проследить чтоб пользователь ввел число от 1 до 7) 
         * 4*. Найти алгебрарическую сумму 1^k + 2^k + 3^k + … + N^k , где k и N вводятся с клавиатуры (в этой задаче не ставлю условий для реализации).
         * 5*. Есть целочисленная переменная X начальное значение которой равно 15. 
         * Необходимо вывести в консоль 10 членов геометрической прогрессии, где первым членом является X, а знаменателем прогресии является 5. 
         * PS: для тех, кто забыл, что такое геометрическая прогрессия Википедия в помощь 
         */
        static void Main(string[] args)
        {
            
            // Задание 1.   Выдать в контактё
            Console.WriteLine("1. Собрать целое число. ");
            Console.WriteLine("Введите цифру или 'Enter' для окончания ввода: ");
            string strDigit = "";
            string bufDigit = "";
            long lDigit = 0;
            while ((bufDigit = Console.ReadLine()).Length != 0)
            {
                if (bufDigit.Length > 1) {
                    Console.WriteLine("Вы ввели больше 1й цифры, но все равно добавим их."); 
                }
                strDigit += bufDigit;
            }
            try
            {
                lDigit = long.Parse(strDigit);   // Любое кол-во цифр (ограничение long) 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Целое число:");
                Console.Write(lDigit);  
            }
            Console.ReadKey();
            Console.WriteLine();
            
            // Задание 2.
            Console.WriteLine("2. Возвести число A в степень B без ф-ции POW. ");
            int A=0, B=0; // Основание, степень
            decimal Rank=1;
            try
            {
                Console.Write("Введите основание А:  ");  
                A = int.Parse(Console.ReadLine());   // Ограничение int
                Console.Write("Введите показатель степени B:  ");
                B = int.Parse(Console.ReadLine());  // Ограничение int
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally
            {
                Console.Write(A + "^" + B + "=");
                // Поскольку берем int, а int м.б. отрицательным и 0, то нужно условие 
                if (B > 0)
                {
                    while ((B--) > 0) // Постфиксная запись
                    {
                        Rank *= A;
                    //    --B;
                    }
                }
                else
                {
                    if (B == 0)
                    {
                        if (A == 0) { Rank = 0; } 
                    }
                    else
                    {
                        while ((B++) < 0)  // Постфиксная запись
                        {
                            Rank /= A;
                            //++B;
                        }
                    }
                }
                Console.Write(Rank);
            }
            Console.ReadKey();
            Console.WriteLine();

            // Задание 3.1. switch - case
            Console.WriteLine("3.1 День недели (switch - case).");
            byte week1 = 0;
            Console.Write("Введите номер для недели из диапазона 1-7, где 1 - понедельник:  ");
            try
            {
                week1 = byte.Parse(Console.ReadLine());   // Ограничение byte
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally  // Блок, кот. выполняемся в любом случае, даже после catch, т.е. ошибки
            {
                switch (week1){
                    case 1:
                        Console.WriteLine("Понедельник");
                        break;
                    case 2:
                        Console.WriteLine("Вторник");
                        break;
                    case 3:
                        Console.WriteLine("Среда");
                        break;
                    case 4:
                        Console.WriteLine("Четверг");
                        break;
                    case 5:
                        Console.WriteLine("Пятница");
                        break;
                    case 6:
                        Console.WriteLine("Суббота");
                        break;
                    case 7:
                        Console.WriteLine("Воскресенье");
                        break;
                    default:
                        Console.WriteLine("Нет такого. Введите цифру от 1 до 7");
                        break;                
                
                } 
            }
            Console.ReadKey();
            Console.WriteLine();

            // Задание 3.2 array - foreach 
            Console.WriteLine("3.2 День недели (array - foreach). ");
            
            byte week2 = 0;
            string[] days = new string[] {"Понедельник","Вторник","Среда","Четверг","Пятница","Суббота","Воскресенье"}; // Объявление и сразу инициализация, иначе надо указывать длину массива
            Console.Write("Введите номер для недели из диапазона 1-7, где 1 - понедельник:  ");
            try
            {
                week2 = byte.Parse(Console.ReadLine());   // Ограничение byte
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally  // Блок, кот. выполняемся в любом случае, даже после catch, т.е. ошибки
            {
                // Проверям правильность ввод номера дня недели
                if (week2>0&week2<=7) { 
                    byte count = 1;
                    foreach(string day in days){
                        if (week2 == count) {
                            Console.WriteLine(day);
                            break;
                        }
                        count++;
                    }
                } else
                {
                    Console.WriteLine("Нет такого. Введите цифру от 1 до 7");
                }
            }
            Console.ReadKey();
            Console.WriteLine();

            // Задание 4.
            Console.WriteLine("4. Алгебраическая сумма одинаковых степеней.");
            Console.WriteLine("Для рассчета 1^k + 2^k + 3^k + … + N^k, введите ");
            Console.Write("k =  ");
            string kStr = Console.ReadLine();
            Console.Write("N =  ");
            string NStr = Console.ReadLine();
            double k = 0, N = 0, Sum = 0;
            try
            {
                k = double.Parse(kStr);   // Ограничение double
                N = double.Parse(NStr);   // Ограничение double
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректно введены данные ", ex.Message);
            }
            finally  // Блок, кот. выполняемся в любом случае, даже после catch, т.е. ошибки
            {
                for (int i = 1; i <= N; i++ )
                {
                    Sum += Math.Pow(i, k);

                }
                Console.Write("Сумма будет равна: ");
                try
                {
                    Console.WriteLine(Convert.ToDecimal(Sum));
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("очень много:) " + Sum + " " + ex.Message);
                }
               
            }
            Console.ReadKey();
            Console.WriteLine();

            // Задание 5.1
            // 5*. Есть целочисленная переменная X начальное значение которой равно 15. 
            // Необходимо вывести в консоль 10 членов геометрической прогрессии, где первым членом является X, а знаменателем прогресии является 5. 
            // PS: для тех, кто забыл, что такое геометрическая прогрессия Википедия в помощь 
            // Геометри́ческая прогре́ссия — последовательность чисел b 1 ,   b 2 ,   b 3 ,   … (членов прогрессии), 
            // в которой каждое последующее число, начиная со второго, получается из предыдущего умножением его на определённое число q  (знаменатель прогрессии), 
            // где b 1 ≠ 0, q ≠ 0: b 1 ,   b 2 = b 1 q ,   b 3 = b 2 q ,   … ,   b n = b n − 1 q 
            Console.WriteLine("5.1 Геометрическая прогрессия.");
            Console.WriteLine("Кол-во выводимых  элементов, n = 10");
            Console.WriteLine("Первый элемент, X = 15");
            Console.WriteLine("Знаменатель, q =  5");
            
            byte n = 10;
            byte q = 5;
            int Xn = 15; 

                // Можно вычислить по фор-ле  bn=b1*q^(n-1)
            
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine("n = " + i + "; Xn = " + Xn);
                    Xn *= q;
                }
            Console.ReadKey();
            Console.WriteLine();

            // Задание 5.2. ООП
            // 5*. Есть целочисленная переменная X начальное значение которой равно 15. 
            // Необходимо вывести в консоль 10 членов геометрической прогрессии, где первым членом является X, а знаменателем прогресии является 5. 
            // PS: для тех, кто забыл, что такое геометрическая прогрессия Википедия в помощь 
            // Геометри́ческая прогре́ссия — последовательность чисел b 1 ,   b 2 ,   b 3 ,   … (членов прогрессии), 
            // в которой каждое последующее число, начиная со второго, получается из предыдущего умножением его на определённое число q  (знаменатель прогрессии), 
            // где b 1 ≠ 0, q ≠ 0: b 1 ,   b 2 = b 1 q ,   b 3 = b 2 q ,   … ,   b n = b n − 1 q 
            // using Task2;   // Указываем потому, что разное пространство имен
            Console.WriteLine("5.2 Геометрическая прогрессия. Используя ООП");
            Console.WriteLine("Кол-во выводимых  элементов, n = 10");
            Console.WriteLine("Знаменатель, q =  5");
            Console.WriteLine("Первый элемент, X = 15");
            
            // Используем инициализацию переменных через конструктор
            GeometricProgression gp1 = new GeometricProgression(10, 5, 15); // n,q,X1
            // Считаем и выводим
            gp1.INPUTGP();

            // Используем инициализацию переменных через конструктор по умолчанию
            GeometricProgression gp2 = new GeometricProgression();
            // Изменяем переменные через аксессор
            gp2.N = 20;
            gp2.Q = 5;
            gp2.X1 = 15;

            Console.WriteLine("Для n = " + gp2.N + ", q = " + gp2.Q + ", X = " + gp2.X1);
            // Считаем и выводим
            gp2.INPUTGP();

            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
