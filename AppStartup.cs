using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Ciphers;

namespace WpfApp1
{
	public class AppStartup
	{
		public static IServiceProvider ConfigureServices()
		{
			var services = new ServiceCollection();
			services.AddScoped<IPoli, Poli>();
			services.AddScoped<IMono, Mono>();
			services.AddScoped<ITrans, Trans>();
			services.AddScoped<IBase64, Base64>();
			services.AddScoped<IHamming, Hamming>();
			services.AddScoped<IRSA, RSA>();

			return services.BuildServiceProvider();
		}
	}
}
