using System;

namespace HT_10_lesson
{
    // Реализовать сортировку ЧЕТ-НЕЧЕТ и сортировку слиянием для квадратной матрицы
    public class MatrixSqure {
        long[,] matrSq;

        public long[,] MatrSq {
            get { return matrSq; }
            set { matrSq = value; }
        }
        public MatrixSqure() {          // Конструктор по умолчанию
            matrSq = new long[0, 0];    // первоначальная инициализация 0 
        }

        public MatrixSqure(byte n) {     // Конструктор для инициализации массива определенной длиной 
            matrSq = new long[n, n];    // Квадратная матрица  
            InitMartix(); // Инициализация
        }
        // Инициализация матрицы
        private void InitMartix() {
            Random ran = new Random(); // создаем последовательность случайных чисел
            for (int i = 0; i < matrSq.GetLength(0); i++) {
                for (int j = 0; j < matrSq.GetLength(1); j++) {
                    matrSq[i, j] = ran.Next(0, 10);    // Ввод случайных чисел
                }
            }
        }
        // Вывод матрицы
        public void OutputMartix() {
            for (int i = 0; i < matrSq.GetLength(0); i++) {
                for (int j = 0; j < matrSq.GetLength(1); j++) {
                    Console.Write("{0}\t", matrSq[i, j]);
                }
                Console.WriteLine();
            }
        }
        // Сортировка строк
        public void SortRow() {
            long[] buffA;   // Объявляем буфферный массив для записи промежуточных значений
            for (int i = 0; i < matrSq.GetLength(0); i++) {   // Строки
                buffA = new long[matrSq.GetLength(1)];
                for (int j = 0; j < matrSq.GetLength(1); j++) {
                    buffA[j] = matrSq[i, j];
                }
                buffA = BubbleSort(buffA);
                for (int j = 0; j < matrSq.GetLength(1); j++) {
                    matrSq[i, j] = buffA[j];
                }
            }
        }
        // Пузырьковая сортировка
        public long[] BubbleSort(long[] a) {
            for (long i = 0; i < a.Length; i++) {
                for (long j = a.Length - 1; j > i; j--) {
                    if (a[j - 1] > a[j]) {
                        Change(a, j - 1, j);
                    }
                }
            }
            return a;
        }
        // Функция перестановки (входной массив, индексы переставляемых значений массива)
        public void Change(long[] order, long start, long end) {
            long buff = order[start];
            order[start] = order[end];
            order[end] = buff;
        }
        // Берем из двумерного массива одномерный
        public long[] GetSinglMatr() {
            long[] buffMas = new long[matrSq.Length];
            long ind = 0;
            foreach (long value in matrSq) {
                buffMas[ind++] = value;
            }
            return buffMas;
        }
        // Переопределяем двумерный массив
        public void SetMatrSq(long[] inMass) {
            long ind = 0;
            for (long i = 0; i < matrSq.GetLength(0); i++) {
                for (long j = 0; j < matrSq.GetLength(1); j++) {
                    matrSq[i, j] = inMass[ind++];
                }
            }
        }
        // Сортировка ЧЕТ и НЕЧЕТ
        // Точка останова F9
        // шаг с обход. F10, с заходом F11, с выходом   Shift+F11
        public long[] SortEvenAndOdd(long[] inMass) {
            // bool blSort = true;
            for (long i = 0; i < inMass.Length; i++) {
                if (i % 2 == 0) {  // Если четное
                    for (long j = inMass.Length - 1; j > 0; j -= 2) {
                        if (inMass[j] < inMass[j - 1]) Change(inMass, j, j - 1);
                    }
                }
                else {
                    for (long j = inMass.Length - 2; j > 0; j -= 2) {
                        if (inMass[j] < inMass[j - 1]) Change(inMass, j, j - 1);
                    }

                }
            }
            return inMass;
        }
        // Сортировка слиянием
        public long[] MergeSort(long[] masssive) {  // Рекурсия
            if (masssive.Length == 1)
                return masssive;
            return Megre(MergeSort(Take(masssive, masssive.Length/2)), MergeSort(Skip(masssive, masssive.Length / 2)));
        }
        // Функция сравнения
        public long[] Megre(long[] inMassRight, long[] inMassLeft) {
            long right = 0, left = 0;
            long[] outMass = new long[inMassRight.Length + inMassLeft.Length];
            // Проходим по всем элементам нового массива
            for (long i = 0; i < inMassRight.Length + inMassLeft.Length; i++) {  
                if (right < inMassRight.Length && left < inMassLeft.Length) {
                    if (inMassRight[right] > inMassLeft[left]) {
                        outMass[i] = inMassLeft[left++];
                    } else {
                        outMass[i] = inMassRight[right++];
                    }
                }else {
                    if (left < inMassLeft.Length) {
                        outMass[i] = inMassLeft[left++];
                    }else {
                        outMass[i] = inMassRight[right++];
                    }
                }
            }

            return outMass;
        }
        // Берем правую часть массива
        public long[] Take(long[] inMass, long newLength) {
            long[] outMass = new long[newLength];
            for (long i=0; i<newLength; i++) {
                outMass[i] = inMass[i];
            }
            return outMass;
        }
        // Берем левую часть массива
        public long[] Skip(long[] inMass, long newLength) {
            long[] outMass = new long[inMass.Length-newLength];
            for (long i = 0; i < (inMass.Length - newLength); i++) {
                outMass[i] = inMass[newLength+i];
            }
            return outMass;
        }
    }

        class Program{
            static void Main(string[] args){
                Console.WriteLine("1. Сортировка ЧЕТ-НЕЧЕТ(через один)");
                MatrixSqure matrSqCur;
                byte matrSqLength = 0;  // размерность квадратной матрицы n
                try {
                    Console.Write("Введите размер квадратной матрицы (0-255), n = ");
                    matrSqLength = byte.Parse(Console.ReadLine());
                }
                catch (Exception ex){
                    Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
                }
                finally{
                    matrSqCur = new MatrixSqure(matrSqLength); // Инициализируем длиной N
                    Console.WriteLine();
                    Console.WriteLine("Исходная матрица:");
                    matrSqCur.OutputMartix(); // Выводим матрицу
                    matrSqCur.SetMatrSq(matrSqCur.SortEvenAndOdd(matrSqCur.GetSinglMatr()));
                    // matrSqCur.SortRow();
                    Console.WriteLine();
                    Console.WriteLine("Сортированная матрица:");
                    matrSqCur.OutputMartix(); // Выводим матрицу

                }
                Console.WriteLine();
                Console.WriteLine("2. Сортировка слиянием");
                MatrixSqure matrSqCur2;
                byte matrSqLength2 = 0;  // размерность квадратной матрицы n
                try {
                    Console.Write("Введите размер квадратной матрицы (0-255), n = ");
                    matrSqLength2 = byte.Parse(Console.ReadLine());
                }
                catch (Exception ex) {
                    Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
                }
                finally {
                    matrSqCur2 = new MatrixSqure(matrSqLength2); // Инициализируем длиной N
                    Console.WriteLine();
                    Console.WriteLine("Исходная матрица:");
                    matrSqCur2.OutputMartix(); // Выводим матрицу
                    matrSqCur2.SetMatrSq(matrSqCur2.MergeSort(matrSqCur2.GetSinglMatr()));
                    // matrSqCur.SortRow();
                    Console.WriteLine();
                    Console.WriteLine("Сортированная матрица:");
                    matrSqCur2.OutputMartix(); // Выводим матрицу
                }
                Console.ReadKey();
            }
        }

    
}
