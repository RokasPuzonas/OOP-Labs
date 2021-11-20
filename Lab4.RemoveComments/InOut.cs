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
                // Check line by line which differ
                int j = 0; // Used for cleaned lines
                for (int i = 0; i < lines.Length && j < cleanedLines.Length; i++)
                {
                    Console.WriteLine("{0} ============ {1}", lines[i], cleanedLines[j]);
                    if (lines[i] != cleanedLines[j])
                    {
                        writer.WriteLine(lines[i]);
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            /*
            using (var writerF = File.CreateText(fout))
            {
                using (var writerI = File.CreateText(finfo))
                {
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string newLine = line;
                            if (TaskUtils.RemoveComments(line, out newLine))
                                writerI.WriteLine(line);
                            if (newLine.Length > 0)
                                writerF.WriteLine(newLine);
                        }
                        else
                        {
                            writerF.WriteLine(line);
                        }
                    }
                }
            }
            */
        }
    }
}
