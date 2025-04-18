﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTest
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            Введение - удобный инструмент — LINQ, или Language Integrated Query
            
            Эта технология берет начало из практики по работе с базами данных с помощью языка запросов SQL,
            LINQ делает возможным применение SQL-подобного синтаксиса в программах на языке C# при работе с данными.
            пример SQL-запроса, и даже не обладая опытом и специальными знаниями, вы можете прочитать его и понять, что происходит: 
            SELECT * FROM Users WHERE Country='Germany' AND City='Berlin';
            
            Есть следующие разновидности LINQ для разных задач: 

            LINQ to Objects: применяется для работы с массивами и коллекциями;
            LINQ to Entities: применяется для работы с базой данных через Entity Framework;
            LINQ to SQL: используется как технология доступа к данным в MS SQL Server;
            LINQ to XML: применяется при работе с файлами XML;
            LINQ to DataSet: применяется при работе с объектом DataSet;
            Parallel LINQ (PLINQ): используется для выполнения параллельных запросов.

            мы рассмотрим LINQ to Objects
            */

            //Запросы LINQ

            //выбрать имена на букву А и отсортировать в алфавитном порядке
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            // список, куда будем сохранять выборку
            var orderedList = new List<string>();

            // пробежимся по массиву и добавим искомое в наш список
            foreach (string person in people)
            {
                if (person.ToUpper().StartsWith("А"))
                    orderedList.Add(person);
            }

            // отсортируем список
            orderedList.Sort();
            foreach (string s in orderedList)
                Console.WriteLine(s);
        }
    }
}