using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCompany = new Company("Rainforest");

            var austinWarehouse = new Warehouse("Austin Warehouse", 5);
            var houstonWarehouse = new Warehouse("Houston Warehouse", 15);
            var sanantonioWarehouse = new Warehouse("San Antonio Warehouse", 12);

            myCompany.Warehouses = new List<Warehouse>()
            {
                austinWarehouse, 
                houstonWarehouse, 
                sanantonioWarehouse
            };

            var austinContainer01 = new Container(5, "Austin-01");
            var austinContainer02 = new Container(5, "Austin-02");
            var austinContainer03 = new Container(5, "Austin-03");

            austinWarehouse.Containers = new List<Container>()
            {
                austinContainer01,
                austinContainer02,
                austinContainer03
            };
             var houstonContainer01 = new Container(5, "houston-01");
            var houstonContainer02 = new Container(5, "houston-02");
            var houstonContainer03 = new Container(5, "houston-03");

            houstonWarehouse.Containers = new List<Container>()
            {
                houstonContainer01,
                houstonContainer02,
                houstonContainer03
            };
            
            var sanantonioContainer01 = new Container(5, "San Antonio-01");
            var sanantonioContainer02 = new Container(5, "San Antonio-02");
            var sanantonioContainer03 = new Container(5, "San Antonio-03");

            sanantonioWarehouse.Containers = new List<Container>()
            {
                sanantonioContainer01,
                sanantonioContainer02,
                sanantonioContainer03
            };


            var carrots = new Item("carrots", 1.25);
            var bananas = new Item("bananas", .45);
            var apples = new Item("apples", .99);

            foreach(var item in austinWarehouse.Containers)
            {
                item.Items = new List<Item>()
                {
                    carrots,
                    bananas,
                    apples
                };          
            }

            foreach(var item in sanantonioWarehouse.Containers)
            {
                item.Items = new List<Item>(){
                    bananas,
                    apples
                };
            }
            foreach(var item in houstonWarehouse.Containers)
            {
                item.Items = new List<Item>(){
                    bananas,
                    carrots
                };
            }

            var result = myCompany.Manifest;
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Item(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
    public class Container
    {
        public int Size { get; set; }
        public string Id { get; set; }
        public List<Item> Items { get; set; }
        public Container(int size, string id)
        {
            this.Size = size;
            this.Id = id;
            this.Items = new List<Item>(size);
        }

    }
    public class Warehouse
    {
        public string Location { get; set; }
        public int Size { get; set; }
        public List<Container> Containers { get; set; }
        public Warehouse(string location, int size)
        {
            this.Location = location;
            this.Size = size;
            this.Containers = new List<Container>(size);

        }
    }
    public class Company
    {
        public string Name { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public Company(string name)
        {
            this.Name = name;
        }

        public string Manifest {
            get {
                Console.WriteLine(this.Name);
                foreach(var warehouse in this.Warehouses)
                {
                    Console.WriteLine(warehouse.Location);

                    foreach(var container in warehouse.Containers)
                    {
                        Console.WriteLine(container.Id);

                        foreach(var product in container.Items)
                        {
                            Console.WriteLine(product.Name);
                        }
                    }

                }

                return "";
            }
        }

    }

}
