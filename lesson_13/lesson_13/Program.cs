using System;
using System.Text;

namespace lesson_13
{
    class Program
    {
        static void Main(string[] args) {/*
           Console.WriteLine( String.Compare("Romania", "Russia"));
            Console.WriteLine(String.Compare("Rwanda", "Russia"));
            Console.WriteLine(String.Compare("Russia", "Russia"));
            Console.WriteLine(String.Compare("Rwanda", "Romania"));
            Console.WriteLine(String.Compare("R", "r"));  // R>1 1
            Console.ReadKey();

            string text = "Хороший день";
            string subString = "замечательный ";
            text = text.Insert(8,subString);
            Console.WriteLine(text);

            Console.WriteLine();
           

            string text1 ="Хороший день";
            int ind = text1.Length - 1;
            text1 = text1.Remove(ind);
            Console.WriteLine(text1);
            text1 = text1.Remove(0,2);
            Console.WriteLine(text1);

            Console.WriteLine();
             */

            string text = "хороший день";
            text = text.Replace("хороший","плохой");
            Console.WriteLine(text);
            text = text.Replace("о","");
            Console.WriteLine(text);
            Console.ReadKey();
            string s1 = " ";
            int g =  s1.IndexOf("это");
            // String.Compare
        }
    }
}
