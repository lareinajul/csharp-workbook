using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
namespace TodoList
{
//Text based interface for the user
    class Program
    {
        private static ItemDAO myDatabase;
        static void Main(string[] args)
        {
            myDatabase = new ItemDAO();
            MainMenuLoop();
        }
         static void MainMenuLoop()
        {
            myDatabase.DisplayList(2);
             while (true)
            {
                UserCommands(out bool exitCondition);
                 if (exitCondition) { break; }
            }
        }
         /* * * *
         * Switch/case tree for directing user input into functions
         * 1  : Mark an item as completed
         * 2  : Show completed items
         * 3  : Show incomplete items
         * 4  : Show all items
         * 5  : Add new Item to list
         * 6  : Remove an Item from list by ID
         * 7  : Remove all completed items
         * 8  : exit
         * 9  : clear
         * 10 : HELP
         * * * */
        static void UserCommands(out bool exitCondition)
        {
            switch (GetUserInput())
            {
                case "showcomplete":
                case "complete":
                    myDatabase.DisplayList(1);
                    break;
                 case "showincomplete":
                case "incomplete":
                    myDatabase.DisplayList(0);
                    break;
                 case "showall":
                case "all":
                    myDatabase.DisplayList(2);
                    break;
                 case "mark":
                case "markitem":
                    MarkItem();
                    break;
                 case "add":
                case "additem":
                    AddItem();
                    break;
                 case "remove":
                case "removebyid":
                    RemoveById();
                    break;
                 case "clean":
                case "removecompleted":
                    RemoveByCompleted();
                    break;
                 case "exit":
                case "qqq":
                    exitCondition = true;
                    return;
                 case "clear":
                    Console.Clear();
                    break;
                 case "help":
                    Help();
                    break;
            }
            exitCondition = false;
        }
         static void RemoveByCompleted()
        {
            System.Console.WriteLine("You're about to remove all of your completed tasks.");
             byte failsafe = 0;
             while (true)
            {
                switch (failsafe)
                {
                    case 0:
                        System.Console.WriteLine("Are you sure about this?");
                        if (Confirmation()) { failsafe++; } else { return; }
                        break;
                     case 1:
                        System.Console.WriteLine("Are you REALLY sure?");
                        if (Confirmation()) { failsafe++; } else { return; }
                        break;
                     case 2:
                        System.Console.WriteLine("Are you REALLY REALLY REALLY sure?");
                        if (Confirmation()) { failsafe++; } else { return; }
                        break;
                     default:
                        System.Console.WriteLine("ok, now deleting all completed tasks.");
                        myDatabase.RemoveByCompleted();
                        return;
                }
            }
        }
        
        //returns a boolean of "true" if a string of yes is given. Else returns false.
        static bool Confirmation()
        {
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "yes" || input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Interacts with database object to remove an item w ith the specified ID
        static void RemoveById()
        {
            Console.WriteLine("Please insert the ID of the item you would like to remove.");
            try
            {
                myDatabase.RemoveById(ExtractNumber(Console.ReadLine()));
            }
            catch
            {
                return;
            }
        }
        //Takes in a string input, and returns a string with all the numbers of that input
        static int ExtractNumber(string input)
        {
            return Int32.Parse(new string(input.Where(c => Char.IsDigit(c)).ToArray()));
        }
        //Marks an item in the list as completed
        static void MarkItem()
        {
            Console.WriteLine("Insert the ID of the item you would like to mark as completed");
            int nums = ExtractNumber(Console.ReadLine());
             myDatabase.MarkComplete(nums);
         }
        //Submits an item to ItemDAO to then be processed and added to the Database
        static void AddItem()
        {
            Console.WriteLine("Insert a description for the task you wish to track");
            string stringInput = Console.ReadLine();
             Console.WriteLine("How many days from now should your task be completed?");
            int numInput = ExtractNumber(Console.ReadLine());
             myDatabase.AddItem(stringInput, numInput);
        }
       //help menu for user
        static void Help()
        {
            Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine("    Command    | Function");
            System.Console.WriteLine("---------------|--------------------------------------");
            System.Console.WriteLine("Mark Item      | Marks an item in the list as completed");
            System.Console.WriteLine("Show Complete  | Shows all completed items in list");
            System.Console.WriteLine("Show Incomplete| Shows all incomplete items in list");
            System.Console.WriteLine("Show All       | Shows all items in the list");
            System.Console.WriteLine("Add Item       | Add a new item to your To Do list");
            System.Console.WriteLine("Remove By Id   | Removes an item associated with the specified unique ID");
            System.Console.WriteLine("Clean          | Removes all completed items");
                System.Console.WriteLine("Exit           | Leave the program :(");
            System.Console.WriteLine();
        }
       //sets what the user types into the console to all lower case, removes all spaces, then returns that as a string
                 static string GetUserInput()
        {
            return Console.ReadLine().ToLower().Replace(" ", String.Empty);
        }
    }
       //Hold information of items in ToDo list. superfluous
    class TodoItem
    {
        public int ID { get; set; }
        public string Desc { get; set; }
        public bool Completed { get; set; }
         
       //For use when user is creating a new row
        
        public TodoItem(int id, string desc)
        {
            this.ID = id;
            this.Desc = desc;
            this.Completed = false;
        }
       //For use when pulling items from database
        
        public TodoItem(int id, string desc, bool completed)
        {
            this.ID = id;
            this.Desc = desc;
            this.Completed = completed;
        }
    }
       // Handles interfacing between C# scripts and database file
    class ItemDAO
    {
        private SqliteConnection _dbConnection;
        private SqliteConnectionStringBuilder _dbString;
         static readonly int tableWidth = 99;
         public ItemDAO()
        {
            _dbString = new SqliteConnectionStringBuilder("DataSource=./TodoDB.db");
            _dbConnection = new SqliteConnection(_dbString.ConnectionString);
            _dbConnection.Open();
             CreateTable();
        }
       //Generates objects to reflect the state of the database. defunct
       // public void SyncTableToObjects()
       // {
       //     using (SqliteCommand command = new SqliteCommand("SELECT * FROM To_Do_List;", _dbConnection))
       //     {
       //         using (SqliteDataReader reader = command.ExecuteReader())
       //         {
       //             while (reader.Read())
       //             {
       //                 int id = reader.GetInt32(0);
       //                 string desc = reader.GetString(1);
       //                 bool completed = reader.GetBoolean(3);
       //                 TodoItem thisRow = new TodoItem(id, desc, completed);
       //                 // ItemList.Add(thisRow);
       //             }
       //         }
       //     }
       // }
       //Syncs the state of the database to reflect TodoItem objects
       // public void SyncObjectsToTable()
       // {
       // }
       //PrintLine, PrintRow, and AlignCentre are adapted from https://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c
         public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
         static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
             foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
             Console.WriteLine(row);
        }
         static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
             if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
         public void DisplayList(byte key)
        {
            try
            {
                string cmdString = null;
                switch (key)
                {
                    case 0:
                        cmdString = "SELECT * FROM To_Do_List WHERE completed = 0;"; // 0 shows where completed = false
                        break;
                    case 1:
                        cmdString = "SELECT * FROM To_Do_List WHERE completed = 1;"; // 1 shows where completed = true
                        break;
                    default:
                        cmdString = "SELECT * FROM To_Do_List;";                     // anything else shows both 0 and 1
                        break;
                }
                using (SqliteCommand command = new SqliteCommand(cmdString, _dbConnection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        Console.Clear();
                        string[] headerColumns = { "ID", "Description", "Due Date", "Status" };
                        PrintRow(headerColumns);
                        PrintLine();
                         while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string desc = reader.GetString(1);
                            string date = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                            string completed = reader.GetInt32(3) == 1 ? "Completed" : "Incomplete";
                             string[] columns = { id.ToString(), desc, date, completed };
                             PrintRow(columns);
                        }
                    }
                }
                Console.WriteLine("\nType help for a list of options\n");
            }
            catch
            {
                Console.WriteLine("oof");
                return;
            }
        }
         public void MarkComplete(int id)
        {
            string cmdString = $"UPDATE To_Do_List SET completed = 1 WHERE id = {id};";
            ExecuteNonQuery(cmdString);
            DisplayList(2);
        }
         public void AddItem(string description, int dateDiff)
        {
            string cmdString = $@"  INSERT INTO To_Do_List (
                                        description,
                                        due_day,
                                        completed
                                    ) 
                                    VALUES (
                                        '{description}',
                                        date('now', +'{dateDiff} day'),
                                        '{0}'
                                    );";
            ExecuteNonQuery(cmdString);
            DisplayList(2);
        }
         private void ExecuteNonQuery(string cmdString)
        {
            try
            {
                using (SqliteCommand command = new SqliteCommand(cmdString, _dbConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Something went wrong");
                System.Console.WriteLine(e.Message);
            }
        }
         public void RemoveById(int id)
        {
            ExecuteNonQuery($"DELETE FROM To_Do_List WHERE id = {id};");
            DisplayList(2);
        }
       //Removes all completed entries
        public void RemoveByCompleted()
        {
            ExecuteNonQuery("DELETE FROM To_Do_List WHERE completed = 1;");
            DisplayList(2);
        }
       //Executes an SQlite command that will create the To_Do table if it does not exist
           public void CreateTable()
        {
            string cmdString = @"CREATE TABLE IF NOT EXISTS To_Do_List (
                                    id INTEGER PRIMARY KEY, 
                                    description VARCHAR(255), 
                                    due_day DATE, 
                                    completed INTEGER NOT NULL
                                    );";
            using (SqliteCommand command = new SqliteCommand(cmdString, _dbConnection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}