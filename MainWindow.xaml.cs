using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Ciphers;
using WpfApp1.Enums;
using WpfApp1.Helpers;
using WpfApp1.WindowHandlers;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string ContentToCipher = string.Empty;
		private string Key = string.Empty;
		private bool IsContentBinary = false;

		private readonly IPoli _poli;
		private readonly IMono _mono;
		private readonly ITrans _trans;
		private readonly IBase64 _base64;
		private readonly IHamming _hamming;	

		public MainWindow(
			IPoli poli, 
			IMono mono,
			ITrans trans,
			IBase64 base64,
			IHamming hamming)
		{
			_poli = poli;
			_mono = mono;
			_trans = trans;
			_base64 = base64;
			_hamming = hamming;

			InitializeComponent();
		}

		#region Buttons
		private void MonoBtn_Click(object sender, RoutedEventArgs e)
		{
			if(!CheckCorrectValues())
			{
				return;
			}

			try
			{
				int.Parse(Key);
			}
			catch(Exception ex)
			{
				return;
			}

			var result = _mono.MonoalphabeticEncrypt(ContentToCipher, int.Parse(Key));

			WindowHandler.InitalizeAndOpenResultWindow(result, CipherTypes.Mono);
		}

		private void PoliBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CheckCorrectValues())
			{
				return;
			}

			var result = _poli.PolyalphabeticEncrypt(ContentToCipher, Key);
			WindowHandler.InitalizeAndOpenResultWindow(result, CipherTypes.Poli);
		}

		private void TransBtn_Click(object sender, RoutedEventArgs e)
		{

			var (result, matrix) = _trans.TransparentEncription(ContentToCipher);

			WindowHandler.InitalizeAndOpenResultWindow(result, CipherTypes.Trans, matrix);

		}

		private void Base64Btn_Click(object sender, RoutedEventArgs e)
		{
			string result;
			if(IsContentBinary)
			{
				result = _base64.BinToBase64(StringToBin.BinaryStringToByteArray(ContentToCipher));
			}
			else 
			{
				result = _base64.ToBase64(ContentToCipher);
			}

			WindowHandler.InitalizeAndOpenResultWindow(result, CipherTypes.Base64);
		}

		private void HammingBtn_Click(object sender, RoutedEventArgs e)
		{
			string result;
			if (IsContentBinary)
			{
				result = _hamming.EncodeBinHamming(ContentToCipher);
			}
			else
			{
				result = _hamming.EncodeHamming(ContentToCipher);
			}

			WindowHandler.InitalizeAndOpenResultWindow(result, CipherTypes.Hamming);
		}

		#endregion

		private void TextOrBinChcBox_Checked(object sender, RoutedEventArgs e)
		{
			IsContentBinary = true;
		}

		private void TextOrBinChcBox_Unchecked(object sender, RoutedEventArgs e)
		{
			IsContentBinary = false;
		}

		private void GetFromFileBtn_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new Microsoft.Win32.OpenFileDialog();
			
			var result = dialog.ShowDialog();

			if (result == true)
			{
				ContentToCipher = File.ReadAllText(dialog.FileName);

				UpdateContentBox();
			}
		}

		private void UpdateContentBox()
		{
			ContentBox.Text = ContentToCipher;
		}

		private void KeyTxtBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			Key = KeyTxtBox.Text;
		}

		private void ContentBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			ContentToCipher = ContentBox.Text;
		}

		private bool CheckCorrectValues()
		{
			if (string.IsNullOrWhiteSpace(Key) || string.IsNullOrWhiteSpace(ContentToCipher))
			{
				return false;
			}

			return true;
		}
	}
}
