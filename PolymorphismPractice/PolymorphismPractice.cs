using System;
using System.Collections.Generic;

namespace PolymorphismPractice
{
    class Program
    {
        public static void Main(string[] args)
        {
            //make an instance of a vehicle
            //make an instance of a sedan
            //make an instance of a truck
            Vehicle veh = new Vehicle();
            Vehicle myMazda = new Sedan();
            Vehicle LisaPrius = new Sedan();
            Vehicle jasonsTruck = new Truck();

            Console.WriteLine(jasonsTruck.dump());

            list <Vehicle> ListOfVehicle = new List<Vehicle>();
            ListOfVehicle.Add(veh);
            ListOfVehicle.Add(myMazda);
            ListOfVehicle.Add(LisaPrius);
            ListOfVehicle.Add(jasonsTruck);

            Console.WriteLine("MyMazda:    " +myMazda.honk());
            Console.WriteLine("LisaPrius:     "+LisaPrius.honk());
            Console.WriteLine("jasonsTruck:  "+jasonsTruck.honk());

            foreach (Vehicle v in ListOfVehicle){
                    if (v is truck){
                        Truck theTruck = (Truck) v;
                        Console.WriteLine(theTruck.dump());
                
                    }   else {
                {
                    Console.WriteLine("is not a truck");
                }
                                    
            }
 
        }
    }
// make a method that is called honk for all of these 3 classes.
// but the methods should all return different Strings;
// trunk: BIG HONK
// sedan: beep beep
// vehicle: honk honk

public abstract class Vehicle
{
    public abstract string honk();
}

public class Sedan:Vehicle
{
    public override String Honk()
    {
        return "BIG HONL";
    }
    public String dump()
    {
        return "Dumping stuff!";
    }
}