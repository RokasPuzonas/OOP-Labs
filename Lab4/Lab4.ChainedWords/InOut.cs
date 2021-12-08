using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4.ChainedWords
{
    static class InOut
    {
        /// <summary>
        /// Read a file line-by-line using an enumarable
        /// </summary>
        /// <param name="filename">Target file</param>
        /// <returns>Enumerable</returns>
        public static IEnumerable<string> ReadByLines(string filename)
        {
            string line;
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
