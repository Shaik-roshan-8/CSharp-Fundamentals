using System;
namespace Day05
{
    class WordFrequency
    {
        static void Main()
        {
            string paragraph = "The trader watched the charts, the charts that moved up and down, the charts that whispered profit and loss. Trading was a game, a game of patience, a game of risk, a game of reward.Every candle told a story, a story of buyers, a story of sellers, a story of balance.He placed a trade, a trade with hope, a trade with fear, a trade with discipline. The market shifted, shifted fast, shifted slow, shifted uncertain. Yet the trader stayed, stayed calm, stayed focused, stayed ready.In trading, repetition was rhythm, rhythm of risk, rhythm of reward, rhythm of learning.";
            paragraph = paragraph.ToLower();
            string cleaned = "";
            for(int i = 0; i < paragraph.Length; i++)
            {
                char c = paragraph[i];
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)) ;
                cleaned += c;
            } // removing punctuations.
            string[] words = cleaned.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int[] count = new int[words.Length];
            // counting the frequency 
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[i] == words[j])
                    {
                        count[i]++;
                    }
                }


            }

            //printing result 
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"{"Word",15} {"Count",15} {"Bar",20}");
            Console.WriteLine("---------------------------------------------------------");
            for (int i = 0; i < words.Length; i++)
            {
                string bar = new string('#', count[i]);

                Console.WriteLine($"{words[i], 15} {count[i],15} {bar,20}");
            }

        }
    }
}