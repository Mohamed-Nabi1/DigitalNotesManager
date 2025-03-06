using System;
using System.Windows.Forms;
using DigitalNotesManager.Application.Interfaces;
using DigitalNotesManager.Application.Services;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UI.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Build Configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Setup Dependency Injection
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration); // Register IConfiguration
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register Services
            services.AddScoped<INoteService, NoteService>();  // Your Note Service
            services.AddScoped<IUserService, UserService>();  // Your User Service

            // Build service provider
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

                // Run the application
                System.Windows.Forms.Application.Run(new Form1()); 
            }

        }
    }
}