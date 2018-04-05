using System;

namespace lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {/*
            string buf;
            int x;
            int y;
            int z;

            try {
                buf = Console.ReadLine();
                x = int.Parse(buf);
                buf = Console.ReadLine();
                y = int.Parse(buf);
                z = x / y;
                Console.WriteLine(z);


            } catch(DivideByZeroException)
            {  // Выполняем Console.WriteLine("Деление на ноль"); когда DivideByZeroException
                Console.WriteLine("Деление на ноль");

            }
           */
         /*  string value = "-18";
           int result = Convert.ToInt32(value);
           Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", value.GetType().Name,value,result.GetType(),result);
           Console.WriteLine();*/
         /*    string value = "one";
           int  result = Convert.ToInt32(value);
             Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", value.GetType().Name, value, result.GetType(), result);
           */
         /*    string value = Int32.MaxValue.ToString();
             int result = Convert.ToInt32(value);
             Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", value.GetType().Name, value, result.GetType(), result);
          */
         /*   string[] values = { "One", "1.34e28", "-26.87", "-18", "-6.00", " 0", "137", "1601.9", Int32.MaxValue.ToString() };
            int result;
            foreach (string value in values) {
                try {
                    result = Convert.ToInt32(value);
                    Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", value.GetType().Name, value, result.GetType(), result);
                } catch (OverflowException) {
                    Console.WriteLine("{0} is outside the range of the Int32 type.", value);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The {0} value '{1}' is not in a recognizable format", value.GetType().Name, value);
                }
            }*/



         Console.ReadKey();
        }
    }
}
