using System;

class UnitConverter
{
    // This is where the program starts running
    static void Main()
    {
        bool keepRunning = true; // we'll use this to control the loop

        // This loop keeps showing the menu until the user chooses to exit
        while (keepRunning)
        {
            // Show the menu
            Console.WriteLine("\n=== Unit Converter ===");
            Console.WriteLine("1. Temperature");
            Console.WriteLine("2. Distance");
            Console.WriteLine("3. Currency");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine(); // read what the user typed

            // Decide what to do based on their choice
            if (choice == "1")
            {
                TemperatureMenu();
            }
            else if (choice == "2")
            {
                DistanceMenu();
            }
            else if (choice == "3")
            {
                CurrencyMenu();
            }
            else if (choice == "4")
            {
                keepRunning = false; // this will stop the while loop
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }

    // Handles temperature conversions
    static void TemperatureMenu()
    {
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.Write("Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine()); // convert text input into a number

        double result = 0; // we'll store the answer here

        if (option == "1")
        {
            result = CelsiusToFahrenheit(value);
        }
        else if (option == "2")
        {
            result = FahrenheitToCelsius(value);
        }
        else
        {
            Console.WriteLine("Invalid option.");
            return; // exit this method early, nothing more to do
        }

        Console.WriteLine("Result: " + result);
    }

    // Small helper methods that do just one calculation each
    static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    // Handles distance conversions
    static void DistanceMenu()
    {
        Console.WriteLine("1. Km to Miles");
        Console.WriteLine("2. Miles to Km");
        Console.Write("Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        double result = 0;

        if (option == "1")
        {
            result = value * 0.621371; // km to miles
        }
        else if (option == "2")
        {
            result = value / 0.621371; // miles to km
        }
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.WriteLine("Result: " + result);
    }

    // Handles currency conversions
    static void CurrencyMenu()
    {
        Console.WriteLine("1. USD to PKR");
        Console.WriteLine("2. PKR to USD");
        Console.Write("Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        double exchangeRate = 278.0; // fixed rate for now, just for practice

        double result = 0;

        if (option == "1")
        {
            result = value * exchangeRate; // USD to PKR
        }
        else if (option == "2")
        {
            result = value / exchangeRate; // PKR to USD
        }
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.WriteLine("Result: " + result);
    }
}