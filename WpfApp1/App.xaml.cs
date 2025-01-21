using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using WpfApp1.Configuration;
using WpfApp1.Core;
using WpfApp1.Infrastructure;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            var configuration = ConfigurationLoader.LoadConfiguration();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            ConfigureService(serviceCollection, configuration);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            

            OracleConfiguration.OracleDataSources.Add(configuration.GetSection("OracleDataSource:TnsName").Value, configuration.GetSection("OracleDataSource:TnsDescriptor").Value);

            services.AddSingleton<IDatabaseService>(provider =>
                new DatabaseService(configuration.GetSection("ConnectionStrings:OracleConnection").Value));

            services.AddSingleton<ISftpService>(provider =>
                new SftpService(
                    configuration["Sftp:Host"],
                    configuration["Sftp:Username"],
                    configuration["Sftp:Password"]
                    ));
            services.AddTransient<MainWindow>();
        }
    }

}
