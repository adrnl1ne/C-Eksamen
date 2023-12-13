using Supermarket;

// Create a new instance of the Scanner class
Scanner scanner = new Scanner();

// Create a new instance of the CheckOut class and set the Scan property to the Scan method of the scanner object
CheckOut checkOut = new CheckOut()
{
    Scan = scanner.Scan,
};

// Prompt the user to select a checkout type
CheckOutType t = UI.ReceiptMenu();

// Based on the selected checkout type, assign the Print property of the checkOut object to the corresponding print method
switch (t)
{
    case CheckOutType.Expensive:
        checkOut.Print = UI.PrintReceiptExpensive;
        break;
    case CheckOutType.Cheap:
        checkOut.Print = UI.PrintReceiptCheap;
        break;
    default:
        break;
}

// Generate random prices for the items
Utils.GenerateRandomPrices();

bool isRunning = true;
while (isRunning)
{
    // Display the main menu and get the user's choice
    isRunning = UI.DisplayMenu();

    if (isRunning)
    {
        // If the user chooses to continue, add an item to the checkout
        checkOut.addItem();
    }
    else
    {
        // If the user chooses to exit, print the receipt
        checkOut.PrintReceipt();
    }
}
