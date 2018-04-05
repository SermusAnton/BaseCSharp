using System;

namespace lesson_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mountsYear = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // январь не высокосный
            Console.WriteLine("Введите дату:");
            Console.WriteLine("День:");
            uint day=0, mount=0, year = 0;
            try {
                day = uint.Parse(Console.ReadLine());
                Console.WriteLine("Месяц:");
                mount = uint.Parse(Console.ReadLine());
                Console.WriteLine("Год:");
                year = uint.Parse(Console.ReadLine());
            } catch (Exception ex){
                    Console.WriteLine("Некорректно ввели данные. Ошибка: " + ex.Message);
             }
            if (mount <= 12 & mount != 0) {
                if (day > mountsYear[mount - 1] || day == 0) {
                    Console.WriteLine("В этом месяце нет столько дней");
                }
                else {


                    // https://ru.wikipedia.org/wiki/%D0%93%D1%80%D0%B8%D0%B3%D0%BE%D1%80%D0%B8%D0%B0%D0%BD%D1%81%D0%BA%D0%B8%D0%B9_%D0%BA%D0%B0%D0%BB%D0%B5%D0%BD%D0%B4%D0%B0%D1%80%D1%8C
                    // год, номер которого кратен 400, — високосный;
                    // остальные годы, номер которых кратен 100, — невисокосные;
                    // остальные годы, номер которых кратен 4, — високосные.
                    long sumDay = 0;
                    for (int i = 0; i < year - 1; i++) {
                        if (((i + 1) % 400) == 0) {
                            sumDay += 366;

                        }
                        else {
                            if (((i + 1) % 100) == 0) {
                                sumDay += 365;
                            }
                            else {
                                if (((i + 1) % 4) == 0) {
                                    sumDay += 366;
                                }
                                else {
                                    sumDay += 365;
                                }

                            }
                        }
                    }

                    long sumDay1 = 0;
                    for (int i = 0; i < mount - 1; i++) {
                        sumDay1 += mountsYear[i];
                    }
                    sumDay1 += day;
                    if (sumDay1 > (28 + 31)) {
                        if ((year % 400) == 0) {
                            sumDay1 += 1;
                        }
                        else {
                            if ((year % 100) == 0) {
                                sumDay1 += 0;
                            }
                            else {
                                if ((year % 4) == 0) {
                                    sumDay1 += 1;
                                }
                                else {
                                    sumDay1 += 0;
                                }

                            }
                        }
                    }
                    long sumItog = sumDay + sumDay1;

                    int indD = (int)(sumItog % 7);
                    string Day = "";
                    switch (indD) {
                        case 1:
                            Day = "понедельник";
                            break;
                        case 2:
                            Day = "вторник";
                            break;
                        case 3:
                            Day = "среда";
                            break;
                        case 4:
                            Day = "четверг";
                            break;
                        case 5:
                            Day = "пятница";
                            break;
                        case 6:
                            Day = "суббота";
                            break;
                        case 0:
                            Day = "воскресенье";
                            break;


                    }
                    Console.WriteLine(Day);
                }
            }
            else {
                Console.WriteLine("В году нет столько месяцев");
            }
            Console.ReadKey();

        }
    }
}
