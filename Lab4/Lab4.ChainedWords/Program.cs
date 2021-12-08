using System;

namespace Lab4.ChainedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Knyga.txt";
            string output1 = "Rodikliai.txt";
            string output2 = "ManoKnyga.txt";
            string punctuation = " ,.;!?";
            TaskUtils.ProcessChains(input, output1, punctuation);
            //TaskUtils.ProcessAligned(input, output2, punctuation);
            TaskUtils.ProccessVericallyAligned(input, output2, punctuation);
        }
    }
}

