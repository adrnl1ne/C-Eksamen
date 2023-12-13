# C-Eksamen

This is my exam assignment for C#



Introduction:
    The program is made to act as a grocery scanner
    Here there will be items type from A - Z, with each having category types from 1 - 9
    Each item will have a random generated price in the beginning of the program, where the item type "M" is a package containing 3 of "A",
    and the item type "P" has an additional pant added to it's price.

User Interaction:
    All inputs from the user is managed through a scanner, and I use delegates to handle my events.
    When starting the program the user will be asked if they want to use the cheap or expensive reciept.
    The cheap reciept shows every item scanned, in the order they are scanned, and then prints the sum.
    The expensive reciept will use LINQ to sort the scanned items, showing them in categories and showing the sum of the amount of different items, that has been scanned.
    For all my classes I use Object initializers.

Runtime:
    The program will keep running in a "while" loop, until the user decides to go to the checkout.

Overall:
    The program is fully functioning without experiencing any bugs, there is a few outcommented calls to test functionality.
    The state of the project is so that additional logic easily can be applied.

