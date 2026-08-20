using System;

class Program
{
    static void Main()
    {
        bool keepRunning = true;

        // Har converter ka ek object (instance) banaya
        TemperatureConverter tempConverter = new TemperatureConverter();
        DistanceConverter distConverter = new DistanceConverter();
        CurrencyConverter currConverter = new CurrencyConverter(278.0);

        while (keepRunning)
        {
            Console.WriteLine("\n=== Unit Converter ===");
            Console.WriteLine("1. Temperature");
            Console.WriteLine("2. Distance");
            Console.WriteLine("3. Currency");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
                RunTemperatureMenu(tempConverter);
            else if (choice == "2")
                RunDistanceMenu(distConverter);
            else if (choice == "3")
                RunCurrencyMenu(currConverter);
            else if (choice == "4")
            {
                keepRunning = false;
                Console.WriteLine("Goodbye!");
            }
            else
                Console.WriteLine("Invalid choice, please try again.");
        }
    }

    static void RunTemperatureMenu(TemperatureConverter converter)
    {
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.Write("Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        double result;
        if (option == "1")
            result = converter.CelsiusToFahrenheit(value);
        else if (option == "2")
            result = converter.FahrenheitToCelsius(value);
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.WriteLine("Result: " + result);
    }

    static void RunDistanceMenu(DistanceConverter converter)
    {
        Console.WriteLine("1. Km to Miles");
        Console.WriteLine("2. Miles to Km");
        Console.Write("Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        double result;
        if (option == "1")
            result = converter.KmToMiles(value);
        else if (option == "2")
            result = converter.MilesToKm(value);
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.WriteLine("Result: " + result);
    }

    static void RunCurrencyMenu(CurrencyConverter converter)
    {
        Console.WriteLine("1. USD to PKR");
        Console.WriteLine("2. PKR to USD");
        Console.Write($"(Current rate: {converter.ExchangeRate}) Choose: ");
        string option = Console.ReadLine();

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        double result;
        if (option == "1")
            result = converter.UsdToPkr(value);
        else if (option == "2")
            result = converter.PkrToUsd(value);
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.WriteLine("Result: " + result);
    }
}

// --- Converter classes: har ek apna logic aur state khud sambhalti hai ---

class TemperatureConverter
{
    public double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}

class DistanceConverter
{
    private const double KmToMilesFactor = 0.621371;

    public double KmToMiles(double km)
    {
        return km * KmToMilesFactor;
    }

    public double MilesToKm(double miles)
    {
        return miles / KmToMilesFactor;
    }
}

class CurrencyConverter
{
    private double exchangeRate; // encapsulated state — bahar se seedha access nahi

    public double ExchangeRate
    {
        get { return exchangeRate; }
        private set { exchangeRate = value; } // sirf yeh class hi change kar sakti hai
    }

    public CurrencyConverter(double initialRate)
    {
        ExchangeRate = initialRate;
    }

    public double UsdToPkr(double usd)
    {
        return usd * ExchangeRate;
    }

    public double PkrToUsd(double pkr)
    {
        return pkr / ExchangeRate;
    }

    public void UpdateExchangeRate(double newRate)
    {
        if (newRate > 0)
            ExchangeRate = newRate;
        else
            Console.WriteLine("Exchange rate must be positive.");
    }
}