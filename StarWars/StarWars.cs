using System;
using System.Linq;

namespace StarWars	
{
    
        public class Program
        {
	        public static void Main()
	        {
		         Person leia = new Person("Leia", "Organa", "Rebel");
		         Person darth = new Person("Darth", "Vader", "Imperial");
		         Person han = new Person ("Han", "Solo", "Rebel");
		         Person luke = new Person ("Luke", "Skywalker","Imperial");
		         Person emporer = new Person ("Emporer", "Palpatine", "Rebel");
		         Ship falcon = new Ship("Rebel", "Smuggling", 2);
		         Ship tie = new Ship("Tie", "Fighter", 1);
		         Ship wing = new Ship("X-Wing", "Fighter", 3);
		         Station rebel = new Station("Rebel Space Station","Rebel", 5);
				 Station death = new Station("Death Star", "Imperial", 3);

	        }
        }

        public class Person
        {
	        private string firstName;
	        private string lastName;
	        private string alliance;
	        public Person(string firstName, string lastName, string alliance)
	        {
	        	this.firstName = firstName;
	        	this.lastName = lastName;
	        	this.alliance = alliance;
	        }

	        public string FullName
	        {
	        	get
	        	{
	        		return this.firstName + " " + this.lastName;
	        	}

	        	set
	        	{
	        		string[] names = value.Split(' ');
	        		this.firstName = names[0];
	        		this.lastName = names[1];
	        	}
	        }
        }

        public class Ship
        {
           private Person[] passengers;
           public Ship(string alliance, string type, int size)
           {
           	    this.Type = type;
           	    this.Alliance = alliance;
           	    this.passengers = new Person[size];
           }
       
           public string Type {	get; set; }
       
           public string Alliance{get;set;}
       
           public string Passengers
           {
           	    get
           	    {
           		    foreach (var person in passengers)
           		    {
           			    Console.WriteLine(String.Format("{0}", person.FullName));
           		    }
       
           		    return "That's Everybody!";
           	    }
           }
       
           public void EnterShip(Person person, int seat)
           {
           	    this.passengers[seat] = person;
           }
       
           public void ExitShip(int seat)
           {
           	    this.passengers[seat] = null;
           }
        }

        public class Station
        {
            private Ships[] ships;
            public Station(string name, string alliance, int size)
            {
                this.name = name;
                this.Alliance = alliance;
                this.Ships = new ships[size];
            }

            public string name { get; set; }

            public string Alliance { get; set; }

            public string Ships
            {
                get
                {
                    foreach (var ship in ships)
                    {
                        Console.WriteLine(String.Format("{0}", ship.name));
                    }

                    return "That's Everybody!";
                }
            }

            public void EnterStation(Ship ship, int dock)
            {
                this.ships[dock] = ship;
            }

            public void ExitStation(int dock)
            {
                this.ships[dock] = null;
            }

            public string Roster
            {
                get {
                    var peopleList = new List<Person>();

                    Console.WriteLine("Ships:  ");
                    foreach (var item in Ships)
                    {
                        peopleList.Add(item.Passengers);
                        Console.WriteLine(item.name);
                    }

                    Console.WriteLine("Persons:  ")
                    foreach(var item in people)
                    {
                        Console.WriteLine(item.name);
                    }                   

                }
            }
        }
    }
}
