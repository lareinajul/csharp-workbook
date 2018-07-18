using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {


            // your code goes here
            Console.WriteLine("Welcome to the Pig Latin Translator!\nType \"exit\" at any time to exit the program.");

            runTranslator();

            

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        static void runTranslator()
        {
            string phrase;

            // get the phrase
            Console.WriteLine("\nEnter a word or phrase:");
            phrase = Console.ReadLine().ToLower(); //convert it to lowercase

            //see if they typed 'exit'
            if (phrase == "exit")
            {
                Console.WriteLine("Goodbye!"); //If so, end the translator
                return;
            }

            // translate and diplay the phrase
            phrase = translatePhrase(phrase);
            Console.WriteLine(phrase);

            //Run repeatedly until you exit
            runTranslator();
        }

        static string translatePhrase(string phrase)
        {
            string[] words;
            string newPhrase;

            //cut the phrase into individual words
            words = phrase.Split(" ");

            //create new phrase
            newPhrase = "";
            foreach (string word in words) //translate each word individually and add to newPhrase
            {
                newPhrase += TranslateWord(word) + " ";
            }

            return newPhrase;
        }
        
        static string TranslateWord(string word)
        {
            int vowelIndex;
            char lastChar = Convert.ToChar(word.Substring(word.Length - 1));
            char punctuation = '\0';

            //check for punctuation at the end of a word
            if (Char.IsPunctuation(lastChar))
            {
                word = word.Substring(0, word.Length - 1);
                punctuation = lastChar;
            }

            // find index of the first vowel
            vowelIndex = findVowelIndex(word);

            if (vowelIndex == 0) //if the first letter is a vowel (or there is no vowel),
            {
                word += "y"; //add a y at the end
            }
            else if (vowelIndex > 0) // if there is a vowel but it's not the first letter,
            {   
                word = word.Substring(vowelIndex) + word.Substring(0, vowelIndex); //flip the word
            }

            // add "ay" and any punctuation
            word += "ay";
            if (punctuation != '\0')
            {
                word += punctuation;
            }


            return word;
        }

        static int findVowelIndex(string word)
        {
            int index = -1;
            int indexY = -1;

            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            // Look for a 'y'
            indexY = word.IndexOf('y');

            // Look for any other vowel
            index = word.IndexOfAny(vowels);

            // See if there's a 'y' that is not the first char and that comes before the first non-'y' vowel
            if (indexY > 0 && (indexY < index || index == -1))
            {
                index = indexY; // if so, use the y as the first vowel
            }

            return index;
        }
    }
}