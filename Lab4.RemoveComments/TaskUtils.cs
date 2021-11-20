using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4.RemoveComments
{
    class TaskUtils
    {
        /** Removes comments and returns an indication about performed activity.
            @param line – line having possible comments
            @param newLine – line without comments */
        public static string[] RemoveComments(string[] lines)
        {
            List<string> cleanedLines = new List<string>();

            foreach (string line in lines)
            {
                Match case1 = Regex.Match(line, @"^(.*)//.*$");
                if (case1.Success)
                {
                    if (case1.Groups[1].Value.Length > 0)
                    {
                        cleanedLines.Add(case1.Groups[1].Value);
                    }
                }
                else
                {
                    cleanedLines.Add(line);
                }
            }
            
            /*
            Match case1 = Regex.Match(line, @"^(.*)//.*$");
            if (case1.Success)
            {
                newLine = case1.Groups[1].Value;
                return true;
            }
            */

            return cleanedLines.ToArray();

            /*
            Match case2 = Regex.Match(line, @"^$");
            if (case2.Success)
            {
                newLine = case2.Captures[1].Value;
                return true;
            }
            */

       
            /*newLine = line;
            for (int i = 0; i < line.Length - 1; i++)
            if (line[i] == '/' && line[i + 1] == '/')
            {
                newLine = line.Remove(i);
                return true;
            }
            return false;*/
        }
    }
}
