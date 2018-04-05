using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lessson_14
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string arg;
            Stack<double> st = new Stack<double>();
            while ((arg = Console.ReadLine()) != "exit") {
                double num;
                bool isNum = double.TryParse(arg,out num);
                if (isNum) {
                    st.Push(num);
                } else {
                    double op2;
                    switch (arg) {
                        case "+":
                            st.Push(st.Pop()+st.Pop());
                            break;
                        case "*":
                            st.Push(st.Pop() * st.Pop());
                            break;
                        case "-":
                            op2 = st.Pop();
                            st.Push(st.Pop() - op2);
                            break;
                        case "/":
                            op2 = st.Pop();
                            if (op2 != 0.0) {
                                st.Push(st.Pop() / op2);
                            } else {
                                Console.WriteLine("Ошибка деление на ноль");
                            }
                            break;
                        case "calc":
                           Console.WriteLine("Результат "+st.Pop());
                            
                            break;
                        default:
                            Console.WriteLine("Ошибка.Неизвестная команда");

                            break;

                    }
                }
            }
            Console.ReadKey();
            */
            int intG = LongestCommonSubstringLength("Папа", "Папочка");
            Console.WriteLine(intG);
            Console.ReadKey();
        }
        // Поиск максимальная одинаковая подстрока  
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
                        if (num[i][j] > maxlen)
                            maxlen = num[i][j];
                    }
                    if (i >= 2)
                        num[i - 2] = null;
                }
            }
            return maxlen;
        }
    }

}
