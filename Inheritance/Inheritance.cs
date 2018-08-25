using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mammals bear = new Mammals();
            bear.IsVertebrate = true;
            bear.IsWarmblooded = true;
                        
            Mammals tiger = new Mammals();
            Mammals whale = new Mammals();

            Birds ostrich = new Birds();
            Birds peacock = new Birds();
            Birds eagle = new Birds();

            Fish salmon = new Fish();
            Fish goldfish = new Fish();
            Fish guppy = new Fish();

            Reptiles turtle =  new Reptiles();
            Reptiles crocodile = new Reptiles();
            Reptiles snake = new Reptiles();

            Amphibians frog = new Amphibians();
            Amphibians toad = new Amphibians();
            Amphibians newt = new Amphibians();

            With3PairsOfLegs ant = new With3PairsOfLegs();
            With3PairsOfLegs cockroach = new With3PairsOfLegs();
            With3PairsOfLegs ladybug = new With3PairsOfLegs();

            WithMoreThan3PairsOfLegs scorpion = new WithMoreThan3PairsOfLegs();
            WithMoreThan3PairsOfLegs spider = new WithMoreThan3PairsOfLegs();
            WithMoreThan3PairsOfLegs millipede = new WithMoreThan3PairsOfLegs();

            WormLike earthworm = new WormLike();
            WormLike leech = new WormLike();

            NotWormLike flukeworm = new NotWormLike();
            NotWormLike tapeworm = new NotWormLike();

        }             
    } 
    class  Vertebrates
    {
        public bool HasNotochord {get;set;}
        public bool HasDorsalHollowNerveChord {get;set;}

    } 
    class WarmBlooded : Vertebrates
    {
        public bool AreEndothermic {get; set;}
    }
    class Mammals : WarmBlooded
    {
        public bool HaveHairOrFur {get; set;}
        public bool AreBornAlive {get; set;}
    }
    class Birds: WarmBlooded
    {
        
    }
    class ColdBlooded : Vertebrates
    {
        
    class Fish : ColdBlooded
    {
        
    }
    class Reptiles : ColdBlooded
    {
        
    }
    class Amphibians : ColdBlooded
    {
        
    }
    class Invertebrates
    {
        
    }  
    class WithJointedLegs : Invertebrates
    {
        
    }
    class With3PairsOfLegs : WithJointedLegs
    {
       
    }
    class WithMoreThan3PairsOfLegs : WithJointedLegs
    {
        
    }
    class WithoutLegs : Invertebrates
    {

    }
    class WormLike : WithoutLegs
    {

    }
    class NotWormLike : WithoutLegs
    {

    }

}
