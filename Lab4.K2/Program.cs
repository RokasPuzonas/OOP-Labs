using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace Lab4.K2
{
    static class TaskUtils
    {
        public static bool NoDigits(string line)
        {
            return !Regex.IsMatch(line, @"\d");
        }

        public static int NumberDifferentVowelsInLine(string line)
        {
            string vowels = "aeiyouąęėįųū";
            int count = 0;

            line = line.ToLower();
            foreach (char vowel in vowels)
            {
                count += line.Contains(vowel) ? 1 : 0;
            }

            return count;
        }

        // Note: returns words including punctuation after them
        public static MatchCollection MatchByWords(string line, string punctuation)
        {
            string pattern = string.Format(@"[^{0}]+[{0}]*", Regex.Escape(punctuation));
            return Regex.Matches(line, pattern);
        }

        public static string FindWord1Line(string line, string punctuation)
        {
            List<string> wordsWith3Vowels = new List<string>();

            foreach (Match match in MatchByWords(line, punctuation))
            {
                int vowelCount = NumberDifferentVowelsInLine(match.Value);
                if (vowelCount == 3)
                {
                   wordsWith3Vowels.Add(match.Value);
                }
            }

            string longestWord = "";
            foreach (string word in wordsWith3Vowels)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }

            return longestWord;
        }

        public static string EditLine(string line, string punctuation, string word)
        {
            // 1. Find given word in line
            MatchCollection words = MatchByWords(line, punctuation);
            int wordPosition = -1;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Value == word)
                {
                    wordPosition = i;
                    break;
                }
            }

            if (wordPosition == -1) return line;

            // 2. Move found word to front
            StringBuilder builder = new StringBuilder();
            builder.Append(words[wordPosition]);
            for (int i = 0; i < words.Count; i++)
            {
                if (i != wordPosition)
                {
                    builder.Append(words[i]);
                }
            }

            // 3. Profit
            return builder.ToString();
        }

        public static Match MatchLastWord(string line, string punctuation)
        {
            string pattern = string.Format(@"[^{0}]+[{0}]*$", Regex.Escape(punctuation));
            return Regex.Match(line, pattern);
        }

        public static string FindWord2Line(string line, string punctuation)
        {
            Match lastWord = MatchLastWord(line, punctuation);
            if (NoDigits(lastWord.Value))
            {
                return lastWord.Value;
            }
            else
            {
                return "";
            }
        }

        public static IEnumerable<string> ReadByLines(string filename)
        {
            string line;
            using (StreamReader reader = new StreamReader(filename, Encoding.UTF8))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static void PerformTask(string fd, string fr)
        {
            List<string> wordsWithoutDigits = new List<string>();
            string punctuation = null;
            using (StreamWriter writer = File.CreateText(fr))
            {
                foreach (string line in ReadByLines(fd))
                {
                    if (punctuation == null)
                    {
                        punctuation = line;
                        continue;
                    }

                    string longestWord = TaskUtils.FindWord1Line(line, punctuation);
                    if (longestWord != "")
                    {
                        writer.WriteLine(TaskUtils.EditLine(line, punctuation, longestWord));
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }

                    string wordWithoutDigits = TaskUtils.FindWord2Line(line, punctuation);
                    if (wordWithoutDigits != "")
                    {
                        wordsWithoutDigits.Add(wordWithoutDigits);
                    }
                }

                char[] punctuationChars = punctuation.ToCharArray();
                foreach (string word in wordsWithoutDigits)
                {
                    writer.WriteLine(word.Trim(punctuationChars));
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TaskUtils.PerformTask("Tekstas.txt", "RedTekstas.txt");
        }
    }
}

