using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfApp1.Ciphers;
namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private IServiceProvider _serviceProvider;

		private void ConfigureServices()
		{
			var services = new ServiceCollection();
			services.AddScoped<IPoli, Poli>();
			services.AddScoped<IMono, Mono>();
			services.AddScoped<ITrans, Trans>();
			services.AddScoped<IBase64, Base64>();
			services.AddScoped<IHamming, Hamming>();

			_serviceProvider = services.BuildServiceProvider();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ConfigureServices();

			var mainWindow = new MainWindow(
				_serviceProvider.GetRequiredService<IPoli>(),
				_serviceProvider.GetRequiredService<IMono>(), 
				_serviceProvider.GetRequiredService<ITrans>(),
				_serviceProvider.GetRequiredService<IBase64>(),
				_serviceProvider.GetRequiredService<IHamming>());

			mainWindow.Show();
		}
	}
}
