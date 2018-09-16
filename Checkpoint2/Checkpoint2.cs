using System;
using System.Linq;
using System.Collections.Generic;

namespace Checkpoint2
{
    class Program
    {

        public static string player = "White";
        static void Main(string[] args)
        {
            Game();
        }

        //Build pieces
            public static readonly Checker whitePiece = new Checker()
            {
                Symbol = char.ConvertFromUtf32(int.Parse("25CB", System.Globalization.NumberStyles.HexNumber)),
                Color = "White"
            };
            public static readonly Checker blackPiece = new Checker()
            {
                Symbol = char.ConvertFromUtf32(int.Parse("25CF", System.Globalization.NumberStyles.HexNumber)),
                Color = "Black"
            };


        public class Checker
        {
            //attributes
            public string Symbol { get; set; }  //the actual symbol either an open or a closed dot
            public int[] Position { get; set; } //the coordinates of its place on the grid
            public string Color { get; set; } // the team name (either "white" or "black")        

        }
		
        public class Board
        {
            //attributes
            public string[][] Grid { get; set; } //the "grid" that makes up the board

            public List<Checker> Checkers { get; set; } //the collection of Checkers currently on the board

            public void CreateBoard()
            {
                //string PlaceHolder = " ";
                
                var newBoard = new string[8][];

			    //Populate row objects to grid
                for (int i = 0; i < newBoard.Length; i++)
                {
                    string[] BoardRow = new string[8];

			        //Build row object
                    for (int r = 0; r < BoardRow.Length; r++)
                    {
                       BoardRow[r] = " ";
                    }
                    
                    newBoard[i] = BoardRow;
                }

                this.Grid = newBoard;
            }

            public void GenerateCheckers(){
                this.Checkers = new List<Checker>();
               
                //fill white positions
                for (int i = 0; i < 3; i++)
                {
                    for (int r = 0; r < 8; r++)
                    {
                        var white = new Checker()
                            {
                                Symbol = char.ConvertFromUtf32(int.Parse("25CB", System.Globalization.NumberStyles.HexNumber)),
                                Color = "White"
                            };

                        if(i%2 == 0 && r%2 != 0)
                        {                        
                            white.Position = new int[] { i, r };
                            this.Checkers.Add(white);
                        }else if(i%2 != 0 && r%2 == 0) {
                            white.Position = new int[] { i, r };
                            this.Checkers.Add(white);
                        }
                        
                    }
                }

                //fill black positions
                for (int i = 5; i < 8; i++)
                {
                    for (int r = 0; r < 8; r++)
                    {
                        var black = new Checker()
                            {
                                Symbol = char.ConvertFromUtf32(int.Parse("25CF", System.Globalization.NumberStyles.HexNumber)),
                                Color = "Black"
                            };
                        if(i%2 == 0 && r%2 != 0)
                        {                        
                            black.Position = new int[] { i, r };
                            this.Checkers.Add(black);
                        }else if(i%2 != 0 && r%2 == 0) {
                            black.Position = new int[] { i, r };
                            this.Checkers.Add(black);
                        }
                    }
                }
            }


            public void DrawBoard(){
                // var boardGrid = this.Grid;
			    //print top grid numbers
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine ("  0 1 2 3 4 5 6 7");

			    //loop through board rows
                for (int i = 0; i < this.Grid.Length; i++)
                {
				    //Get board row
                    var row = this.Grid[i];

				    //get board row index 
                    var rowString = i.ToString();
				
				    //loop through each row item
                    for (int r = 0; r < row.Length; r++)
                    {
                        var itemValue = " " + row[r];

                        rowString = rowString + itemValue;
                    }

				    //print row string to console
                    Console.WriteLine(rowString);
                }
            }

            public void PlaceCheckers()
            {
                for (var i = 0; i < Checkers.Count; i++)
                {
                    int[] position = Checkers[i].Position;
                    Grid[position[0]][position[1]] = Checkers[i].Symbol;
                }
            }

            private Checker SelectChecker(int row, int column)
            {
                var position = new int[] {row, column};
                var checker = Checkers.Where(x => x.Position[0] == row && x.Position[1] == column).SingleOrDefault();
                return checker;
            }

            public void MoveChecker(int selRow, int selColumn, int row, int column)
            {
                var checker = SelectChecker(selRow, selColumn);
                
                if(checker.Color == player) //Prevent player from moving other players checkers
                {
                    if(checker != null)
                    {
                        Checkers.Remove(checker);
                        checker.Position = new int[]{row, column};    
                        Checkers.Add(checker);            
                    }
                }
                else{
                    Console.WriteLine("Don't try to move the other players checker! Turn forfeited.");
                }

            }

            public void RemoveChecker(int row, int column)
            {
                var checker = SelectChecker(row, column);
                if(checker != null)
                {
                    Checkers.Remove(checker);
                }
            }

            public bool CheckForWin()
            {

                if(player == "White")
                {
                    var blackCheckerCount = Checkers.Where(x => x.Color == "Black").Count();

                    if(blackCheckerCount == 0)
                    {
                        return true;
                    }
                }
                else{
                    var whiteCheckerCount = Checkers.Where(x => x.Color == "White").Count();

                    if(whiteCheckerCount == 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
       

        public static void Game()
        {           

            Board board = new Board();
            board.CreateBoard();
            board.GenerateCheckers();            

            bool winDetected = false;

            while(!winDetected)
            {
                board.PlaceCheckers();
                board.DrawBoard();   

                Console.WriteLine("Player " + player +"'s turn" );

                Console.WriteLine("move or remove checker?");

                Console.WriteLine("Select a checker");
                Console.WriteLine("Enter Row:");
                int selRow = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Column:");
                int selColumn = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select new checker location");
                Console.WriteLine("Enter Row:");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Column:");
                int column = Convert.ToInt32(Console.ReadLine());

                board.MoveChecker(selRow, selColumn, row, column);

                    Console.WriteLine("Remove checker? y/n");
                    var userAction = Console.ReadLine().ToLower();
                    
                    if(userAction == "y")
                    {
                        Console.WriteLine("Select checker to remove");
                        Console.WriteLine("Enter Row:");
                        row = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Column:");
                        column = Convert.ToInt32(Console.ReadLine());

                        board.RemoveChecker(row, column);
                    }

                winDetected = board.CheckForWin();
                
                if(!winDetected)
                {
                    if(player == "White")
                    {
                        player = "Black";
                    }
                    else{
                        player = "White";
                    }

                    board.CreateBoard();

                }

            }

        }
    }
}
