using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LinqTest
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            14.2. Проекция и выборка - Select()

            Но точно также мы могли бы спроецировать и в другой более сложный тип, в том числе анонимный.
            Допустим, из данных по студентам мы хотим выгрузить для них анкеты, но описывать модель класса анкеты не хотим, ведь больше нигде она нам не понадобится. 
            */

            //спроецировали сущности класса Student в новый тип — в строки, сохранив туда значения свойства Name.

            // Подготовим данные
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            //Допустим, из данных по студентам мы хотим выгрузить для них анкеты, но описывать модель класса анкеты не хотим, ведь больше нигде она нам не понадобится. 
            var studentApplications = from s in students
                                          // создадим анонимный тип для представления анкеты
                                      select new
                                      {
                                          FirstName = s.Name,
                                          YearOfBirth = DateTime.Now.Year - s.Age
                                      };

            // Выведем результат
            // Выведем результат
            foreach (var application in studentApplications)
                Console.WriteLine($"{application.FirstName}, {application.YearOfBirth}");

            //Андрей, 2002
            //Сергей, 1998
            //Дмитрий, 1996
            //Василий, 2001

            //Либо, если модель Анкеты у нас есть, так: 
            //var studentApplications = from s in students
            //                              // спроецируем в новую сущеность анкеты
            //                          select new Application()
            //                          {
            //                              FirstName = s.Name,
            //                              YearOfBirth = DateTime.Now.Year - s.Age
            //                          };

            //С методами расширения то же самое, ещё проще:
            //Методы расширения, к сожалению, не поддерживают определение внутренних локальных переменных, и это одно из основных преимуществ операторов перед ними
            //но эти два инструмента можно сочетать, поэтому ту часть запроса, где переменные вам нужны, можно написать с помощью операторов.

            //// выборка имен в строки
            //var names = students.Select(u => u.Name);

            //// проекция в анонимный тип
            //var applications = students.Select(u => new
            //{
            //    FirstName = u.Name,
            //    YearOfBirth = DateTime.Now.Year - u.Age
            //});

            //// проекция в другой тип
            //var applications1 = students.Select(u => new Application()
            //{
            //    FirstName = u.Name,
            //    YearOfBirth = DateTime.Now.Year - u.Age
            //});

        }
        // Создадим модель Student
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }
    }
}

/*
Задание 14.2.1
Дан массив слов:

string [] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха"};
Сделайте выборку в анонимный тип с одновременной сортировкой слов по длине. Результат выведите в консоль.

var wordsInfo =  words.Select(w =>
   new
   {  // Выборка в анонимный тип
       Name = w,
       Length = w.Length // Длину слова сохраняем сразу в свойство нового анонимного типа
   })
   .OrderBy( word => word.Length); //  сортируем коллекцию по длине
 
 
// выводим
foreach (var word in wordsInfo)
   Console.WriteLine($"{word.Name} - {word.Length} букв");
*/

