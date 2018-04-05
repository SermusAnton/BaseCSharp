using System;
using BinaryTreeTest;

namespace tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree myBinaryTree1 = new BinaryTree();
            int countNode = 1;
            try {
                Console.WriteLine("Введите кол-во элементов дерева:");
                countNode =Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception e) {
                Console.WriteLine("Некорректно введены данные. Ошибка" + e.Message);
            }
            Random randomData = new Random();
            long removeData = 0;
            for (int i = 0; i < countNode; i++) {
                long longData = (long)randomData.Next(0, 10);
                Console.Write(" "+longData);
                myBinaryTree1.Insert(longData);
                if (i == (int)(countNode / 2 -1)) {
                    removeData = longData;
                }
            }
            Console.WriteLine();

            Console.WriteLine("До удаления");
            BinaryTreeExtensions.Print(myBinaryTree1);

            Console.WriteLine("После удаления элемента дерева: "+ removeData);
            myBinaryTree1.Remove(removeData);
            BinaryTreeExtensions.Print(myBinaryTree1);

            Console.ReadKey();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
        }
    }
}
