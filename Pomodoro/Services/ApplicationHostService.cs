using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pomodoro.Services
{
    public class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private MainPage _mainPage;

        public ApplicationHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await InitializeAsync();
            await ProcessActivationAsync();
            await StartupAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        private async Task StartupAsync()
        {
            await Task.CompletedTask;
        }

        private async Task ProcessActivationAsync()
        {
            if (App.Current.Windows.OfType<MainPage>().Any())
                await Task.CompletedTask;

            _mainPage = _serviceProvider.GetService<MainPage>();
            _mainPage.Show();
            await Task.CompletedTask;
        }
    }
}
