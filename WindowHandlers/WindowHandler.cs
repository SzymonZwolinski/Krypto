using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Ciphers;
using WpfApp1.Enums;

namespace WpfApp1.WindowHandlers
{
	public static class WindowHandler
	{
		public static void InitalizeAndOpenResultWindow(string text, CipherTypes cipherType, string optionalStep)
		{
			var resultWindow = new ResultWindow(text, cipherType, optionalStep);

			resultWindow.Show();
		}

		public static void InitalizeAndOpenResultWindow(string text, CipherTypes cipherType)
		{
			var resultWindow = new ResultWindow(text, cipherType);

			resultWindow.Show();
		}
	}
}
