using System;
using System.Collections.Generic;

namespace Deli_Counter_menu
{
    class Program
    {
        static bool KeepGoing()
        {
            while (true)
            {
                Console.Write("\nContinue? (y/n): ");
                string response = Console.ReadLine();
                response = response.ToLower();

                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response == "n" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter y or n.");
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Deli Counter Menu");
            Dictionary<string, double> items = new Dictionary<string, double>();
            items["apple"] = 0.99;
            items["banana"] = 0.59;
            items["fig"] = 1.59;
            items["kiwi"] = 2.19;
            
            Console.WriteLine("\nItem\t\t\t\tPrice");
            Console.WriteLine("========================================");

            foreach (var pair in items)
            {
                Console.WriteLine($"\n{pair.Key}\t\t\t\t${pair.Value}");
            }
            do
            {
                Console.WriteLine("\nEnter \"A\" for adding a new item.");
                Console.WriteLine("Enter \"R\" for removing an item.");
                Console.WriteLine("Enter \"C\" for changing an item.");
                Console.WriteLine("Enter \"Q\" to quit.");

                string choice = Console.ReadLine();
                choice = choice.ToUpper();

                while (choice != "A" && choice != "R" && choice != "C" && choice != "Q")
                {
                    Console.WriteLine("\nPlease enter \"A\" or \"R\" or \"C\" or \"Q\' ");
                    choice = Console.ReadLine();
                    choice = choice.ToUpper();
                }


                if (choice == "A")
                {
                    Console.Write("\nPlease enter the item name: ");
                    string itemName = Console.ReadLine();
                    itemName = itemName.ToLower();
                   bool itemExists = items.ContainsKey(itemName);

                    while (itemExists)
                    {
                        Console.Write($"\n{itemName} already exists. Please enter some other item name: ");
                        itemName = Console.ReadLine();
                        itemName = itemName.ToLower();
                        itemExists = items.ContainsKey(itemName);
                    }
                    Console.Write("\nPlease enter item price: ");
                    double itemPrice = double.Parse(Console.ReadLine());


                    items[itemName] = itemPrice;

                }
                else if (choice == "R")
                {
                    Console.Write("\nWhich item you want to remove?:");
                    string itemRem = Console.ReadLine();
                    itemRem = itemRem.ToLower();
                    items.Remove(itemRem);

                }
                else if (choice == "C")
                {
                    Console.Write("\nEnter the item name: ");
                    string itemName = Console.ReadLine();
                    itemName = itemName.ToLower();

                    Console.WriteLine($"\nCurrent price of {itemName} is ${items[itemName]}");
                    Console.Write($"\nEnter new price of {itemName}: ");
                    double newPrice = double.Parse(Console.ReadLine());
                    items[itemName] = newPrice;

                }
                else if (choice == "Q")
                {
                    Console.WriteLine("\nThank you!");
                }
                foreach (var pair in items)
                {
                    Console.WriteLine($"\n{pair.Key}\t\t${pair.Value}");
                }

            } while (KeepGoing() == true);


            

        }
    }
}
