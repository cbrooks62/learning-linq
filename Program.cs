/* --Restriction/Filtering Operations--*/

// Find the words in the collection that start with the letter 'L'
using System.ComponentModel.Design;
using Microsoft.VisualBasic;

List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

IEnumerable<string> LFruits =
from fruit in fruits
where fruit.StartsWith("L")
select fruit;

Console.WriteLine("-----------------------------------------");
Console.WriteLine("**Fruit that starts with the letter 'L'**");
Console.WriteLine("-----------------------------------------");
foreach (string LFruit in LFruits)
{

    Console.WriteLine(LFruit.ToString());

};

// Which of the following numbers are multiples of 4 or 6
List<int> numbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);
Console.WriteLine("");
Console.WriteLine("----------------------------------------");
Console.WriteLine("**Numbers that are multiples of 4 or 6**");
Console.WriteLine("----------------------------------------");
foreach (int fourSixMultiple in fourSixMultiples)
{
    Console.WriteLine(fourSixMultiple);
}


/* --Ordering Operations-- */

// Order these student names alphabetically, in descending order (Z to A)
List<string> names = new List<string>()
{
    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
    "Francisco", "Tre"
};

IEnumerable<string> descend = names.OrderByDescending(name => name).ToList();
Console.WriteLine("");
Console.WriteLine("------------------------------------------------------");
Console.WriteLine("**Names alphabetically, in descending order (Z to A)**");
Console.WriteLine("------------------------------------------------------");
foreach (string name in descend)
{
    Console.WriteLine(name);
}

// Build a collection of these numbers sorted in ascending order
List<int> numbers2 = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

List<int> ascend = numbers2.OrderBy(number => number).ToList();

Console.WriteLine("");
Console.WriteLine("-------------------------------------");
Console.WriteLine("**Numbers sorted in ascending order**");
Console.WriteLine("-------------------------------------");
foreach (int number in ascend)
{
    Console.WriteLine(number);
}


/* --Aggregate Operations-- */

// Output how many numbers are in this list
List<int> numbers3 = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

int count = numbers3.Count();

Console.WriteLine("");
Console.WriteLine("-------------------");
Console.WriteLine("**Number of items**");
Console.WriteLine("-------------------");

Console.WriteLine(count);

// How much money have we made?
List<double> purchases = new List<double>()
{
    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
};

double total = purchases.Sum();

Console.WriteLine("");
Console.WriteLine("-------------------");
Console.WriteLine("**Total purchases**");
Console.WriteLine("-------------------");
Console.WriteLine(total);

// What is our most expensive product?
List<double> prices = new List<double>()
{
    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
};

double mostExpensive = prices.Max();

Console.WriteLine("");
Console.WriteLine("--------------------------");
Console.WriteLine("**Most expensive Product**");
Console.WriteLine("--------------------------");
Console.WriteLine(mostExpensive);


/* --Partitioning Operations-- */

/*
    Store each number in the following List until a perfect square
    is detected.

    Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
*/
List<int> wheresSquaredo = new List<int>()
{
    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
};

List<int> notSqrt = new List<int>();
foreach (int number in wheresSquaredo)
{
    double sqrt = Math.Sqrt(number);
    if (sqrt % 1 != 0)
    {
        notSqrt.Add(number);
    }
    else
    {
        break;
    }
}

Console.WriteLine("");
Console.WriteLine("------------------------------");
Console.WriteLine("**Numbers until perfect sqrt**");
Console.WriteLine("------------------------------");
foreach (int number in notSqrt)
{
    Console.WriteLine(number);
}


/* --Using Custom Types--*/

// Build a collection of customers who are millionaires


List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

var millionaireCustomers = customers.Where(customer => customer.Balance >= 1000000);

Console.WriteLine("");
Console.WriteLine("-------------------------");
Console.WriteLine("**Millionaire Customers**");
Console.WriteLine("-------------------------");
foreach (var customer in millionaireCustomers)
{
    Console.WriteLine($"Customer: {customer.Name}, Balance: {customer.Balance}");
};


/*
    Given the same customer set, display how many millionaires per bank.
    Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

    Example Output:
    WF 2
    BOA 1
    FTB 1
    CITI 1
*/

var millionairesPerBank = millionaireCustomers.GroupBy(m => m.Bank)
                                              .Select(g => new { Bank = g.Key, Count = g.Count() });

Console.WriteLine("");
Console.WriteLine("-------------------------");
Console.WriteLine("**Millionaires per Bank**");
Console.WriteLine("-------------------------");
foreach (var item in millionairesPerBank)
{
    Console.WriteLine($"Bank: {item.Bank} Customers: {item.Count}");
}

public class Customer
{
    public string? Name { get; set; }
    public double Balance { get; set; }
    public string? Bank { get; set; }

};

