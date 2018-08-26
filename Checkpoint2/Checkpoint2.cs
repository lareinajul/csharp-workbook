using System;

namespace Checkpoint2
{

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class Checker() 
    {
        //attributes
        public string Symbol {get; set;}  //the actual symbol either an open or a closed dot
        public int[] Position {get; set;} //the coordinates of its place on the grid
        public string Color {get; set;} // the team name (either "white" or "black")

    }

    class Board()
    {
        //attributes
        public string[][] Grid {get; set;} //the "grid" that makes up the board
        public List<Checker> Checkers {get; set;} //the collection of Checkers currently on the board

        //methods
        CreateBoard(); //Creating the grid that is the board
        DrawBoard(); //View the game board
        GenerateBoard(); //Creating all the Checker instances at the beginning of the game
        SelectChecker(); //Selecting a particular checker
        RemoveChecker(); //Remove a defeated checker
        CheckForWin(); //check if all Checkers of one color have been removed
    }

    public CreateBoard()
    {

    }
    public DrawBoard() 
    {

    } 
    public GenerateBoard()
    {

    }  
    public SelectChecker()
    {

    }
    public RemoveChecker()
    {

    }
    public CheckForWin()
    {

    }
    class Game() 
    {
        //Build pieces
        var whitePiece = new Checker()
        {
            Symbol = char.ConvertFromUtf32(int.Parse("25CB", System.Globalization.NumberStyles.HexNumber)),        
            Color = "White"

        };
        var blackPiece = new Checker()
        {
            Symbol = char.ConvertFromUtf32(int.Parse("25CF", System.Globalization.NumberStyles.HexNumber)),
            Color = "Black"
        };

        
        Board board = new Board();
        //methods
        Start(whitePiece, blackPiece); //starting a game       
    }
}
