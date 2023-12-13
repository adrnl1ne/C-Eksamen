using Supermarket;
using System;
using System.Collections.Generic;

// Delegate for printing receipt
public delegate void PrintReceipt(CheckOut items);

// Delegate for scanning item
public delegate Item ScanItem();

// Enum for checkout type
public enum CheckOutType
{
    Expensive,
    Cheap
}

public class Utils
{
    // Dictionary to store item prices
    public static Dictionary<string, double> PriceMap = new Dictionary<string, double>();

    // Method to generate random prices for items
    public static void GenerateRandomPrices()
    {
        Random random = new Random();

        // Loop through numbers 1 to 9
        for (int number = 1; number <= 9; number++)
        {
            // Loop through letters A to Z
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                string item = number.ToString() + letter.ToString();
                double price = random.NextDouble() * 100;

                // Modify the price for item "M" to be four times the price of item "A"
                if (letter == 'M')
                {
                    string itemA = number.ToString() + "A";
                    double priceA = PriceMap.ContainsKey(itemA) ? PriceMap[itemA] : 0;
                    price = priceA * 3;
                }

                if (letter == 'P')
                {
                    string itemP = number.ToString() + "P";
                    double pricePant = PriceMap.ContainsKey(itemP) ? PriceMap[itemP] : 0;
                    price = pricePant + 3;
                }


                PriceMap[item] = price;
            }
        }

        // Uncomment the following lines to print the generated prices
        //Console.WriteLine("Prices Generated" + PriceMap);
        /*foreach (var item in PriceMap)
        {
            Console.WriteLine($"Item: {item.Key}, Price: {item.Value}");
        }*/
    }

    

    // Method to get price for an item based on its code
    public static double GetPrice(string code)
    {
        if (PriceMap.ContainsKey(code))
        {
            return PriceMap[code];
        }
        else
        {
            return 0;
        }
    }

}
