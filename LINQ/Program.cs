using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTest
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            2/6   14.1. Фильтрация SelectMany() - Сложные фильтры 

            SelectMany — метод расширения, предоставляющий способ сделать сложную фильтрацию
            Здесь происходит так называемая проекция элементов в новую сущность, к которой потом применяются фильтры выборки
            */

            //У нас есть список студентов, нужно получить тех, кто младше 28 лет и владеет английским языком

            // Подготовим данные
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };


            // Составим запрос () - Здесь происходит так называемая проекция элементов в новую сущность, к которой потом применяются фильтры выборки. 
            //как это происходит:

            //Сама последовательность элементов(список языков студента) передаётся в качестве первого параметра.
            //Вторым параметром будет функция, которая осуществляет преобразование, возвращая на выходе пары «студент - язык»,
            //к которым потом применяется дальнейшая фильтрация.

            var selectedStudents = students.SelectMany(
                   // коллекция, которую нужно преобразовать
                   s => s.Languages,
                   // функция преобразования, применяющаяся к каждому элементу коллекции
                   (s, l) => new { Student = s, Lang = l })
               // дополнительные условия                          
               .Where(s => s.Lang == "английский" && s.Student.Age < 28)
               // указатель на объект выборки
               .Select(s => s.Student);

            // Выведем результат
            foreach (Student student in selectedStudents)
                Console.WriteLine($"{student.Name} - {student.Age}");

            // выводим
            foreach (var ord in orderedNums)
                Console.WriteLine(ord);

            //Андрей - 23
            //Сергей - 27

            //Задание 14.1.6
            //Дан список массивов:

            //var numsList = new List<int[]>()
            //{
            //    new[] {2, 3, 7, 1},
            //    new[] {45, 17, 88, 0},
            //    new[] {23, 32, 44, -6},
            //};

            //var orderedNums = numsList
            // .SelectMany(s => s) // выбираем элементы
            // .OrderBy(s => s); // сортируе   

        }

        // Создадим модель класс для города
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }
    }
}

