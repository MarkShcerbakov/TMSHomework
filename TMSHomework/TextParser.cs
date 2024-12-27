using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class TextParser
    {
        public string Text;
        public string[] TextSentence;
        public string[] Words;
        public readonly string[] DigitWords = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        public Dictionary<int, Func<string[]>> TextParserMethods;

        public TextParser(string inputText)
        {
            Text = inputText;
            TextSentence = GetTextSentence();
            Words = GetWords();
            TextParserMethods = new()
            {
                [1] = WordsWithMaxDigits,
                [2] = LongestWord,
                [3] = DigitToWords,
                [4] = QuestionAndExclamationSentences,
                [5] = SentenceWithoutCommas,
                [6] = WordsWithSameFirstAndLastLetters,
            };
        }

        private string[] GetTextSentence() => Regex.Matches(Text, @"(?<=\A|\s).+?[\.\!\?]").Select(m => m.Value).ToArray();

        private string[] GetWords() => TextSentence.SelectMany(sentence => sentence.Split()).ToArray();

        private string[] WordsWithMaxDigits() => TextSentence.SelectMany(sentence => sentence.Split()).Where(word => Regex.IsMatch(word, @"\d+")).ToArray(); //???

        private string[] LongestWord()
        {
            var maxLength = Words.Max(word => word.Length);
            var longestWords = Words.Where(word => word.Length == maxLength).Distinct();
            var longestWord = longestWords.Select(word => $"{word}-{Words.Count(item => item == word)}").ToArray();
            return longestWord;
        }

        private string[] DigitToWords() => TextSentence.Select(sentence => Regex.Replace(sentence, @"[0-9]", m => DigitWords[int.Parse(m.Value)])).ToArray();

        private string[] QuestionAndExclamationSentences() => TextSentence.Where(sentence => "?!".Contains(sentence[^1])).OrderBy(sentence => -sentence[^1]).ToArray();

        private string[] SentenceWithoutCommas() => TextSentence.Where(sentence => Regex.IsMatch(sentence, @"[^\,]")).ToArray();

        private string[] WordsWithSameFirstAndLastLetters() => Words.Where(word => word[0] == word[^1]).Distinct().ToArray();
    }
}
