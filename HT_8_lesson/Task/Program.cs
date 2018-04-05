using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task
{
    class Program
    {
        /*  Домашнее задание: с помощью рекурсии определить является ли введенная строка полиндромом?
         *  Теория https://ru.wikipedia.org/wiki/%D0%9F%D0%B0%D0%BB%D0%B8%D0%BD%D0%B4%D1%80%D0%BE%D0%BC
         *  Поиск длиннейшей подстроки-полиндрома
         https://ru.wikipedia.org/wiki/%D0%9F%D0%BE%D0%B8%D1%81%D0%BA_%D0%B4%D0%BB%D0%B8%D0%BD%D0%BD%D0%B5%D0%B9%D1%88%D0%B5%D0%B9_%D0%BF%D0%BE%D0%B4%D1%81%D1%82%D1%80%D0%BE%D0%BA%D0%B8-%D0%BF%D0%B0%D0%BB%D0%B8%D0%BD%D0%B4%D1%80%D0%BE%D0%BC%D0%B0#CITEREFGusfield1997
        */

        static void Main(string[] args){
            Console.WriteLine("Является ли строка полиндромом");
            string strIn=""; // входная строка
            Console.Write("Введите исходную строку: ");
            strIn = (Console.ReadLine()).Trim().ToLower();
           Console.WriteLine();
            
            for (int i = 1; i < strIn.Length-1; i++) {
                InputPolindrom(strIn,i,i);
            }

            Console.ReadKey();   
 
        }

        public static void InputPolindrom(string strIn, int start, int end) {
            if ( ((start - 1) < 0 || (end + 1) >= strIn.Length)||(strIn[start - 1] != strIn[end + 1] )) {
                string polStr = strIn.Substring(start, (end - start + 1));
                if (polStr.Length >= 3) Console.WriteLine(polStr);
           }else {
               InputPolindrom(strIn, start-1,  end+1);
                
            }


        }   
    }
   
}
