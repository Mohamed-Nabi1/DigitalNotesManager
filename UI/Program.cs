using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;
using DigitalNotesManager.Application.Interfaces;
using DigitalNotesManager.Application.Services;
using Infrastructure.Context;
using Domain.Interfaces; // Add this namespace for ICategoryRepository
using Infrastructure.Repositories; // Add this namespace for CategoryRepository
using UI.Forms;

namespace UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Initialize application configuration (e.g., settings, themes)
            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Configure services and dependencies
            var serviceProvider = ConfigureServices();

            // Resolve required services from DI container
            using var scope = serviceProvider.CreateScope();
            var noteService = scope.ServiceProvider.GetRequiredService<INoteService>();
            var categoryService = scope.ServiceProvider.GetRequiredService<ICategoryService>();
            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();  // You can resolve more services as needed

            Console.WriteLine("Services resolved successfully!");

            // Run the application with MainForm and pass the services it needs
            System.Windows.Forms.Application.Run(new MainForm(noteService, categoryService)); // Pass resolved services to the form
        }

        // Method to configure all the necessary services for DI
        private static IServiceProvider ConfigureServices()
        {
            // Set up configuration to read from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Set up DI container (ServiceCollection)
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);  // Make IConfiguration available in DI container

            // Configure database context with connection string from configuration
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>(); // Register ICategoryRepository

            // Register application services (Scoped by default)
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>(); // Register IUserService if needed

            // Build and return the service provider
            return services.BuildServiceProvider();
        }
    }
}