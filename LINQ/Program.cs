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
            2/6   14.1. Фильтрация

            SelectMany — метод расширения, предоставляющий способ сделать сложную фильтрацию
            Здесь происходит так называемая проекция элементов в новую сущность, к которой потом применяются фильтры выборки
            */

            // Подготовим данные
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

     
            // Составим запрос ()
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

/*
Задание 14.1.6
Дан список массивов:

var numsList = new List<int[]>()
{
   new[] {2, 3, 7, 1},
   new[] {45, 17, 88, 0},
   new[] {23, 32, 44, -6},
};
Сделайте выборку всех чисел в новую коллекцию, расположив их в ней по возрастанию.

Результат выведите в консоль.

Ответ для самопроверки
var orderedNums = numsList
   .SelectMany(s => s) // выбираем элементы
   .OrderBy(s => s); // сортируем

// выводим
foreach (var ord in orderedNums)
    Console.WriteLine(ord);
*/