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

						bool multiLineComment = false;

            foreach (string line in lines)
            {
								Match case1 = Regex.Match(line, @"^(.*)/\*.*$");
								Match case2 = Regex.Match(line, @"^.*\*/(.*)$");
                Match case3 = Regex.Match(line, @"^(.*)//.*$");

								if (case1.Success)
								{
									if (!multiLineComment) {
										multiLineComment = true;
										if (case1.Groups[1].Value.Length > 0)
										{
												cleanedLines.Add(case1.Groups[1].Value);
										}
									}
								}
								else if (case2.Success)
								{
									if (multiLineComment) {
										multiLineComment = false;
										if (case2.Groups[1].Value.Length > 0)
										{
												cleanedLines.Add(case2.Groups[1].Value);
										}
									}
								}
								else if (case3.Success)
                {
                    if (case3.Groups[1].Value.Length > 0)
                    {
                        cleanedLines.Add(case3.Groups[1].Value);
                    }
                }
                else
                {
                    cleanedLines.Add(line);
                }
            }
            
            return cleanedLines.ToArray();
        }
    }
}
