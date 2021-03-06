﻿using System;
using System.IO;
using System.Collections.Generic;

namespace _07_HW_GubinVS_2
{
    class Program
    {
        /// Разработать ежедневник.
        /// В ежедневнике реализовать возможность 
        /// - создания
        /// - удаления
        /// - реактирования 
        /// записей
        /// 
        /// В отдельной записи должно быть не менее пяти полей
        /// 
        /// Реализовать возможность 
        /// - Загрузки данных из файла
        /// - Выгрузки данных в файл
        /// - Добавления данных в текущий ежедневник из выбранного файла
        /// - Экспорт записей по выбранному диапазону дат
        /// - Упорядочивания записей ежедневника по выбранному полю
        /// 

        static void Main(string[] args)
        {
            string path = @"C:\07_HW_GubinVS_2\data.csv";
            //string path = InputPath();
            Menu(path);

            Console.ReadKey();
        }




        /// <summary>
        /// Меню выполняющее бесконечный цикл, предлагая пользователю выбрать режим работы.
        /// </summary>
        public static void Menu(string path)
        {
            do
            {
                Print("\n\n  Необходимо выбрать режим работы:\n" +
                    "1 - Добавить данные из консоли.\n" +
                    "2 - Добавить данные из файла.\n" +
                    "3 - Редактировать данные.\n" +
                    "4 - Удалить данные.\n" +
                    "5 - Вывести данные в консоль.\n" +
                    "6 - Экспорт записей по выбранному диапазону дат.\n" +
                    "7 - Упорядочить данные по выбранному полю.\n");


                switch (Convert.ToInt32(Console.ReadLine()))
                {

                    case 1:

                        #region Режим добавления данных из консоли
                            AddItemFromConsole(path);
                        #endregion Режим добавления данных из консоли
                        break;

                    case 2:
                        #region Режим добавления данных из файла
                            AddItemFromFile(path);
                        #endregion Режим добавления данных из файла
                        break;
                    case 3:
                        #region Режим редактирования данных
                            EditData(path);
                        #endregion Режим редактирования данных
                        break;

                    case 4:
                        #region Режим удаления данных
                            RemoveData(path);
                        #endregion Режим удаления данных
                        break;
                    case 5:
                        #region Режим просмотра данных      
                            ReadData(path);
                        #endregion Режим просмотра данных   
                        break;
                    case 6:
                        #region Режим экспорта данных по выбранному диапазону дат
                            ExportData(path);
                        #endregion Режим экспорта данных по выбранному диапазону дат
                        break;
                    case 7:
                        #region Сортировка данных по выбранному полю
                            SortItemForFields(path);
                        #endregion Сортировка данных по выбранному полю
                        break;
                    default:
                        Print("Команда не распознана!");
                        break;
                }
            } while (true);


        }

        /// <summary>
        ///  Метод сортировки данных по выбранному полю
        /// </summary>
        /// <param name="path"></param>
        private static void SortItemForFields(string path)
        {
            // Инициализация экземпляра структуры данных
            DataBase db = new DataBase(path);
            Print("Исходные данные:");
            // Вывод заголовка таблицы в консоль
            PrintHeading();

            // Cчитывание данных из файла (для того, чтобы показать что есть в базе)
            db.ReadFile(path);

            db.Print();

            Print("Отсортировать по: \n 1. Потреблению (ХВС) \n 2. По потреблению (ГВС)");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    db.SortTotalCold();
                    break;
                case 2:
                    db.SortTotalHotter();
                    break;
                default:
                    Print("Нет такой цыфры в меню!");
                    break;
            }

            // Вывод существующих данных в консоль
            Print("\nОтсортированные данные:");
            PrintHeading();
            db.Print();
        }


        /// <summary>
        /// Метод выводит данные, дата записи которых старше или равна верхнему диапазону и младще нижнему диапазону введенных дат 
        /// </summary>
        /// <param name="path"></param>
        private static void ExportData(string path)
        {
            // Инициализация экземпляра структуры данных
            DataBase db = new DataBase(path);

            // Вывод заголовка таблицы в консоль
            PrintHeading();

            // Cчитывание данных из файла (для того, чтобы показать что есть в базе)
            db.ReadFile(path);

            // Вывод существующих данных в консоль
            db.Print();

            // Экспорт данных
            Print("Введите полный путь к файлу в который экспортируются данные");
            string path2 = @"C:\07_HW_GubinVS_2\data2.csv"; // InputPath();

            Print("Введите верхний диапазон даты для экспорта данных. Формат ввода данных: дд.мм.гггг");
            string data = "02.03.2021";  // Console.ReadLine();

            Print("Введите нижний диапазон даты для экспорта данных. Формат ввода данных: дд.мм.гггг");
            string data2 = "15.08.2021";  //Console.ReadLine();


            // Удаление элементв списка не входящих в выбранный диапазон
            db.Export(data, data2);


            ////Вывод обновленных данных в консоль
            Print("\nЭкспортируемые данные:");
            db.Print();

            // Запись обновленных данных в файл
            File.Delete(path2);
            db.WriteFile(path2);
            Print("\n\nЭкспорт данных выполнен!");
        }

        /// <summary>
        /// Метод считывающий из файла данные и выводящий результат в консоль
        /// </summary>
        /// <param name="path"></param>
        private static void ReadData(string path)
        {
            // Инициализация экземпляра структуры данных
            DataBase db = new DataBase(path);

            // Вывод заголовка таблицы в консоль
            PrintHeading();

            // Cчитывание данных из файла (для того, чтобы показать что есть в базе)
            db.ReadFile(path);

            // Вывод существующих данных в консоль
            db.Print();
        }


        /// <summary>
        /// Метод удаления данных по выбранному периоду
        /// </summary>
        /// <param name="path"></param>
        private static void RemoveData(string path)
        {
            // Инициализация экземпляра структуры данных
            DataBase db = new DataBase(path);

            // Вывод заголовка таблицы в консоль
            PrintHeading();

            // Cчитывание данных из файла (для того, чтобы показать что есть в базе)
            db.ReadFile(path);

            // Вывод существующих данных в консоль
            db.Print();

            // Редактирование данных
            Print("Введите период записи, который необходимо удалить");
            string period = Console.ReadLine();

            // Удаление элемента списка по выбранному индексу
            db.RemoveItem(db.IndexOf(period));

            // Перерасчет элементов потребления
            db.RecalculateItem();

            //Вывод обновленных данных в консоль
            Print("Обновленные данные:");
            db.Print();

            // Запись обновленных данных в файл
            File.Delete(path);
            db.WriteFile(path);
        }


        /// <summary>
        /// Редактирование данных по выбранному полю
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private static void EditData(string path)
        {

            // Инициализация экземпляра структуры данных
            DataBase db = new DataBase(path);

            // Вывод заголовка таблицы в консоль
            PrintHeading();

            // Cчитывание данных из файла (для того, чтобы показать что есть в базе)
            db.ReadFile(path);

            // Вывод существующих данных в консоль
            db.Print();

            // Редактирование данных
            Print("Введите период записи, который необходимо отредактировать");
            string period = Console.ReadLine();
            // Найти индекс записи по периоду
            //Console.WriteLine(db.IndexOf(period));
            // Перезаписать новыми данныим

            Print("Заполните новые данные");
            db.AddItemDBIndex(db.IndexOf(period), AddDataFromConsole());
            db.RecalculateItem();

            //Вывод обновленных данных в консоль
            db.Print();

            // Запись обновленных данных в файл
            File.Delete(path);
            db.WriteFile(path);
        }

        /// <summary>
        /// Реализация меню: Добавление данных считанных из файла
        /// </summary>
        /// <param name="path"></param>
        private static void AddItemFromFile(string path)
        {
            // Инициализация экземпляра структуры
            DataBase db = new DataBase(path);

            // Считывание данных из файла
            db.ReadFile(path);

            // Запрос на путь к файлу с данными
            string path2 = InputPath();
            db.ReadFileSecond(path2);

            // Вывод обновленных данных в консоль
            db.Print();

            // Запись обновленных данных в файл
            File.Delete(path);
            db.WriteFile(path);
        }


        /// <summary>
        /// Реализация меню: Ввод данных в базу с консоли
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private static void AddItemFromConsole(string path)
        {
            // Инициализация экземпляра структуры данных
            DataBase db = new DataBase(path);

            // Вывод заголовка таблицы в консоль
            PrintHeading();

            // Cчитывание данных из файла (для того, чтобы показать что есть в базе)
            db.ReadFile(path);

            // Вывод существующих данных в консоль
            db.Print();


            // Ввод данных в базу из консоли 
            db.AddItemDBForArray(AddDataFromConsole());

            // Вывод обновленных данных в консоль
            db.Print();

            // Запись обновленных данных в файл
            File.Delete(path);
            db.WriteFile(path);
        }


        /// <summary>
        /// Метод сбора данных полей структуры из консоли, 
        /// возвращает массив string
        /// </summary>
        private static string[] AddDataFromConsole()
        {
            Console.WriteLine("Введите дату подачи данных: в формате гггг, мм, дд");
            string date = Console.ReadLine();

            Console.WriteLine("Введите месяц за который подаются данные:");
            string period = Console.ReadLine();

            Console.WriteLine("Введите показания счетчика холодного водоснабжения (ХВС):");
            string cold = Console.ReadLine();

            Console.WriteLine("Введите показания счетчика горячего водоснабжения (ГВС):");
            string hotter = Console.ReadLine();

            string[] item = new string[] { date, period, cold, hotter };

            return item;
        }


        /// <summary>
        /// Метод инициализирующий и выводящий заголовок полей таблицы в консоль
        /// </summary>
        private static void PrintHeading()
        {
            Heading heading = new Heading();
            heading.Print();
        }


        /// <summary>
        /// Метод получения пути к файлу, хранящему данные, из консоли
        /// </summary>
        public static string InputPath()
        {
            Console.WriteLine("Укажите полный путь к файлу c данными:");
            string path = Console.ReadLine();
            return path;

        }


        /// <summary>
        /// Метод печати данных в консоль. 
        /// Принимает строковое значение, которое необходимо вывести в консоль
        /// </summary>
        /// <param name="text"></param>
        public static void Print(string text)
        {
            Console.WriteLine($"{text}");
        
        }
    }
}
