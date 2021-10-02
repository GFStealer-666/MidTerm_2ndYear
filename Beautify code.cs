using System;
using System.Collections.Generic;

namespace BeautifyCode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FlowerStore flowerStore = new FlowerStore();
                        
            DoWhileLoop(flowerStore);
        }

        static void DoWhileLoop(FlowerStore flowerStore)
        {
            string decide = "y";
            string selectFlower;
            
            PrintHeader(1);

            PrintForEachLoop(flowerStore);

            do
            {
                Console.Write("Choose number to buy flower : ");
                
                selectFlower = Console.ReadLine();

                SwitchCase(flowerStore, selectFlower);                

                PrintExit();

                decide = Console.ReadLine();

                PrintDecide(decide, flowerStore);

            }
            while (decide != "exit");
        }
        static void SwitchCase(FlowerStore flowerStore , string selectFlower)
        {
            switch (selectFlower)
            {

                case "1":
                    flowerStore.addToCart(flowerStore.flowerList[0]);
                    Console.WriteLine("Added " + flowerStore.flowerList[0]);
                    break;
                case "2":
                    flowerStore.addToCart(flowerStore.flowerList[1]);
                    Console.WriteLine("Added " + flowerStore.flowerList[1]);
                    break;
                default:
                    Console.WriteLine("Not Added to cart. found select number of flower");
                    break;
            }
        }

        static void PrintHeader(int header)
        {
            if(header == 1)
            {
                Console.WriteLine("Welcome to the Flower store Online Shopping");
                Console.WriteLine("-------------------------------------------");
            }
        }

        static void PrintForEachLoop(FlowerStore flowerStore)
        {
            foreach (string i in flowerStore.flowerList)
            {
                Console.Write((flowerStore.flowerList.IndexOf(i) + 1) + " ");
                Console.WriteLine(i);
            }
        }

        static void PrintDecide(string decide , FlowerStore flowerStore)
        {
            if (decide == "exit")
            {
                Console.Write("Current my cart");
                flowerStore.showCart();
            }
        }
        

        static void PrintExit()
        {
            Console.WriteLine(" ");
            Console.WriteLine("You can stop adding the flower by typing Exit ");
            Console.WriteLine("If you wish to continue press any button except spacebar");

            Console.ReadLine(); 
        }
    }
    class FlowerStore
    {
        public List<string> flowerList = new List<string>();
        List<string> cart = new List<string>();
        public FlowerStore()
        {
            flowerList.Add("Rose");

            flowerList.Add("Lotus");
        }
        public void addToCart(string name)
        {
            cart.Add(name);
        }

        public void showCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                Console.WriteLine("My Cart :");
                foreach (string i in cart)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
