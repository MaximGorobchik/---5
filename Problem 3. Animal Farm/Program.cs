using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Chicken
{
    private int age;
    private string name;

    public Chicken(int age, string name)
    {
        this.Age = age;
        this.Name = name;
    }

    public int Age
    {
        get { return age; }
        set
        {
            if(value > 15 || value < 0)
            {
                throw new ArgumentException("Age should be between 0 and 15");
            }
            this.age = value;
        }
    }
    public string Name
    {
        get { return name; }
        set
        {
            if (value == null || value == " " || value == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }
    public double ProductPerDay()
    {
        return CalculateProductPerDay();
    }
    private double CalculateProductPerDay()
    {
        switch(this.age)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return 2;
            case 4:
            case 5:
            case 6:
            case 7: 
                return 1.5;
            case 8:
            case 9:
            case 10: 
                return 1;
            default: return 0;
        }
    }


}
namespace Problem_3.Animal_Farm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                var NewChicken = new Chicken(age,name);
                Console.WriteLine($"Chicken {NewChicken.Name} (age {NewChicken.Age}) can produce {NewChicken.ProductPerDay()} eggs per day");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
