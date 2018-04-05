using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Linq;

namespace Task {

    class Program {
        static void Main(string[] args) {
            
            int year = 0;
            string [] colorYear = new [] {"зелено","красно","желто","бело","черно"};
            string[] animalYear = new[] {"крысы", "быка", "тигра", "зайца", "дракона", "змеи", "лошади", "овцы", "обезьяны", "курицы", "собаки", "свиньи" };
            try {
                Console.Write("Введите год в формате гггг:");
                year = int.Parse(Console.ReadLine());
                if (year < 1) {
                    throw new Exception("год не может быть меньше 1");
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
                year = 1;
            }
            finally {
                if (year > 1983) {
                    year = (year - 1984) % 60 + 1;
                } else {
                    year = 61 - (1984 - year) % 60;
                }
                byte color = (byte)(((year - 1) % 10) / 2 );
                byte animal = (byte)((year - 1) % 12 );
                string colorPostfix = ((animal < 5 & animal > 0) ? "го " : "й ");
                string ColorAnimalYear = "Год " + colorYear[color] + colorPostfix + animalYear[animal];
                Console.WriteLine(ColorAnimalYear);
            }
            Console.ReadKey();
        }
    }
}
