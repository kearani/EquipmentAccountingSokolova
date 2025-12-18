using System;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentAccounting.ConsoleUI
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование DAL...");

            try
            {

                using (var context = new AppDbContext())
                {

                    context.Database.EnsureCreated();

                    Console.WriteLine("База данных создана успешно!");


                    var department = new Department
                    {
                        Name = "Отдел IT",
                        Code = "1"
                    };

                    context.Departments.Add(department);
                    context.SaveChanges();

                    Console.WriteLine($"Добавлен отдел: {department.Name}");


                    var departments = context.Departments.ToList();
                    Console.WriteLine($"\nВсего отделов в базе: {departments.Count}");

                    foreach (var dept in departments)
                    {
                        Console.WriteLine($"- {dept.Name} ({dept.Code})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Подробности: {ex.InnerException?.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();









        }
    }
}