using System;
using System.Collections;
using Mission3Assignment;

class Program
{
    static void Main(string[] args)
    {
        ArrayList inventory = new ArrayList();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nFood Bank Inventory System");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Remove Food Item");
            Console.WriteLine("3. Show Inventory");
            Console.WriteLine("4. Exit");
            Console.Write("Enter an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddFoodItem(inventory);
                    break;
                case "2":
                    RemoveFoodItem(inventory);
                    break;
                case "3":
                    PrintInventory(inventory);
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddFoodItem(ArrayList inventory)
    {
        Console.WriteLine("\nEnter food name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter food category: ");
        string category = Console.ReadLine();

        int quantity;
        do
        {
            Console.WriteLine("Enter food quantity (positive number): ");
        } while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0);

        DateTime expirationDate;
        do
        {
            Console.WriteLine("Enter food expiration date: ");
        } while (!DateTime.TryParse(Console.ReadLine(), out expirationDate));

        FoodItem item = new FoodItem(name, category, quantity, expirationDate);
        inventory.Add(item);
        Console.WriteLine($"\nFood Item {name} added successfully!");
    }

    static void RemoveFoodItem(ArrayList inventory)
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("\nNo food found!");
            return;
        }

        Console.Write("Enter the name of the food item to delete: ");
        string name = Console.ReadLine();

        FoodItem itemToRemove = null;
        foreach (FoodItem item in inventory)
        {
            if (item.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
            {
                itemToRemove = item;
                break;
            }
        }

        if (itemToRemove != null)
        {
            inventory.Remove(itemToRemove);
            Console.WriteLine($"\nFood item {name} removed successfully!");
        }
        else
        {
            Console.WriteLine($"\nFood item {name} not found!");
        }
    }

    static void PrintInventory(ArrayList inventory)
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("\nNo food items in inventory.");
            return;
        }

        Console.WriteLine("\nInventory:");
        foreach (FoodItem item in inventory)
        {
            Console.WriteLine(item);
        }
    }
}   