using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2 {
    public class GeometricProgression {
        // Поля класса
        private byte n;     // Кол-во элементов
        private byte q;     // Знаменатель
        private ulong x1;     // Певоначальное значение
        
        // Конструктор по умолчанию
        public GeometricProgression() { 
            this.n=0;     // Кол-во элементов
            this.q = 0;     // Знаменатель
            this.x1 = 0;     // Певоначальное значение
        }
        // Конструктор с одновремменой инициалазацией класса
        public GeometricProgression(byte n, byte q, ulong x1)  {
            this.n = n;     // Кол-во элементов
            this.q = q;     // Знаменатель
            this.x1 = x1;     // Певоначальное значение
        }
        // Свойство
        public byte N {  // Аксессоры для n
            get { return this.n; }
            set { this.n=value;  }
        }
        // Свойство
        public byte Q {  // Аксессоры для Q
            get  { return this.q; }
            set { this.q = value; }
        }
        // Свойство
        public ulong X1  { // Аксессоры для Xn
            get {  return this.x1;  }
            set { this.x1 = value;  }
        }
        // Метод расчет элемента I, используем  bn=b1*q^(n-1)
        private ulong CalculationI(byte Namber) {
            return (    X1 * (ulong)Math.Pow(      q , (Namber - 1)      )       );
       }
        // Метод вывода элемента с 1 по n
        public void INPUTGP()  {
            for (byte i = 1; i <= n; i++) {
                Console.WriteLine("n = " + i + "; Xn = " + CalculationI(i));
             }
        }
    }
}
