using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class Person
{
    private string name;
    private int money;
    private List<Product> backpack;

    public Person(string name, int money)
    {
        this.Name = name;
        this.Money = money;
        this.backpack = new List<Product>();
    }
    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == null || value == " " || value == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }
    public int Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
               throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }
    public void Buy(Product product)
    {
        if (this.money < product.Price)
        {
            throw new ArgumentException($"{this.Name} can't afford {product.Name}");
        }
        this.backpack.Add(product);
        this.money -= product.Price;
    }
    public IList<Product> GetProducts()
    {
        return this.backpack;
    }
}

public class Product
{
    private string name;
    private int price;

    public Product(string name, int price)
    {
        this.name = name;
        this.price = price;
    }
    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == null || value == " " || value == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }
    public int Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            this.price = value;
        }
    }

}

namespace Problem_4.Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var Persons = new List<Person>();
                var Products = new List<Product>();
                var ppls = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var products = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var p in ppls)
                {
                    var personInfo = p.Split('=');
                    var person = new Person(personInfo[0], int.Parse(personInfo[1]));
                    Persons.Add(person);
                }
                foreach (var p in products)
                {
                    var productInfo = p.Split('=');
                    var product = new Product(productInfo[0], int.Parse(productInfo[1]));
                    Products.Add(product);
                }
                string end;
                while ((end = Console.ReadLine()) != "END")
                {
                    var endInfo = end.Split(' ');
                    var buyerName = endInfo[0];
                    var productName = endInfo[1];

                    var buyer = Persons.FirstOrDefault(b => b.Name == buyerName);
                    var productToBuy = Products.FirstOrDefault(bp => bp.Name == productName);
                    try
                    {
                        buyer.Buy(productToBuy);
                        Console.WriteLine($"{buyerName} bought {productName}");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                foreach (var p in Persons)
                {
                    var bought = p.GetProducts();
                    var result = bought.Any() ? string.Join(", ", bought.Select(pq => pq.Name).ToList()) : "Nothing bought";
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
