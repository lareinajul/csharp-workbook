using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace WordGuess 
{
    class Program
    {
        public static string[] dictionary;
        public static string word;
        public static int wordIndex; 
        static void Main(string[] args)
        {
            Console.WriteLine("Loading words. Please be patient...");
            dictionary = File.ReadAllLines(@"C:\Users\JULIE\Documents\SACA\C#online\csharp-workbook\words_alpha.txt"); 

            //get random word from dictionary
            Random rnd = new Random();
            int r = rnd.Next(dictionary.Count() - 1); //subtract 1 because count has an index of 1 and arrays have index of 0

            word = dictionary[r]; //assign word
            wordIndex = r;

            //start game
            Game();
        }

        public static void Game()
        {
            var winDetected = false;
            bool showAnswer = false;
            List<string> guessList= new List<string>();

            while(!winDetected && !showAnswer)
            {
                Console.WriteLine("Enter a guess or enter 9 to show answer");
                string entry = Console.ReadLine().ToLower();
                
                //Display word and exit game
                if(entry == "9")
                {
                    Console.WriteLine("Word was: " + word);
                    showAnswer = true;
                }
                else //continue with game
                {

                    int entryIndex = Array.IndexOf(dictionary, entry);
                    guessList.Add(entry);

                    //word entered is winning word
                    if(entryIndex == wordIndex)
                    {
                        Console.WriteLine("You Win!");
                        winDetected = true;
                    }
                    else //word entered is not winnning word
                    {
                        //print list of guesses so far
                        int guessCount = 1;
                        foreach(var item in guessList)
                        {
                             Console.WriteLine(guessCount + ". " + item); 
                            guessCount++;                       
                        }

                        if(entryIndex > wordIndex) //entered word is lower on the list compared to winning word
                        {
                            Console.WriteLine("Word is before " + entry);
                        }
                        else // entered word is before winning word
                        {
                            Console.WriteLine("Word is after " + entry);
                        }

                        
                    }
                }
            }
        }
    }
}
