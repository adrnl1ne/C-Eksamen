namespace Supermarket
{
    public class Item
    {
        public string Code { get; set; }
        public double Price { get; set; }
           
        
        public Item(string code, double price)
        {
            Code = code;
            Price = price;
        }
    
        public override string ToString()
        {
            return $"{Code}";
        }

    }

}