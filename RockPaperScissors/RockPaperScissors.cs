using System;

public class Program
{
    public static void Main()
    {
        string secretCode = "green";
        bool play = true;
        while(play)
        {
            RPS();
            Console.WriteLine();
            Console.WriteLine("wantto play again?");
            var response = Console.ReadLine();
            if(response == "y")
            {
                play = true;
            }
            else{
                break;
            }

        }

        void RPS()
        {
            Console.WriteLine(">>>>Rock, Paper, Scissors<<<<<");

            string hand1 = "";
            bool hand1Valid = false;
            //////
            while (!hand1Valid)
            {
                Console.Write("Enter hand 1 (rock, paper or scissors): ");
                hand1 = Console.ReadLine().ToLower();

                hand1Valid = CheckString(hand1);
            }

            if (hand1 == secretCode)
            {
                Console.Write("hand1 wins!");
            }
            else 
            { 
                Console.Clear();
                Console.WriteLine(">>>>Rock, Paper, Scissors<<<<<");

                string hand2 = "";
                bool hand2Valid = false;
                while (!hand2Valid)
                {
                    Console.Write("Enter hand 2 (rock, paper or scissors): ");
                    hand2 = Console.ReadLine().ToLower();

                    hand2Valid = CheckString(hand2);
                }

                if (hand2 == secretCode)
                {
                    Console.WriteLine("hand2 wins!");
                }
                else
                {
                    Console.WriteLine(CompareHands(hand1, hand2));
                    Console.ReadLine();
                }
            }
            
            
        }
    }
    
    public static bool CheckString(string enteredValue)
    {
        bool result = false;
        // if Rock Paper Scissors return true
        // else tell user invalid entry

        if (enteredValue == "rock" || enteredValue == "scissors" || enteredValue == "paper" || enteredValue == "green")
        {
            result = true;
        }
        else
        {
            Console.WriteLine(enteredValue + " is an invalid entry, please try again!!");
}


        return result;
    }

    public static string CompareHands(string hand1, string hand2)
    {
        string message = "";
        bool tie = false;
        tie = (hand1 == hand2) ? true : false;

        if (tie) message = "It's a tie!";

        switch (hand1)
        {
            case "rock":
                if (hand2 == "scissors") message = "Rock beats scissors, Hand one wins!";
                else message = "Paper beats rock, Hand two wins!";
                break;
            case "paper":
                if (hand2 == "rock") message = "Paper beats rock, Hand one wins!";
                else message = "Scissors beats paper, Hand two wins!";
                break;
            case "scissors":
                if (hand2 == "paper") message = "Scissors beats paper, Hand one wins!";
                else message = "Rock beats scissors, Hand two wins!";
                break;
        }

        return message;
    }
}