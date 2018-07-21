using System;
using System.Threading;
namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool alive=true;
            while (alive) 
            {
                var complete = Game();
                if (complete == true)
                {
                    Console.WriteLine("You managed to escape,would you like to play again? [y/n]");
                    string response = Console.ReadLine();
                    if(response == "y")
                    {
                        alive = true;
                    }
                    else{
                        break;
                    }
                }
                else{
                    Console.WriteLine("You died, would you like to play again? [y/n]");
                    string response = Console.ReadLine();
                    if(response == "y")
                    {
                        alive = true;
                    }
                    else{
                        break;
                    }
                }
            }

            bool Game()
            {
                bool stick = false;
                bool complete = false;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Welcome to the cavern of secrets!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                Thread.Sleep(3000);

                Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");

                Console.WriteLine("Do you take it? [y/n]: ");
                string ch1 = Console.ReadLine();
                Thread.Sleep(3000);

                if (ch1 == "y")
                {
                    Console.WriteLine("You have taken the stick!");
                    Thread.Sleep(2000);
                    stick = true;
                }
                else
                {
                    Console.WriteLine("You did not take the stick");

                }
                Console.WriteLine("As you proceed further into the cave, you see a small glowing object");

                Console.WriteLine("Do you approach the object? [y/n]:");
                string ch2 = Console.ReadLine();

                if (ch2 == "y")
                {
                    Console.WriteLine("You approach the object");
                    Thread.Sleep(2000);
                    Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                    Thread.Sleep(1000);
                    Console.WriteLine("The eye belongs to a giant spider");

                    Console.WriteLine("Do you try to fight it? [y/n]: ");
                    string ch3 = Console.ReadLine();


                    if (ch3 == "y")
                    {
                        if (stick)
                        {
                            Console.WriteLine("You only have a stick to fight with");
                            Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage");
                            Thread.Sleep(2000);

                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("                  Fighting...                   ");
                            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Thread.Sleep(2000);

                            Random random = new Random();
                            int fdmg1 = random.Next(3, 10);
                            int edmg1 = random.Next(1, 5);
                            Console.WriteLine("you hit a " + fdmg1);
                            Console.WriteLine("you hit a " + edmg1);
                            Thread.Sleep(2000);

                            if (edmg1 > fdmg1)
                            {
                                Console.WriteLine("The spider dealt more damage than you");
                                complete = false;
                                return complete;
                            }
                            else if (fdmg1 < 5)
                            {
                                Console.WriteLine("You didn't do enough damage to kill the spider,");
                                complete = true;
                                return complete;
                            }
                            else
                            {
                                Console.WriteLine("You killed the Spider!");
                                complete = true;
                                return complete;
                            }

                        }
                        else
                        {
                            Console.WriteLine("You don't have anything to fight with");
                            Thread.Sleep(2000);

                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("                  Fighting...                   ");
                            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Thread.Sleep(2000);

                            Random random = new Random();
                            int fdmg1 = random.Next(1, 8);
                            int edmg1 = random.Next(1, 5);
                            Console.WriteLine("you hit a " + fdmg1);
                            Console.WriteLine("you hit a " + edmg1);
                            Thread.Sleep(2000);

                            if (edmg1 > fdmg1)
                            {
                                Console.WriteLine("The spider dealt more damage than you");
                                complete = false;
                                return complete;
                            }
                            else if (fdmg1 < 5)
                            {
                                Console.WriteLine("You didn't do enough damage to kill the spider,");
                                complete = true;
                                return complete;
                            }
                            else
                            {
                                Console.WriteLine("You killed the Spider!");
                                complete = true;
                                return complete;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("You choose not to fight the spider");
                        Thread.Sleep(1000);
                        Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!!!");
                        complete = false;
                        return complete;

                    }
                }
                else
                {
                    Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave");
                    Thread.Sleep(1000);
                    Console.WriteLine("But something won't let you....");
                    Thread.Sleep(2000);
                    complete = false;
                    return complete;
                }
            }
        }
    }
}
