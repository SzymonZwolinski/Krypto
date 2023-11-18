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
		public static void InitalizeAndOpenResultWindow(
			string text,
			CipherTypes cipherType,
			IServiceProvider serviceProvider,
			string? privateKey = null)
		{
			var resultWindow = new ResultWindow(
				serviceProvider.GetRequiredService<IPoli>(),
				serviceProvider.GetRequiredService<IMono>(),
				serviceProvider.GetRequiredService<ITrans>(),
				serviceProvider.GetRequiredService<IRC4>(),
				serviceProvider.GetRequiredService<IDES>(),
				serviceProvider);

			resultWindow.InitalizeUi(text, cipherType);
			if (!string.IsNullOrWhiteSpace(privateKey))
			{
				resultWindow.AddPrivateKey(privateKey);
			}

			resultWindow.Show();
		}

		public static void InitalizeAndOpenResultWindowForDes(
			string text,
			CipherTypes cipherType,
			IServiceProvider serviceProvider,
			byte[]? privateKey = null)
		{
			var resultWindow = new ResultWindow(
				serviceProvider.GetRequiredService<IPoli>(),
				serviceProvider.GetRequiredService<IMono>(),
				serviceProvider.GetRequiredService<ITrans>(),
				serviceProvider.GetRequiredService<IRC4>(),
				serviceProvider.GetRequiredService<IDES>(),
				serviceProvider);

			resultWindow.InitalizeUi(text, cipherType);
			if (privateKey.Any())
			{
				resultWindow.AddBytePrivateKey(privateKey);
			}

			resultWindow.Show();
		}

		public static void InitalizeAndOpenResultWindow(
			string text, 
			CipherTypes cipherType,
			string matrix,
			IServiceProvider serviceProvider)
		{
			var resultWindow = new ResultWindow(
				serviceProvider.GetRequiredService<IPoli>(),
				serviceProvider.GetRequiredService<IMono>(),
				serviceProvider.GetRequiredService<ITrans>(),
				serviceProvider.GetRequiredService<IRC4>(),
				serviceProvider.GetRequiredService<IDES>(),
				serviceProvider);

			resultWindow.InitalizeUi(text, cipherType);
			if(string.IsNullOrWhiteSpace(matrix)) 
			{
				resultWindow.InitalizeDivider(matrix);
			}

			resultWindow.Show();
		}

		public static void InitalizeRSAWindow(
			List<List<BigInteger>> rsa,
			Tuple<BigInteger, BigInteger> PublicKey,
			Tuple<BigInteger, BigInteger> PrivateKey,
			IServiceProvider serviceProvider) 
		{
			var RSAWindow = new Windows.RSA(serviceProvider.GetRequiredService<IRSA>(), serviceProvider);

			RSAWindow.InitalizeUI(PrivateKey, PublicKey, rsa);

			RSAWindow.Show();
		}

		public static void InitaliseHammingWindow(string HammingCode, IServiceProvider serviceProvider)
		{
			var HammingWindow = new Windows.Hamming(serviceProvider.GetRequiredService<IHamming>(), serviceProvider);

			HammingWindow.InitalizeUI(HammingCode);
			HammingWindow.Show();
		}
	}
}
