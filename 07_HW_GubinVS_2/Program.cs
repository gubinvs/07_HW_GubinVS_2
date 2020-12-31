﻿using System;
using System.IO;

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
        /// - Импорт записей по выбранному диапазону дат
        /// - Упорядочивания записей ежедневника по выбранному полю
        /// 

        static void Main(string[] args)
        {
            string path = @"C:\07_HW_GubinVS\data.csv";
            //string path = Input();
            //Start();

            DataBase d = new DataBase();
            d.AddItemDB(new DateTime (2020,01,01), "Январь", 11, 12);
            d.AddItemDB(new DateTime(2020, 02, 01), "Февраль", 15, 19);
            d.AddItemDB(new DateTime(2020, 01, 01), "Март", 11, 12);
            d.AddItemDB(new DateTime(2020, 02, 01), "Fghtkm", 15, 19);
            d.Print();
        

            Console.ReadKey();
        }


        /// <summary>
        /// Метод выполняющий бесконечный цикл по предложению пользователю выбрать действие
        /// </summary>
        public static void Start()
        {
            do
            {
            Print("Необходимо выбрать режим работы:\n" +
                "1 - Добавить данные из консоли.\n" +
                "2 - Добавить данные из файла.\n" +
                "3 - Редактировать данные.\n" +
                "4 - Удалить последние данные.\n" +
                "5 - Вывести данные в консоль.\n" +
                "6 - Импорт записей по выбранному диапазону дат.\n" +
                "7 - Упорядочить данные по выбранному полю.\n");

            
            switch (Convert.ToInt32(Console.ReadLine()))
                {

                    case 1:
                         #region Режим добавления данных из консоли
                    
                    #endregion Режим добавления данных из консоли
                        break;

                    case 2:
                        #region Режим добавления данных из файла
                    #endregion Режим добавления данных из файла
                        break;
                    case 3:
                        #region Режим редактирования данных
                        #endregion Режим редактирования данных
                        break;
                        
                    case 4:
                         #region Режим удаления последних данных
                    
                    #endregion Режим удаления последних данных
                        break;
                    case 5:
                        #region Режим просмотра данных      
                    
                    #endregion Режим просмотра данных   
                        break;
                    case 6:
                        #region Режим импортирования данных по выбранному диапазону дат
                    
                    #endregion Режим импортирования данных по выбранному диапазону дат
                        break;
                    case 7:
                        #region Сортировка данных по выбранному полю
                    
            
                    #endregion Сортировка данных по выбранному полю
                        break;
                    default:
                        Print("Команда не распознана!");
                        break;
                }
            } while (true);


        }


        /// <summary>
        /// Метод получения пути к файлу чере консоль
        /// </summary>
        public static string Input()
        {
            Console.WriteLine("Укажите полный путь к файлу c данными:");
            string path = Console.ReadLine();
            return path;

        }


        /// <summary>
        /// Метод печати принимаемых данных в консоль
        /// </summary>
        /// <param name="text"></param>
        public static void Print(string text)
        {
            Console.WriteLine($"{text}");
        
        }
    }
}
