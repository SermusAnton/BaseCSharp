using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task
{
    // telephone book phone number
    class TelefonBookRow : IComparable  {
       
     //   private static int ind=0;
        private int numberRow = 0;  // Номер записи
        private string number = "";   // Номер телефона
        private string name = "";   // ФИО владельца
        private string adress = ""; // Адрес установки телефона
        public int NumberRow {
            get {
                return numberRow;
            }           
        }
        public String Number {
            get {
                return number;
            }
            set {
                this.number = value;
            }
        }
        public String Name {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        }
        public String Adress {
            get {
                return adress;
            }
            set {
                this.adress = value;
            }
        }
        public TelefonBookRow() {
            Random ranInt = new Random();
            numberRow = ranInt.Next(1, 100);  // Номер записи
            number = "";   // Номер телефона
            name = "";   // ФИО владельца
            adress = ""; // Адрес установки телефона
        }
        public TelefonBookRow(string number, string name, string adress) {
            // ++ind;
            Random ranInt = new Random();
            this.numberRow = ranInt.Next(1, 100);  // Номер записи
            this.number = number;   // Номер телефона
            this.name = name;   // ФИО владельца
            this.adress = adress; // Адрес установки телефона
        }
        // Реализуем метод для сравнения элементов строк между собой
        public int CompareTo(object obj) {
            if (obj == null) return 1;
            
            TelefonBookRow otherNumber = obj as TelefonBookRow;
            if (otherNumber != null)   // Сортировку производим по номеру телефона
                if (this.NumberRow > otherNumber.NumberRow) { return -1; } else { return 1; }
            else
                throw new ArgumentException("Object is not a Number");
        }
    }
        
    class Program
    {
        /*  Курсовая работа: 
         *  1-реализовать умножение матрицы на матрицу. 
         *  2-реадизовать ООП структуру телефонного справочника,что б в него можно было добавлять и удалять записи.
         */    
        static void Main(string[] args)
        {
            SortedSet<TelefonBookRow> TelefonBook1 = new SortedSet<TelefonBookRow>();
            TelefonBook1.Add(new TelefonBookRow("93-93-93","Иванов И.И.","г. Иваново, ул. Лежневская, д.3, кв. 163"));
            TelefonBook1.Add(new TelefonBookRow("93-95-44","Смирнов П.А.", "г. Иваново, ул. Велижская, д.5, кв. 98"));
            TelefonBook1.Add(new TelefonBookRow("93-95-44", "Виноградов Д.А,", "г. Иваново, ул. Велижская, д.5, кв. 98"));
            foreach (TelefonBookRow key in TelefonBook1) {
                Console.WriteLine(key.NumberRow +" "+ key.Number + " " + key.Name + " " + key.Adress);
            }
          //  TelefonBookRow deleteElement = new TelefonBookRow("93-93-93","","");
            // Удаляем элемент
          //  TelefonBook1.Remove(deleteElement);
            Console.WriteLine("Другой порядок");
            foreach (TelefonBookRow key in TelefonBook1) {

                Console.WriteLine(key.NumberRow + " " + key.Number + " " + key.Name + " " + key.Adress);
            }
           
            Console.WriteLine("Для завершения нажмите любую клавишу...");
           Console.ReadKey();
         
        }
   }
}
