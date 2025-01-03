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
        public readonly string[] DigitWords = { "<ноль>", "<один>", "<два>", "<три>", "<четыре>", "<пять>", "<шесть>", "<семь>", "<восемь>", "<девять>" };
        public Dictionary<int, Func<string[]>> TextParserMethods;
        public bool IsCorrectInputText;

        public TextParser(string inputText)
        {
            Text = inputText;
            TextSentence = GetTextSentence();
            Words = GetWords();
            IsCorrectInputText = CheckInputText();
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

        private bool CheckInputText()
        {
            var check = Regex.IsMatch(Text, @"\w+[\.\!\?]");
            if (!check)
            {
                Console.WriteLine("\"Введен некорректный текст! Программа завершена!\"");
            }
            return check;
        }

        private string[] GetTextSentence() => Regex.Matches(Text, @"\w.+?[\.\!\?]").Select(m => m.Value).ToArray();

        private string[] GetWords() => TextSentence.SelectMany(sentence => Regex.Matches(sentence, @"\b(\w|[-'])+\b")).Select(m => m.Value).ToArray();

        private string[] WordsWithMaxDigits() => Words.Where(word => Regex.IsMatch(word, @"\d+")).OrderBy(word => -word.Length).ToArray();

        private string[] LongestWord()
        {
            var maxLength = Words.Max(word => word.Length);
            var longestWords = Words.Distinct().Where(word => word.Length == maxLength);
            var longestWordsCount = longestWords.Select(word => Words.Count(item => item == word));
            var longestWord = longestWords.Select((word, idx) => $"{word} - {longestWordsCount.ElementAt(idx)}").ToArray();
            return longestWord;
        }

        private string[] DigitToWords() => TextSentence.Select(sentence => Regex.Replace(sentence, @"[0-9]", m => DigitWords[int.Parse(m.Value)])).ToArray();

        private string[] QuestionAndExclamationSentences() => TextSentence.Where(sentence => "?!".Contains(sentence[^1])).OrderBy(sentence => -sentence[^1]).ToArray();

        private string[] SentenceWithoutCommas() => TextSentence.Where(sentence => !Regex.IsMatch(sentence, @"\,")).ToArray();

        private string[] WordsWithSameFirstAndLastLetters() => Words.Distinct().Where(word => word[0] == word[^1]).ToArray();

        public void GetParsedText(int choice)
        {
            if (TextParserMethods.TryGetValue(choice, out Func<string[]> textParserMethods) &&
    DescriptionSelector.Descriptions.TryGetValue(choice, out string description))
            {
                Console.WriteLine(description);
                foreach (var item in textParserMethods().DefaultIfEmpty("-"))
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Сделайте корректный выбор!\n");
            }
        }
    }
}
