using System;

class FactorialSumCalculator
{
    static int Factorial(int n)
    {
        // Bug: Missing decrement in the recursive call, leading to infinite recursion.
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * Factorial(n);
        }
    }

    static int CalculateFactorialSum(int limit)
    {
        if (limit < 1)
        {
            throw new ArgumentException("Limit must be a positive integer greater than or equal to 1");
        }

        int factorialSum = 0;
        for (int i = 1; i <= limit; i++)
        {
            Console.WriteLine($"Calculating factorial for {i}");
            factorialSum += Factorial(i);
        }
        return factorialSum;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Factorial Sum Calculator!");
        Console.WriteLine("This program calculates the sum of all factorials from 1 to your chosen number.");

        while (true)
        {
            Console.Write("Enter a positive integer (or type 'exit' to quit): ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }

            try
            {
                int number = int.Parse(userInput);
                if (number < 1)
                {
                    Console.WriteLine("Please enter a positive integer greater than or equal to 1.");
                    continue;
                }

                int result = CalculateFactorialSum(number);
                Console.WriteLine($"The sum of factorials from 1 to {number} is: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid integer.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
