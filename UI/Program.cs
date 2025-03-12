using Application.Interfaces;
using Application.Services;
using DigitalNotesManager.Application.Interfaces;
using DigitalNotesManager.Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using UI.Forms;

internal static class Program
{
    // Static property to store the ServiceProvider
    public static IServiceProvider ServiceProvider { get; private set; }

    [STAThread]
    static void Main()
    {
        try
        {
            // Initialize application configuration (e.g., settings, themes)
            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Configure services and dependencies
            ServiceProvider = ConfigureServices(); // Assign the ServiceProvider to the static property

            // Resolve required services from DI container
            using var scope = ServiceProvider.CreateScope();
            var noteService = scope.ServiceProvider.GetRequiredService<INoteService>();
            var categoryService = scope.ServiceProvider.GetRequiredService<ICategoryService>();
            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

            Console.WriteLine("Services resolved successfully!");

            // Run the application with Form1 and pass the required services
            System.Windows.Forms.Application.Run(new LoginForm(userService, noteService, categoryService));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Method to configure all the necessary services for DI
    private static IServiceProvider ConfigureServices()
    {
        try
        {
            // Set up configuration to read from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Set up DI container (ServiceCollection)
            var services = new ServiceCollection();

            // Register IConfiguration
            services.AddSingleton<IConfiguration>(configuration);

            // Configure database context with connection string from configuration
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped);

            // Register repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Register application services
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();

            // Register CategorySelector
            services.AddScoped<CategorySelector>();

            // Build and return the service provider
            return services.BuildServiceProvider();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Service configuration failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
    }
}
