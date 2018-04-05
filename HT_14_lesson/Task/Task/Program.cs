using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
// using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.Common;

namespace Task {
    class Program {
        public static string LCS(string s1, string s2) {
            int [,] a = new int[s1.Length + 1, s2.Length + 1];
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
        }


        public static int LongestCommonSubstringLength(string str1, string str2) {
            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
                return 0;

            List<int[]> num = new List<int[]>();
            int maxlen = 0;
           for (int i = 0; i < str1.Length; i++) {
                num.Add(new int[str2.Length]);
                for (int j = 0; j < str2.Length; j++) {
                    if (str1[i] != str2[j])
                        num[i][j] = 0;
                    else {
                        if ((i == 0) || (j == 0))
                            num[i][j] = 1;
                        else
                            num[i][j] = 1 + num[i - 1][j - 1];
                        if (num[i][j] > maxlen) {
                            maxlen = num[i][j];
                        }
                    }
                   
                }
            }
           return   maxlen;
        }
        // Используем булевую таблицу
        public static string  LCSBoolean(string s1, string s2) {   // int
            bool[,] a = new bool[s1.Length , s2.Length ];
            int maxLen=0;
            int u = 0; // , v = 0;
            
            for (int i = 0; i < s1.Length; i++) {
                for (int j = 0; j < s2.Length; j++) {
                        a[i, j] = (s1[i] == s2[j]);  // Сравниваем символы строк, помещая их в соответствующие ячейки
                        int di = i, dj = j;
                        int sumLen = 0;
                        while (di >= 0 && dj >= 0 &&a[di, dj]) {  
                                ++sumLen;
                                --di; --dj;
                        }
                        if (sumLen > maxLen) {
                            maxLen = sumLen;
                            u = i;
                           // v = j;
                        }
                }
            }

            return s1.Substring(u+1 - maxLen, maxLen); // maxLen;
        }
        /*
        Домашнее задание-1- продебажить и разобрать оба метода поиска максимальной общей подстроки- высказать свои предположения по оптимизации кода.
        2- есть кусок кода на c#,определить,верно ли в нем количество фигурных скобок 
        3- 2 задача+ верно ли расставлены ; 4- верно ли оформлены условные операторы,операторы циклов, и case- операторы.
        */
        static void Main(string[] args) {
            
            Console.WriteLine("\t 1.Сравнение слов.");
            Console.Write("Первое слово: ");
            string str1 = Console.ReadLine().Trim().ToUpper();
            Console.Write("Второе слово: ");
            string str2 = Console.ReadLine().Trim().ToUpper();
            str1 =str1.Length>0?str1:"папа";
            str2 = str2.Length > 0 ? str2 : "папочкапапа";
            Console.WriteLine("Сравниваем {0} и {1}",str1,str2);
            Console.WriteLine("1.1 LCS");
            Console.WriteLine("Результат: " + LCS(str1, str2));
            Console.WriteLine("1.2 LongestCommonSubstringLength");
            Console.WriteLine("Результат: " + LongestCommonSubstringLength(str1,str2));
            Console.WriteLine("1.3 LCSBoolean");
            Console.WriteLine("Результат: " + LCSBoolean(str1, str2));
            


            
            Console.WriteLine("\t 2.Верно ли кол-во фигурных скобок");
            string directory = Environment.CurrentDirectory;  // Католог exe
            string fileName = "1.cs";
            string sourceFile = Path.Combine(directory, fileName);  // Добавляем к пути 1.cs
            string textCode = File.ReadAllText(sourceFile);  // Открываем файл и записываем все в одну строку

            Console.WriteLine("\t Файл: "+ fileName);

            int countBraceOpen = 0, countBraceClose = 0;
            foreach (char charText in textCode) {
                if (charText == '{') ++countBraceOpen;
                if (charText == '}') ++countBraceClose;
            }
            Console.WriteLine("Кол-во открытых скобок: {0} и закрытых: {1} ", countBraceOpen, countBraceClose);
            
            Console.WriteLine("\t3.Верно ли расставленны \";\"");
            // 
            {
                string paternNewLine = "\r\n";
                string paternSemicolon = ";";
                int numberStr = 0;
                foreach (string iLine in Regex.Split(textCode, paternNewLine, RegexOptions.IgnoreCase)) {
                    numberStr++;
                    if (((iLine.Trim()).Length > 0) & !(DetectRedreservedWords(iLine) | new Regex(paternSemicolon).IsMatch(iLine))) {
                        Console.WriteLine("Строка {0} неверно оформлена: {1}", numberStr, iLine);
                    }
                }
            }  
            Console.WriteLine("\t4.Верно ли оформлены операторы if,for,while,switch,case");
            // 
            {
                string paternNewLine = "\r\n";
                string paternBrackets = @"\([^)]+\)";
                string paternСolon = "case .+:";
                int numberStr = 0;
                foreach (string iLine in Regex.Split(textCode, paternNewLine, RegexOptions.IgnoreCase)) {
                    numberStr++;
                    int? indexWord1 = DetectWords(iLine, new string[] {"if","for","while","switch"});
                    if (indexWord1 != null) {  // Если нашли наши операторы, то обязательно должны проверить правильность
                        if (indexWord1 != 0 | !new Regex(paternBrackets).IsMatch(iLine)) {  // Оператор должен начинаться с начала строки и в этой же строке д.б. скобки
                            Console.WriteLine("Строка {0} неверно оформлена: {1}", numberStr, iLine);
                        }
                    }
                    int? indexWord2 = DetectWords(iLine, new string[] { "case" });
                    if (indexWord2 != null) {  // Если нашли наши операторы, то обязательно должны проверить правильность
                        if (indexWord2 != 0 | !new Regex(paternСolon).IsMatch(iLine)) {  // Оператор должен начинаться с начала строки и в этой же строке д.б. скобки
                            Console.WriteLine("Строка {0} неверно оформлена: {1}", numberStr, iLine);
                        }
                    }
                }
            }



            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода... ");
            Console.ReadKey();




        }
        private static bool DetectRedreservedWords(string inLine) {
            string [] reservedWords = new string[] {  // слова и символы, после которых в конце строки не ставят  ";"
                "public", "static","{", "}","if","else","for","while","switch","case" // , ";\n"
            };
            foreach (string resWord in reservedWords) {
                if (((inLine.Trim().ToLower()).IndexOf( resWord)) > -1) {
                    return true;
                }
            }
            return false;
        }

        private static int? DetectWords(string inLine, string[] indWords) {
            foreach (string resWord in indWords) {
                if (((inLine.Trim().ToLower()).IndexOf(resWord)) > -1) {
                    return ((inLine.Trim().ToLower()).IndexOf(resWord));
                }
            }
            return null;
        }
    }
}
