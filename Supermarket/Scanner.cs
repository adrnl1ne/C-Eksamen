namespace Supermarket
{
    // Scanner class for scanning items
    public class Scanner
    {
        // Scan method to scan an item
        public Item Scan()
        {
            // Get user input for item code and convert it to uppercase
            string code = UI.userInput().ToUpper();

            // Create a new Item object with the scanned code and price
            Item scannedItem = new Item(code: code, price: Utils.GetPrice(code));

            // Return the scanned item
            return scannedItem;
        }
    }
}