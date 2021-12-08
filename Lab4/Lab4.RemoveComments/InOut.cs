using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4.RemoveComments
{
    class InOut
    {
        public static void Process(string fin, string fout, string finfo)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            string[] cleanedLines = TaskUtils.RemoveComments(lines);

            File.WriteAllLines(fout, cleanedLines);

            using (var writer = File.CreateText(finfo))
            {
                int j = 0; // Used for cleaned lines
                // Check line by line which differ
                for (int i = 0; i < lines.Length && j < cleanedLines.Length; i++)
                {
                    if (lines[i] != cleanedLines[j])
                    {
                        writer.WriteLine(lines[i]);
												if (lines[i].StartsWith(cleanedLines[j]))
												{
														j++;
												}
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }
    }
}
