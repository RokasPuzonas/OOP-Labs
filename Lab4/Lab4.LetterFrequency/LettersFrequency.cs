using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab4.LetterFrequency
{
    /** To count letters frequency */
    class LettersFrequency
    {
        private const int CMax = 256;
        private Dictionary<char, int> Frequency; // Frequency of letters
        public string line { get; set; }

        public LettersFrequency()
        {
            line = "";
            Frequency = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                Frequency.Add(c, 0);
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Frequency.Add(c, 0);
            }
        }

        public int Get(char character)
        {
            return Frequency[character];
        }
        
        /** Counts repetition of letters. */
        public void CountLetters()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsLetter(line[i]))
                {
                    if (!Frequency.ContainsKey(line[i]))
                    {
                        Frequency.Add(line[i], 0);
                    }
                    Frequency[line[i]]++;
                }
            }
        }

        public char GetMostFrequent()
        {
            char mostFrequent = (char)(0);
            foreach (var pair in Frequency)
            {
                if (mostFrequent == 0 || pair.Value > Frequency[mostFrequent])
                {
                    mostFrequent = pair.Key;
                }
            }
            return mostFrequent;
        }

        public List<Tuple<char, int>> GetOrderedFrequencies()
        {
            List<Tuple<char, int>> frequencies = new List<Tuple<char, int>>();
            foreach (var pair in Frequency)
            {
                frequencies.Add(new Tuple<char, int>(pair.Key, pair.Value));
            }

            frequencies.Sort(delegate (Tuple<char, int> x, Tuple<char, int> y)
            {
                return -x.Item2.CompareTo(y.Item2);
            });

            return frequencies;
        }
    }
    
}
