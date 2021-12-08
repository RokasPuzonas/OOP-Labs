using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4.RemoveLines
{
    class InOut
    {
        public static int LongestLine(string fin)
        {
            int No = -1;
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int length = 0;
                int lineNo = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > length)
                    {
                        length = line.Length;
                        No = lineNo;
                    }
                    lineNo++;
                }
            }
            return No;
        }        public static List<int> LongestLines(string fin)
        {
            List<int> lines = new List<int>();
            int longestLength = 0;

            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int lineNo = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > longestLength)
                    {
                        longestLength = line.Length;
                        lines.Clear();
                        lines.Add(lineNo);
                    }
                    else if (line.Length == longestLength)
                    {
                        lines.Add(lineNo);
                    }
                    lineNo++;
                }
            }

            return lines;
        }        public static void RemoveLine(string fin, string fout, int No)
        {
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int lineNo = 0;
                using (var writer = File.CreateText(fout))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (No != lineNo)
                        {
                            writer.WriteLine(line);
                        }
                        lineNo++;
                    }
                }
            }
        }

        public static void RemoveLines(string fin, string fout, List<int> lines)
        {
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int lineNo = 0;
                using (var writer = File.CreateText(fout))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!lines.Contains(lineNo))
                        {
                            writer.WriteLine(line);
                        }
                        lineNo++;
                    }
                }
            }
        }
    }
}
