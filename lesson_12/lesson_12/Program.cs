using System;

namespace lesson_12
{
    class Program
    {
        private static int? BinarySearch(int[] a, int x) {
            if ((a.Length == 0) || (x < a[0]) || (x > a[a.Length - 1])) {
                return null;
            }
            int first = 0;
            int last = a.Length;
            while (first < last) {
                int mid = first + (last - first) / 2;
                if (x <= a[mid]) {
                    last = mid;
                }else {
                    first = mid + 1;
                }
            }
            if (a[last] == x)
                return last;
            else return null;
            
        }
        static void Main(string[] args)
        {
            /*
             int x = 0;    
             int y = 0;
             int[] A;
            // Random ran = new Random(); // создаем последовательность случайных чисел
             try {
            //     Console.WriteLine();
                 Console.Write("Введите размер массива: ");
                 x = int.Parse(Console.ReadLine());
             //    Console.WriteLine();
                 Console.Write("Введите искомый элемент: ");
                 y = int.Parse(Console.ReadLine());
             }
             catch (Exception ex) {
                 Console.WriteLine(ex.Message);
             }
             finally {
                 A = new int[x];
                 for (int i = 0; i < x; i++) {
                         A[i] = i;
                         Console.Write("{0}\t", A[i]);
                 }
                 Console.WriteLine();
                 if (BinarySearch(A, y) != null) {
                     Console.Write("Позиция искомого элемента: ");
                     Console.Write(BinarySearch(A, y));
                 }else {
                     Console.Write("Нет такого элемента!");
                 }
             }
             Console.ReadKey();

             string s1 = "A string is more";
             string s2 = "than the sum of its chars.";
             s1 += s2;
             System.Console.WriteLine(s1); 
              */
            string s1 = "hello";
            string s2 = "world";
            s1 = s2;
            int result = String.Compare(s1,s2);
            Console.WriteLine(result);
            Console.ReadKey();
            
        }
    }
}
