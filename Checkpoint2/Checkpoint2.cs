using System;
using System.Linq;
using System.Collections.Generic;

namespace Checkpoint2
{
    class Program
    {
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

            //methods
            //CreateBoard(); //Creating the grid that is the board        
            //DrawBoard(); //View the game board
            //GenerateBoard(); //Creating all the Checker instances at the beginning of the game
            //SelectChecker(); //Selecting a particular checker
            //RemoveChecker(); //Remove a defeated checker
            //CheckForWin(); //check if all Checkers of one color have been removed
        }
       

        public void SelectChecker()
        {
            
        }

        public void RemoveChecker()
        {

        }

        public void CheckForWin()
        {

        }

        public bool Start(Checker white, Checker black, Board board)
        {
            return true;
        }

        public static void Game()
        {
            //Build pieces
            // var whitePiece = new Checker()
            // {
            //     Symbol = char.ConvertFromUtf32(int.Parse("25CB", System.Globalization.NumberStyles.HexNumber)),
            //     Color = "White"

            // };
            // var blackPiece = new Checker()
            // {
            //     Symbol = char.ConvertFromUtf32(int.Parse("25CF", System.Globalization.NumberStyles.HexNumber)),
            //     Color = "Black"
            // };

            Board board = new Board();
            board.CreateBoard();
            board.GenerateCheckers();
            board.PlaceCheckers();
            board.DrawBoard();    
        }
    }
}
