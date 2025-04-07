using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TodoApiClient.Interfaces;
using TodoApiClient.Services;

namespace todo
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем коллекцию сервисов
            var services = new ServiceCollection();

            // Конфигурируем сервисы
            ConfigureServices(services);

            // Строим провайдер сервисов
            ServiceProvider = services.BuildServiceProvider();

            // Создаем главное окно
            var mainWindow = new MainWindow();

            // Устанавливаем начальную страницу
            mainWindow.MainFrame.Navigate(new View.LogIn(
                ServiceProvider.GetRequiredService<IApiService>()));

            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрируем HttpClient
            services.AddHttpClient();

            // Регистрируем наш сервис API
            services.AddSingleton<IApiService, ApiService>();
        }
    }
}