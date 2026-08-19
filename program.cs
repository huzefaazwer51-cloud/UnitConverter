using System;

class UnitConverter
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Unit Converter ===");
            Console.WriteLine("1. Temperature");
            Console.WriteLine("2. Distance");
            Console.WriteLine("3. Currency");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TemperatureMenu();
                    break;
                case "2":
                    DistanceMenu();
                    break;
                case "3":
                    CurrencyMenu();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void TemperatureMenu()
    {
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.Write("Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        double result = option switch
        {
            "1" => CelsiusToFahrenheit(value),
            "2" => FahrenheitToCelsius(value),
            _ => throw new Exception("Invalid option")
        };

        Console.WriteLine($"Result: {result}");
    }

    static double CelsiusToFahrenheit(double c) => (c * 9 / 5) + 32;
    static double FahrenheitToCelsius(double f) => (f - 32) * 5 / 9;

    static void DistanceMenu()
    {
        Console.WriteLine("1. Km to Miles");
        Console.WriteLine("2. Miles to Km");
        Console.Write("Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        double result = option switch
        {
            "1" => value * 0.621371,
            "2" => value / 0.621371,
            _ => throw new Exception("Invalid option")
        };

        Console.WriteLine($"Result: {result}");
    }

    static void CurrencyMenu()
    {
        Console.WriteLine("1. USD to PKR");
        Console.WriteLine("2. PKR to USD");
        Console.Write("Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        // fixed rate for simplicity — you can hardcode a rate you look up
        double rate = 278.0;

        double result = option switch
        {
            "1" => value * rate,
            "2" => value / rate,
            _ => throw new Exception("Invalid option")
        };

        Console.WriteLine($"Result: {result}");
    }
}
















}
