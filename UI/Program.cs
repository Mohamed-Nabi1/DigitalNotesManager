using System;
using System.Windows.Forms;
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

            // Build service provider
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

                // Run Migrations (Optional: Ensure Database Created)
                //dbContext.Database.Migrate();

                // Run the application
                System.Windows.Forms.Application.Run(new Form1());  // Replace `Form1` with your actual startup form
            }

        }
    }
}