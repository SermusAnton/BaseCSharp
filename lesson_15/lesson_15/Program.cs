using System;
using System.Collections.Generic;
using System.Text;
namespace lesson_15
{
    class Program
    {
        /*
        public static string LCS(string s1, string s2) {
            int[,] a = new int[s1.Length + 1, s2.Length + 1];
            int u = 0, v = 0;

            for (int i = 0; i < s1.Length; i++)
                for (int j = 0; j < s2.Length; j++)
                    if (s1[i] == s2[j]) {
                        a[i + 1, j + 1] = a[i, j] + 1;
                        if (a[i + 1, j + 1] > a[u, v]) {
                            u = i + 1;
                            v = j + 1;
                        }
                    }

            return s1.Substring(u - a[u, v], a[u, v]);
        }*/
        static void Main(string[] args) { /*
            // List<string> strOut = new List<string>();
            string[] strList = new string[7];
            strList[0] = "eж";
            strList[1] = "снег";
            strList[2] = "eж";
            strList[3] = "снег";
            strList[4] = "1";
            strList[5] = "2";
            strList[6] = "5";
            Console.WriteLine("Сравнение массива строк");
            for (int i = 0; i < strList.Length; i++) {
                for (int j = i+1; j < strList.Length; j++) {

                    if (String.Compare(strList[i], strList[j]) == 0) {
                        strList[i] = "";
                    }
                }
            }
            for (int i = 0; i < strList.Length; i++) {
                if (strList[i] != "") {
                    Console.WriteLine(strList[i]);
                }
            }
            Console.ReadKey();
            */

            /*
            List<string> strOut = new List<string>();
            string inStr = "";
            while ((inStr = Console.ReadLine()).Length > 0) {
                strOut.Add(inStr);
            }
            Console.WriteLine("Сравнение списка строк");
            for (int i = 0; i < strList.Length; i++) {
                for (int j = i + 1; j < strList.Length; j++) {

                    if (String.Compare(strList[i], strList[j]) == 0) {
                        strList[i] = "";
                    }
                }
            }
            for (int i = 0; i < strList.Length; i++) {
                if (strList[i] != "") {
                    Console.WriteLine(strList[i]);
                }
            }
            Console.ReadKey();
            */
            // Решето Эрастофена
            int n = int.Parse(Console.ReadLine());
            bool[] A = new bool[n];
            // Инициализация и вывод массива
            for (int i=2; i<n; i++) {
                A[i] = true;
                Console.WriteLine("{0}",i);
            }
            // Обработка
            for (int i=2;i<Math.Sqrt(n)+1;++i) {
                if (A[i]) {
                    for (int j = i * i; j < n; j += i) {
                        A[j] = false;
                    }
                }
            }
            Console.WriteLine();
            // Повторный вывод
            for (int i = 2; i<n;i++) {
                if (A[i]) {
                    Console.WriteLine("{0}", i);
                }

            }
            Console.ReadKey();

        }
    }
}
