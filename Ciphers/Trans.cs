using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.Ciphers
{
	public class Trans : ITrans
	{
		public (string, string) TransparentEncription(string sentence)
		{
			var wordsInSentence = sentence.Split(' ').ToList();

			var maxLength = wordsInSentence.Max(x => x.Length);
			var paddedWords = wordsInSentence.Select(x => x.PadRight(maxLength)).ToList();

			var transformedWords = new List<string>();
			var tempWord = new StringBuilder();

			for (var y = 0; y < maxLength; y++)
			{
				tempWord.Clear();
				for (var x = 0; x < paddedWords.Count(); x++)
				{
					tempWord.Append(paddedWords[x][y]);
				}
				tempWord.Append("!");
				transformedWords.Add(tempWord.ToString());
			}

			return (string.Join("", transformedWords.ToArray()), string.Join("\n", transformedWords));
		}

		public string DecodeTransparent(string sentence)
		{
			var firstExclamationMark = sentence.IndexOf("!");

			var list = InitializeList(firstExclamationMark);

			var sentenceWithoutExclamationMarks = sentence.Replace("!", "");

			for (var x = 0; x < sentenceWithoutExclamationMarks.Length; x++)
			{
				list[x % firstExclamationMark] += sentenceWithoutExclamationMarks[x];
			}
			return string.Join("", list.ToArray());
		}

		private List<string> InitializeList(int length)
		{
			var list = new List<string>();
			while (list.Count() != length)
			{
				list.Add(string.Empty);
			}

			return list;
		}
	}
}
