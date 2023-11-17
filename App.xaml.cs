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

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			_serviceProvider = AppStartup.ConfigureServices();

			var mainWindow = new MainWindow(
				_serviceProvider.GetRequiredService<IPoli>(),
				_serviceProvider.GetRequiredService<IMono>(),
				_serviceProvider.GetRequiredService<ITrans>(),
				_serviceProvider.GetRequiredService<IBase64>(),
				_serviceProvider.GetRequiredService<IHamming>(),
				_serviceProvider.GetRequiredService<IRSA>(),
				_serviceProvider.GetRequiredService<IRC4>(),
				_serviceProvider);

			mainWindow.Show();
		}
	}
}
