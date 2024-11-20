using System;
using System.Collections.Generic;

class ShoppingCart
{
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string itemName, int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("Error: Quantity must be positive.");
            return;
        }

        if (items.ContainsKey(itemName))
        {
            items[itemName] += quantity;
        }
        else
        {
            items[itemName] = quantity;
        }
    }

    public void RemoveItem(string itemName, int quantity)
    {
        if (!items.ContainsKey(itemName))
        {
            Console.WriteLine($"Error: {itemName} is not in the cart.");
            return;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("Error: Quantity must be positive.");
            return;
        }

        if (items[itemName] < quantity)
        {
            Console.WriteLine($"Error: Cannot remove {quantity} {itemName}(s). Only {items[itemName]} in cart.");
            return;
        }

        items[itemName] -= quantity;
        if (items[itemName] == 0)
        {
            items.Remove(itemName);
        }
    }

    public void ViewCart()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
            return;
        }

        Console.WriteLine("Items in your cart:");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item.Key}: {item.Value}");
        }
    }

    public double CalculateTotal(Dictionary<string, double> priceList)
    {
        double total = 0;
        foreach (var item in items)
        {
            if (priceList.ContainsKey(item.Key))
            {
                total += priceList[item.Key] * item.Value;
            }
            else
            {
                Console.WriteLine($"Warning: Price for {item.Key} is not available.");
                // Bug: Missing handling for items without a price.
            }
        }

        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ShoppingCart cart = new ShoppingCart();
        Dictionary<string, double> priceList = new Dictionary<string, double>
        {
            { "apple", 1.0 },
            { "banana", 0.5 },
            { "orange", 0.75 },
            { "milk", 2.5 }
        };

        Console.WriteLine("Welcome to the Shopping Cart System!");
        Console.WriteLine("Available commands: add, remove, view, total, exit");

        while (true)
        {
            Console.Write("\nEnter a command: ");
            string command = Console.ReadLine().ToLower();

            if (command == "exit")
            {
                Console.WriteLine("Exiting the shopping cart system. Goodbye!");
                break;
            }

            switch (command)
            {
                case "add":
                    Console.Write("Enter the item name: ");
                    string addItem = Console.ReadLine().ToLower();
                    Console.Write("Enter the quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int addQuantity))
                    {
                        cart.AddItem(addItem, addQuantity);
                    }
                    else
                    {
                        Console.WriteLine("Error: Quantity must be a valid integer.");
                    }
                    break;

                case "remove":
                    Console.Write("Enter the item name: ");
                    string removeItem = Console.ReadLine().ToLower();
                    Console.Write("Enter the quantity to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int removeQuantity))
                    {
                        cart.RemoveItem(removeItem, removeQuantity);
                    }
                    else
                    {
                        Console.WriteLine("Error: Quantity must be a valid integer.");
                    }
                    break;

                case "view":
                    cart.ViewCart();
                    break;

                case "total":
                    double total = cart.CalculateTotal(priceList);
                    Console.WriteLine($"The total cost of your cart is: ${total:F2}");
                    break;

                default:
                    Console.WriteLine("Error: Unknown command. Please try again.");
                    break;
            }
        }
    }
}
