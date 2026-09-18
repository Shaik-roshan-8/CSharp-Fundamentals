using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks.Dataflow;
namespace Day05
{
    class StringToolkit
    {
        static void Main()
        {

           
                Console.WriteLine(IsPalindrome("    "));
                Console.WriteLine(RevereseWords("    "));
                Console.WriteLine(CountVowels("    "));
                Console.WriteLine(ToTitleCase("    "));
                Console.WriteLine(CountOccurences("    ", "    "));
                Console.WriteLine(Capitalisedstring("    "));
            

        }
        static bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (string.IsNullOrWhiteSpace(input)) return false;
            input = input.ToLower();
            input = input.Trim();
            input = input.Replace(" ", "");

            char[] temp = new char[input.Length];
            int count = 0;

            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    temp[count] = c;
                    count++;
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != temp[count - i - 1])
                {
                    return false;
                }

            }
            return true;
        }
        static int CountVowels(string input)
        {
            if(string.IsNullOrEmpty(input)) return 0;
            if (string.IsNullOrWhiteSpace(input)) return 0;
            input = input.ToLower();
            int count = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char c in input)
            {
                if (Array.Exists(vowels, v => v == c))
                {
                    count++;
                }
            }
            return count;
        }
        static string RevereseWords(string input)
        {
            if (string.IsNullOrEmpty(input)) return "Empty";
            if (string.IsNullOrWhiteSpace(input)) return "Empty";
            string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] reversedwords = new string[words.Length];

            int j = 0;
            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversedwords[j] = words[i];
                j++;
            }
            string result = string.Join(" ", reversedwords);
            return result;
        }

        static string ToTitleCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return "Empty";
            if (string.IsNullOrWhiteSpace(input)) return "Empty";
            string[] words;
            words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Capitalise(words[i]);

            }
            string result = string.Join(" ", words);
            return result;


        }
        static string Capitalise(string word)
        {
            if (string.IsNullOrEmpty(word)) return "Empty";
            if (string.IsNullOrWhiteSpace(word)) return "Empty";
            string firstchar = char.ToUpper(word[0]).ToString();
            string rest = word.Substring(1).ToLower();
            string capitalised = firstchar + rest;
            return capitalised;
        } // Helper methof for Titlecase.

        static int CountOccurences(string text, string word)  // same word means same characters too (casesensitive.)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(word))
                return 0;
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(word)) return 0;
            string[] words;
            words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word)
                    count++;
            }
            return count;
        }

        static string Capitalisedstring(string sentence)
        {
            if (string.IsNullOrEmpty(sentence)) return "Empty";
            if (string.IsNullOrWhiteSpace(sentence)) return "Empty";
            sentence.Trim();
            string[] words = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Capitalise(words[i]);

            }
            string result = string.Join(" ", words);
            return result;


        }

    }
}