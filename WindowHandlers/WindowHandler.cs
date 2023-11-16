using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Ciphers;
using WpfApp1.Enums;
using WpfApp1.Windows;

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

		public static void InitalizeRSAWindow(
			List<List<BigInteger>> rsa,
			Tuple<BigInteger, BigInteger> PublicKey,
			Tuple<BigInteger, BigInteger> PrivateKey) 
		{
			var RSAWindow = new Windows.RSA(
				string.Join("", PrivateKey),
				string.Join("", PublicKey),
				ConvertToString(rsa));

			RSAWindow.Show();
		}

		private static string ConvertToString(List<List<BigInteger>> listOfLists)
		{
			// Konwersja każdej listy do ciągu znaków i połączenie ich
			return string.Join(",", listOfLists.Select(block =>
				string.Join(",", block.Select(bigInteger => bigInteger.ToString()))));
		}
	}
}
