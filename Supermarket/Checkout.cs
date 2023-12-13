namespace Supermarket
{
    // Class representing the checkout process
    public class CheckOut
    {
        // Delegate for scanning an item
        public ScanItem Scan;

        // Delegate for printing the receipt
        public PrintReceipt Print;

        // Total price of all scanned items
        public double TotalPrice;

        public double Discount;

        // List to store scanned items
        public List<Item> scannedItems = new List<Item>();

        public double GetDiscount(Item scannedItem)
        {
            // Check if the scanned item is already in the list
            int itemCount = scannedItems.Count(item => item.Code == scannedItem.Code);

            // If there are 3 of the same item
            if (itemCount % 4 == 0)
            {
                string item = scannedItem.Code;
                Discount = Utils.PriceMap.ContainsKey(item) ? Utils.PriceMap[item] : 0;
                Console.WriteLine("Discount applied");
                return Discount;
            }
            else
            {
                return 0;
            }
        }

        // Method to add an item to the checkout process
        public async Task addItem()
        {
            // Scan an item
            Item scannedItem = Scan();
            
            // Add the scanned item to the list
            scannedItems.Add(scannedItem);

            // Update the total price
            TotalPrice += scannedItem.Price;

            // Aplly Discount
            TotalPrice -= GetDiscount(scannedItem);

            // Delay for 500 milliseconds
            await Task.Delay(500);
        }

        // Method to print the receipt
        public void PrintReceipt()
        {
            // Call the Print delegate to print the receipt
            Print(this);
        }
    }
}
