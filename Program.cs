using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;


//Dictionary
Dictionary<string, double> magicCards = new Dictionary<string, double>();
magicCards.Add("mox pearl",3750.00);
magicCards.Add("time walk", 5001.01);
magicCards.Add("mox emerald", 5500.00);
magicCards.Add("mox ruby", 5872.95);
magicCards.Add("timetwister", 6000.99);
magicCards.Add("mox jet", 10000.99);
magicCards.Add("mox sapphire", 12486.99);
magicCards.Add("ancestral recall", 14999.95);
magicCards.Add("black lotus", 249985.99);

//foreach(KeyValuePair<string, double> card in magicCards.OrderByDescending(key => key.Value))
//{
//    Console.WriteLine(",", card.Key, card.Value);
//}

//Lists
List<string> shoppingCart = new List<string>();
List<double> total = new List<double>();

//convert high value to low dictionary
Dictionary<string, double> highToLowConvert= new Dictionary<string, double>();

//Greeting
Console.WriteLine("Welcome to Black Market Connections. \r\nThe home of the rarest Magic cards \r\nHave a look at our selection.");

//listing items
int i = 1;
foreach(KeyValuePair<string,double> kvp in magicCards.OrderByDescending(key => key.Value))
{
    Console.WriteLine(String.Format("{0,-30}{1,-15}",$"{i}) {kvp.Key}:", $"{kvp.Value}"));
    i++;
}
int cardNumber = 0;
bool runProgram = true;
//Run loop
while (runProgram)
{
    //determine purchase loop
    while (true)
    {
        Console.WriteLine("Type the name or number of the magic card you would like to purchase.");
        string card = Console.ReadLine().ToLower().Trim();
        bool containsInt = card.All(char.IsDigit);
        //contains word
        if (magicCards.ContainsKey(card))
        {
            shoppingCart.Add(card);
            highToLowConvert.Add(card, magicCards[card]);
            itemInShoppingcart(shoppingCart, magicCards);
            break;
        }
        //contains number
        else if (containsInt && (int.Parse(card) - 1) < magicCards.Count)
        {
            cardNumber = int.Parse(card) - 1;
            string itemByNumber = magicCards.ElementAt(cardNumber).Key.ToString();
            shoppingCart.Add(itemByNumber);
            highToLowConvert.Add(itemByNumber, magicCards[itemByNumber]);
            Console.WriteLine(String.Format("{0,-30}{1,-15}", itemByNumber, magicCards[itemByNumber]));
            itemInShoppingcart(shoppingCart, magicCards);
            break;
        }
        //retry
        else
        {
            Console.WriteLine("Please check spelling, spacing or that the number is available.");
        }
    }
    //exit program method
    exitProgram(ref runProgram);
}
    double max = double.MinValue;
    double min = double.MaxValue;
    string maxItem = "";
    string minItem = "";
//List items high to low   
foreach (KeyValuePair<string, double> high in highToLowConvert.OrderByDescending(key => key.Value))
{
    Console.WriteLine(String.Format("{0,-30}{1,-15}", $"{high.Key}:", $"{high.Value}"));
}
//Total    
foreach(string item in shoppingCart)
{
    total.Add(magicCards[item]);
//determine max
    if (magicCards[item] > max)
    {
        max = magicCards[item];
        maxItem = item;
    }
    //determine min
    if (magicCards[item] < min)
    {
        min = magicCards[item];
        minItem = item;
    }
}
    //checkout summary
Console.WriteLine(String.Format("{0,-30}{1,-15}", "total", total.Sum()));
Console.WriteLine($"Your most expensive item was {maxItem} which costs {max}");
Console.WriteLine($"Your least expensive item was {minItem} which costs {min}");
    


static void itemInShoppingcart(List<string> shoppingCart, Dictionary<string, double> magicCards)
    {
        foreach (string item in shoppingCart)
        {
            Console.WriteLine(String.Format("{0,-30}{1,-15}", item, magicCards[item]));
        }
    }
static void exitProgram(ref bool x)
    {
        while (true)
        {
            Console.WriteLine("Would you like to checkout?");
            string answer = Console.ReadLine().ToLower().Trim();

            if (answer.Contains('y'))
            {
                x = false;
                break;
            }
            else if (answer.Contains('n'))
            {
                x = true;
                break;
            }
            else
            {
                Console.WriteLine("Please use y/n");
            }
        }
    }
