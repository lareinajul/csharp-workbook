using System;
					
public class Program
{
	public static void Main()   
	{		
        int myDay = 15;
        int myMonth = 10;
                
		Console.WriteLine("Please input a year");
		int myYear = Convert.ToInt32(Console.ReadLine());

        DateTime dt = new DateTime(myYear,myMonth, myDay);

        int dow = (int)dt.DayOfWeek;

        var dowName = (DaysOfTheWeekWithNumbers)dow;
        Console.WriteLine(dowName);

	}	
	enum DaysOfTheWeekWithNumbers
	{
		Monday = 1, Tuesday = 2, Wednesday = 3, Thursday = 4, Friday = 5, Saturday = 6, Sunday = 0
	}
}