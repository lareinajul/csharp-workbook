using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            PlayGame();
            // this command is so your program does not close automatically.
        }

        public static void PlayGame()
        {
            int score1 = 0;
            int score2 = 0; 
            bool playing = true; //stays true until you type "exit"
            int round = 0; //tracks what round you're on.
            

            Console.WriteLine("Let's Play Rock Paper Scissors!");
            System.Threading.Thread.Sleep(1000);

            //name the players.
            Console.WriteLine("What is your name?");
            string humanName = Console.ReadLine();
            Console.WriteLine("\nHello, {0}!\n", humanName);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("What would you like to name your opponent?");
            string compName = Console.ReadLine();

            Console.WriteLine("Okay, Let's play! Type EXIT at any time to quit. Type carefully as an invalid inmput will result in computer winning!");
            System.Threading.Thread.Sleep(1000);
            
            //Game loop
            while (playing)
            {
                round += 1;

                //get human player's choice.
                Console.WriteLine("\nRound {0}\nChoose your hand: \"rock\", \"paper\" or \"scissors\":", round);
                string hand1 = Console.ReadLine().ToLower();

                //see if Exit.
                if (hand1 == "exit" || hand1 == "quit") {
                    playing = false;
                    return;
                }

                //choose a random number from 1-3 for the computer.
                Random rndX = new Random();
                int compChoice = rndX.Next(1,3);

                //determine the computer's hand based on our random number.
                string hand2 = null;
                switch (compChoice)
                {
                    case 1:
                        hand2 = "rock";
                        break;
                    case 2:
                        hand2 = "paper";
                        break;
                    case 3:
                        hand2 = "scissors";
                        break;
                }
                //Tell us what computer chose.
                Console.WriteLine("\n{0} chose {1}!\n", compName, hand2);
                System.Threading.Thread.Sleep(1000);


                //declare winner.
                int winner = CompareHands(hand1, hand2);

                switch (winner)
                {
                    case 0: //tie
                        Console.WriteLine("It's a tie! No points awarded this round.");
                        break;
                    case 1: //human wins
                        Console.WriteLine("You win!");
                        score1 += 1;
                        break;
                    default: //computer wins
                        Console.WriteLine("{0} wins!", compName);
                        score2 += 1;
                        break;
                }
                System.Threading.Thread.Sleep(1000);

                //display score.
                Console.WriteLine("\nScoreboard:\n{0}: {1}\n{2}: {3}", humanName, score1, compName, score2);
                System.Threading.Thread.Sleep(1000);
            }
        }
        
        public static int CompareHands(string hand1, string hand2)
        {
            // Returns winner as an integer.
            
            if (hand1 == hand2)
            {
                return 0; //0 = tie
            }

            if (hand1 == "rock")
            {
                if (hand2 == "scissors")
                {
                    return 1;
                }
                //If we reach here, computer chose paper.
                return 2;
            }

            if (hand1 == "scissors")
            {
                if (hand2 == "paper")
                {
                    return 1;
                }
                //If we reach here, computer chose rock.
                return 2;
            }

            if (hand1 == "paper")
            {
                if (hand2 == "rock")
                {
                    return 1;
                }
                //If we reach here, computer chose scissors.
                return 2;
            }

            //If we reach here, human must have typed something other than rock, scissors or paper.
            Console.WriteLine(hand1 + " is not a valid choice!");
            System.Threading.Thread.Sleep(1000);
            return 2; // Computer wins
        }
    }
}