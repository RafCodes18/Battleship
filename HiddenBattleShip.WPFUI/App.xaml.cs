using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Configuration;
using System.Data;
using System.Windows;

namespace HiddenBattleShip.WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ServiceProvider serviceProvider;
        public static IConfiguration Configuration;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

        }

        private void ConfigureServices(ServiceCollection services)
        {
            var configSettings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configSettings;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configSettings)
                .CreateLogger();



            services.AddSingleton<GameList>()
                .AddLogging(c => c.AddConsole())
                .AddLogging(c => c.AddDebug())
                .AddLogging(c => c.AddSerilog())
               .AddLogging(c => c.AddEventLog());

            /*  services.AddSingleton<QRCode>()
                 .AddLogging(c => c.AddConsole())
                 .AddLogging(c => c.AddDebug())
                 .AddLogging(c => c.AddSerilog())
                 .AddLogging(c => c.AddEventLog()); */


        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var GameList = serviceProvider.GetService<GameList>();

            //var screen = serviceProvider.GetService<QRCode>();

            GameList.Show();
        }


    }

}
