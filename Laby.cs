using System;
using LabyCSharp.Lab50_51;
using LabyCSharp.Lab40_41;
using LabyCSharp;

bool keepRunning = true;

while (keepRunning)
{
    Console.Clear();
    Console.WriteLine("Выберите номер лабораторной работы:");
    Console.WriteLine("1 - Лабораторная работа 5");
    Console.WriteLine("2 - Лабораторная работа 10-11");
    Console.WriteLine("3 - Лабораторная работа 12-13");
    Console.WriteLine("4 - Лабораторная работа 14-15");
    Console.WriteLine("5 - Лабораторная работа 16-17");
    Console.WriteLine("6 - Лабораторная работа 18-19");
    Console.WriteLine("7 - Лабораторная работа 20-21");
    Console.WriteLine("8 - Лабораторная работа 24-25");
    Console.WriteLine("9 - Лабораторная работа 28-29");
    Console.WriteLine("10 - Лабораторная работа 30-31");
    Console.WriteLine("11 - Лабораторная работа 34-35");
    Console.WriteLine("12 - Лабораторная работа 36-37");
    Console.WriteLine("13 - Лабораторная работа 40-41");
    Console.WriteLine("14 - Лабораторная работа 46-47");
    Console.WriteLine("15 - Лабораторная работа 50-51");
    Console.WriteLine("16 - Лабораторная работа 54-55");
    Console.WriteLine("17 - Лабораторная работа 56-57");
    Console.WriteLine("18 - Лабораторная работа 60-61");
    Console.WriteLine("19 - Лабораторная работа 70-71");
    Console.WriteLine("0 - Выход");
    Console.Write("Введите номер: ");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            //Lab5.Run();
            break;
        case "2":
            Lab10_11.Run();
            break;
        case "3":
            Lab12_13.Run();
            break;
        case "4":
            Lab14_15.Run();
            break;
        case "5":
            Lab16_17.Run();
            break;
        case "6":
            Lab18_19.Run();
            break;
        case "7":
            Lab20_21.Run();
            break;
        case "8":
            Lab24_25.Run();
            break;
        case "9":
            Lab28_29.Run();
            break;
        case "10":
            Lab30_31.Run();
            break;
        case "11":
            Lab34_35.Run();
            break;
        case "12":
            Lab36_37.Run();
            break;
        case "13":
            Lab40_41.Run();
            break;
        case "14":
            Lab46_47.Run();
            break;
        case "15":
            Lab50_51.Run();
            break;
        case "16":
            Lab54_55.Run();
            break;
        case "17":
            Lab56_57.Run();
            break;
        case "18":
            Lab60_61.Run();
            break;
        case "19":
            Lab70_71.Run();
            break;
        case "777":
            RunAllLabs();
            break;
        case "0":
            keepRunning = false;
            break;
        default:
            Console.WriteLine("Неверный номер лабораторной работы.");
            break;
    }

    if (keepRunning)
    {
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
    }
}

Console.WriteLine("Программа завершена.");

static void RunAllLabs()
{
    Console.WriteLine("Выполнение всех лабораторных работ...");

    //Lab5.Run();
    Lab10_11.Run();
    Lab12_13.Run();
    Lab14_15.Run();
    Lab16_17.Run();
    Lab18_19.Run();
    Lab20_21.Run();
    Lab24_25.Run();
    Lab28_29.Run();
    Lab30_31.Run();
    Lab34_35.Run();
    Lab36_37.Run();
    Lab40_41.Run();
    Lab46_47.Run();
    Lab50_51.Run();
    Lab54_55.Run();
    Lab56_57.Run();
    Lab60_61.Run();
    Lab70_71.Run();

    Console.WriteLine("Все лабораторные работы выполнены.");
}