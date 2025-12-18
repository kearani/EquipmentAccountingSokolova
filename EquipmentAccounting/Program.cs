using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace WinFormsUI
{
    public class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        public static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            ConfigureServices();
            Application.Run(ServiceProvider.GetRequiredService<DepartmentForm>());

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

            static void InitializeDatabase()
            {
                try
                {
                    using var scope = ServiceProvider.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<DAL.AppDbContext>();

                    context.Database.EnsureCreated();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка инициализации БД: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            static void ConfigureServices()
            {
                var services = new ServiceCollection();

                services.AddTransient<DepartmentForm>();
                services.AddTransient<DepartmentAddForm>();

                services.AddScoped<DAL.AppDbContext>();
                services.AddScoped<DAL.Repositories.IDepartmentRepository, DAL.Repositories.DepartmentRepository>();
                services.AddScoped<BLL.Services.DepartmentService>();

                ServiceProvider = services.BuildServiceProvider();

                InitializeDatabase();
            }

        }
    }
}