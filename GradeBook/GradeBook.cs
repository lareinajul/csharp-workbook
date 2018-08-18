using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask the user for a list of students (put the students in a stack)


            var nameList = new List<string>();
            Dictionary<string, decimal> grades =  new Dictionary<string, decimal>();
            var response = "";
            // Prompt for another name until user types "finished"
            while (response != "finished")
            {

                Console.WriteLine("Enter student name or type finished to end input");
                //Prompt for user input
                response = Console.ReadLine();
              if(response != "finished")
                { 
                    //Put name in list
                    nameList.Add(response);
                    Console.WriteLine("Enter grades (comma separated) for " + response);
                    List<int> studGrades = new List<int>();
                    var gradeInput = Console.ReadLine().Split(",").ToList();
                    foreach(var item in gradeInput)
                    {
                        studGrades.Add(Convert.ToInt32(item));
                    }

                    var avg = studGrades.Average();
                    grades.Add(response, Convert.ToDecimal(avg));
                    //add a list of grades (dictionary of student grades).
                    //prompt for grades for student name

                    // ask user to input comma separated values for each student
                    // parse string for values by doing a split on the comma
                    // add all values to dictionary


                }
                else
                {
                   foreach (var item in grades)
                    {
                        Console.WriteLine("Name: " + item.Key + ": Grade Average:  " +  item.Value);
                    }   
                   break;
                }
               
            }
             
                       
           
           //program should output avg grade for each student.
            // Get all grades for student from dictionary and average them together
            // Print out on screen next to user name
        }
    }
}