using System;

namespace LR2_OOP_CSharp
{
    class Project
    {
        public string Title { get; set; }
        public int DurationInDays { get; set; }

        public Project(string title, int durationInDays)
        {
            Title = title;
            DurationInDays = durationInDays;
        }

        public void ShowProjectInfo()
        {
            Console.WriteLine($"Проект: {Title}, длительность: {DurationInDays} дней");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Человек: {Name}, возраст: {Age}");
        }
    }

    // Класс Employee наследуется от Person
    class Employee : Person
    {
        public string Company { get; set; }
        public string Position { get; set; }

        public Employee(string name, int age, string company, string position)
            : base(name, age)
        {
            Company = company;
            Position = position;
        }

        // Переопределяю метод базового класса
        public override void ShowInfo()
        {
            Console.WriteLine($"Сотрудник: {Name}, возраст: {Age}, компания: {Company}, должность: {Position}");
        }
    }

    class Program
    {
        static void Main()
        {
            Project project = new Project("Разработка учётной системы", 45);
            project.ShowProjectInfo();
            Console.WriteLine();

            Person person = new Person("Алексей", 27);
            person.ShowInfo();
            Console.WriteLine();

            Employee employee = new Employee("Марина", 31, "ТехноСофт", "Программист");
            employee.ShowInfo();
            Console.WriteLine();

            // Через ссылку Person всё равно вызовется метод Employee
            Person anotherEmployee = new Employee("Игорь", 24, "ИТ-Центр", "Тестировщик");
            anotherEmployee.ShowInfo();

            Console.WriteLine();
            Console.WriteLine("Работа программы завершена.");
        }
    }
}
