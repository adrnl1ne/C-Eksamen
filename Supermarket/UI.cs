using System;
using System.Linq;

namespace Supermarket
{
    public class UI
    {
        // Displays the receipt menu and returns the selected checkout type
        public static CheckOutType ReceiptMenu()
        {
            Console.WriteLine("Receipt Menu:");
            Console.WriteLine("1. Print Receipt (Expensive)");
            Console.WriteLine("2. Print Receipt (Cheap)");

            string input = Console.ReadLine();

            if (input == "1")
            {
                return CheckOutType.Expensive;
            }
            else
            {
                return CheckOutType.Cheap;
            }
        }

        // Displays the main menu and returns true if "Add Item" is selected, false otherwise
        public static bool DisplayMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Exit");

            string input = Console.ReadLine();

            if (input == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Prints the receipt in an expensive format
        public static void PrintReceiptExpensive(CheckOut checkOut)
        {
            // Sorts the scanned items by code
            var itemSorted = from item in checkOut.scannedItems
                             orderby item.Code
                             select item;

            // Finds unique items and groups them by the first character of their code
            var groupedItems = itemSorted.Select(i => i.Code).Distinct().GroupBy(i => i[0]);

            Console.WriteLine("Receipt (Expensive Format):");
            foreach (var group in groupedItems)
            {
                Console.WriteLine($"Group: {group.Key}");
                Console.WriteLine($"ITEM: NUM...PRICE");
                Console.WriteLine($"-----------------");
                foreach (var code in group)
                {
                    uint numOfItems = 0;
                    double totalPrice = 0;

                    // Calculates the number of items and total price for each code
                    foreach (var item in itemSorted)
                    {
                        if (item.Code == code)
                        {
                            numOfItems++;
                            totalPrice += item.Price;
                        }
                    }
                    Console.WriteLine($"{code}: {numOfItems}...{totalPrice}");
                }
            }
            Console.WriteLine($"-----------------");
            Console.WriteLine($"Discount: {checkOut.Discount}");
            Console.WriteLine($"Total Price: {checkOut.TotalPrice}");

        }

        // Prints the receipt in a cheap format
        public static void PrintReceiptCheap(CheckOut checkOut)
        {
            Console.WriteLine("Receipt (Cheap Format):");
            foreach (Item item in checkOut.scannedItems)
            {
                Console.WriteLine($"{item} - Price: {Utils.GetPrice(item.Code)}");
            }
            Console.WriteLine($"-----------------");
            Console.WriteLine($"Discount: {checkOut.Discount}");
            Console.WriteLine($"Total Price: {checkOut.TotalPrice}");



        }

        // Prompts the user to enter a code and returns the input
        public static string userInput()
        {
            Console.WriteLine("Enter Code:");
            string input = Console.ReadLine();
            return input;
        }

    }
}