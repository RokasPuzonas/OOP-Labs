using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4.ChainedWords
{
    static class TaskUtils
    {
        /// <summary>
        /// Return anything that matches a word in given text, depending on punctuation
        /// </summary>
        /// <param name="text">Target text</param>
        /// <param name="punctuation">Target punctuation</param>
        /// <returns>Word matches</returns>
        private static MatchCollection MatchByWords(string text, string punctuation)
        {
            string pattern = string.Format(@"[^{0}\n]+", Regex.Escape(punctuation));
            return Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Return anything that matches a positive integer in text
        /// </summary>
        /// <param name="text">Target text</param>
        /// <returns>Integer matches</returns>
        private static MatchCollection MatchByIntegers(string text)
        {
            return Regex.Matches(text, @"\d+");
        }

        /// <summary>
        /// Find all chains of words in given text. A chain is a sequence of words where every words
        /// last letter matches the next words first letter. And split the text into words using punctuation
        /// </summary>
        /// <param name="text">Target text</param>
        /// <param name="punctuation">Target punctuation</param>
        /// <returns>A list of chains with line number where it was found</returns>
        public static List<Tuple<int, string>> FindChains(string text, string punctuation)
        {
            List<Tuple<int, string>> chains = new List<Tuple<int, string>>();

            bool startedChain = false;
            int chainStart = 0;

            MatchCollection matches = MatchByWords(text, punctuation);
            for (int i = 1; i < matches.Count; i++)
            {
                Match prevMatch = matches[i-1];
                Match match = matches[i];
                bool matchesCriteria = prevMatch.Value.ToLowerInvariant().Last() == match.Value.ToLowerInvariant().First();

                if (matchesCriteria && !startedChain)
                {
                    startedChain = true;
                    chainStart = prevMatch.Index;
                }
                else if (!matchesCriteria && startedChain)
                {
                    startedChain = false;
                    int line = text.Substring(0, chainStart).Count(c => c == '\n')+1;
                    string chain = text.Substring(chainStart, match.Index-chainStart).TrimEnd('\n');
                    chains.Add(new Tuple<int, string>(line, chain));
                }
            }

            // Ensure that last chain gets added to list
            if (startedChain)
            {
                int line = text.Substring(0, chainStart).Count(c => c == '\n')+1;
                string chain = text.Substring(chainStart).TrimEnd('\n');
                chains.Add(new Tuple<int, string>(line, chain));
            }

            return chains;
        }

        /// <summary>
        /// Find all positive integers in given text
        /// </summary>
        /// <param name="text">Target text</param>
        /// <returns>List of positive integers</returns>
        public static List<int> FindIntegers(string text)
        {
            List<int> integers = new List<int>();

            MatchCollection matches = MatchByIntegers(text);
            foreach (Match match in matches)
            {
                integers.Add(int.Parse(match.Value));
            }

            return integers;
        }

        /// <summary>
        /// Finds the longest chain in the given text, while using given punctuation to determine words.
        /// </summary>
        /// <param name="text">Target text</param>
        /// <param name="punctuation">Target punctuation</param>
        /// <returns></returns>
        public static Tuple<int, string> FindLongestChain(string text, string punctuation)
        {
            List<Tuple<int, string>> chains = FindChains(text, punctuation);

            if (chains.Count == 0)
            {
                return null;
            }

            Tuple<int, string> longestChain = chains[0];
            foreach (var pair in chains)
            {
                if (pair.Item2.Length > longestChain.Item2.Length)
                {
                    longestChain = pair;
                }
            }

            return longestChain;
        }

        /// <summary>
        /// Ouput to file:
        /// * longest chain and where it was found
        /// * sum of all positive integers
        /// </summary>
        /// <param name="inputFile">Input file</param>
        /// <param name="outputFile">Output file</param>
        /// <param name="punctuation">Target punctuation</param>
        public static void ProcessChains(string inputFile, string outputFile, string punctuation)
        {
            string text = File.ReadAllText(inputFile, Encoding.UTF8);
            Tuple<int, string> longestChain = FindLongestChain(text, punctuation);
            List<int> integers = FindIntegers(text);

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                if (longestChain != null)
                {
                    writer.WriteLine("Ilgiausia žodžių grandinė {0} eilutėje: {1}", longestChain.Item1, longestChain.Item2);
                }
                else
                {
                    writer.WriteLine("Nėra žodžių grandinių.");
                }

                writer.WriteLine("Yra {0} žodžiai sudaryti iš skaitmenų. Jų suma: {1}", integers.Count, integers.Sum());
            }
        }

        private static string AlignWordsByColumns(List<List<string>> words, string punctuation)
        {
            StringBuilder aligned = new StringBuilder();
            Dictionary<int, int> columns = new Dictionary<int, int>();

            foreach (List<string> row in words)
            {
                int column = 0;
                foreach (string word in row)
                {
                    if (!columns.ContainsKey(column))
                    {
                        columns.Add(column, 0);
                    }
                    columns[column] = Math.Max(columns[column], word.Length);
                    column++;
                }
            }

            foreach (List<string> row in words)
            {
                int column = 0;
                for (int i = 0; i < row.Count; i++)
                {
                    string word = row[i];
                    aligned.Append(word);
                    if (i < row.Count - 1)
                    {
                        aligned.Append(new string(' ', columns[column] - word.Length));
                    }
                    column++;
                }
                aligned.Append("\n");
            }

            return aligned.ToString();
        }

        /// <summary>
        /// Align every word in a line by columns
        /// </summary>
        /// <param name="inputFile">Input file</param>
        /// <param name="outputFile">Output file</param>
        /// <param name="punctuation">Target punctuation</param>
        public static void ProcessAligned(string inputFile, string outputFile, string punctuation)
        {
            string pattern = string.Format(@"[^{0}]+[{0}]*", Regex.Escape(punctuation));
            string text = File.ReadAllText(inputFile, Encoding.UTF8);
            List<List<string>> words = new List<List<string>>();

            foreach (string line in InOut.ReadByLines(inputFile))
            {
                List<string> row = new List<string>();
                words.Add(row);
                foreach (Match match in Regex.Matches(line, pattern))
                {
                    row.Add(match.Value.TrimEnd('\n'));
                }
            }

            File.WriteAllText(outputFile, AlignWordsByColumns(words, punctuation));
        }

        /// <summary>
        /// Align every line by columns and print words vertically
        /// </summary>
        /// <param name="inputFile">Input file</param>
        /// <param name="outputFile">Output file</param>
        /// <param name="punctuation">Punctuation</param>
        public static void ProccessVericallyAligned(string inputFile, string outputFile, string punctuation)
        {
            string pattern = string.Format(@"[^{0}]+[{0}]*", Regex.Escape(punctuation));
            string text = File.ReadAllText(inputFile, Encoding.UTF8);
            List<List<string>> words = new List<List<string>>();

            foreach (string line in InOut.ReadByLines(inputFile))
            {
                int column = 0;
                int row = 0;
                foreach (Match match in Regex.Matches(line, pattern))
                {
                    if (words.Count <= row)
                    {
                        words.Add(new List<string>());
                    }
                    words[row].Add(match.Value.TrimEnd('\n'));
                    row++;
                }
                column++;
            }

            File.WriteAllText(outputFile, AlignWordsByColumns(words, punctuation));
        }
    }
}

