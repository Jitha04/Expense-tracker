using System;
using System.Collections.Generic;

class Expense
{
    public string Category { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {Category}: ${Amount} - {Description}";
    }
}

class Program
{
    static List<Expense> expenses = new List<Expense>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Expense Tracker ===");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. View Total Expenses");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddExpense();
                    break;
                case "2":
                    ViewExpenses();
                    break;
                case "3":
                    ViewTotalExpenses();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddExpense()
    {
        Console.Write("Enter category (e.g., Food, Transport, etc.): ");
        string category = Console.ReadLine();

        Console.Write("Enter amount: ");
        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.WriteLine("Invalid amount. Press any key to return.");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter date (YYYY-MM-DD) or press Enter for today: ");
        DateTime date;
        if (!DateTime.TryParse(Console.ReadLine(), out date))
        {
            date = DateTime.Now; // Default to today
        }

        expenses.Add(new Expense { Category = category, Amount = amount, Description = description, Date = date });
        Console.WriteLine("Expense added successfully! Press any key to continue.");
        Console.ReadKey();
    }

    static void ViewExpenses()
    {
        Console.WriteLine("\n--- Your Expenses ---");
        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses recorded.");
        }
        else
        {
            foreach (var expense in expenses)
            {
                Console.WriteLine(expense);
            }
        }
        Console.WriteLine("\nPress any key to return.");
        Console.ReadKey();
    }
    static void ViewTotalExpenses()
    {
        double total = 0;
        foreach (var expense in expenses)
        {
            total += expense.Amount;
        }
        Console.WriteLine($"\nTotal Expenses: ${total}");
        Console.WriteLine("Press any key to return.");
        Console.ReadKey();
    }
}

