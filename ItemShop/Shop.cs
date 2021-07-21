using System;
using System.Collections.Generic;
using System.Text;

namespace ItemShop
{
    public class Shop
    {
        private decimal OrderTotal;

        public Shop()
        {
            OrderTotal = 0m;
        }

        public void Run()
        {
            // Runs all the shop logic here
            DisplayIntro();
            SellItem("Chipped Sword", 10.5m);
            DisplayOrderTotal();
            SellItem("Rusty Mallet", 15.5m);
            DisplayOrderTotal();
            DisplayOutro();
        }

        private void DisplayIntro()
        {
            Console.Title = "Item Shop";
            Console.WriteLine(@"+-----------+
| Item Shop |
+-----------+");
            Console.WriteLine($"\nWelcome to the {Console.Title}!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void SellItem(string itemName, decimal itemCost)
        {
            //Console.Clear();
            Console.Write($"\nWould you like to buy a {itemName} for {itemCost:C2}? (yes/no) : ");
            string answer = Console.ReadLine().ToLower().Trim();

            if (answer.StartsWith("y"))
            {
                try
                {
                    Console.Write($"How many {itemName}'s would you like? : ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    decimal total = itemCost * quantity;
                    OrderTotal += total;

                    if (quantity >= 1)
                    {
                        Console.WriteLine($"You would like {quantity} {itemName}(s)!");
                        Console.ReadLine();
                    }
                    
                    Console.WriteLine($"Your purchase for {quantity} {itemName}(s) has been made at the cost of {total:C2}!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a positive integer!");
                    Console.WriteLine("Press enter to try again...");
                    Console.ReadKey();
                    SellItem(itemName, itemCost);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Please an appropriate integer!");
                    Console.WriteLine("Press enter to try again...");
                    Console.ReadKey();
                    SellItem(itemName, itemCost);
                }
            }

            else
            {
                Console.WriteLine("OK, as you wish!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void DisplayOrderTotal()
        {
            Console.WriteLine($">>> Your current order total is {OrderTotal:C2}");
        }

        private void DisplayOutro()
        {
            Console.WriteLine("\nThank you for shopping!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
