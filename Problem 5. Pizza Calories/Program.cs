using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Problem_5.Pizza_Calories
{
    internal class Program
    {
        static void Main()
        {
            var dough = new Dough();
            var pizza = new Pizza();
            var line = Console.ReadLine();
            if (line.Contains("Dough") || line.Contains("dough"))
            {
                var Doughinfo = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var Doughtype = Doughinfo[1];
                var Doughtech = Doughinfo[2];
                var Doughweight = double.Parse(Doughinfo[3]);
                try
                {
                    dough = new Dough(Doughtype, Doughtech, Doughweight);
                    Console.WriteLine($"{dough.CaloriesCalculator()}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                line = Console.ReadLine();
                if (line == "END" || line == "end") return;
            }
            if (line.Contains("Topping") || line.Contains("topping"))
            {
                var Topinfo = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var Toptype = Topinfo[1];
                var Topweight = double.Parse(Topinfo[2]);
                try
                {
                    var topping = new Topping(Toptype, Topweight);
                    Console.WriteLine($"{topping.CaloriesCalculator()}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                line = Console.ReadLine();
                if (line == "END" || line == "end") return;
            }

            ///////////////////////////////////////////////////
            while (!line.Equals("END"))
            {
                var lines = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (lines[0].Equals("Pizza") || lines[0].Equals("pizza"))
                {
                    var name = lines[1];
                    var toppingCount = int.Parse(lines[2]);

                    try
                    {
                        pizza = new Pizza(name,toppingCount);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (lines[0].Equals("Dough") || lines[0].Equals("dough"))
                {
                    var Doughtype = lines[1];
                    var Doughtech = lines[2];
                    var Doughweight = double.Parse(lines[3]);

                    try
                    {
                        dough = new Dough(Doughtype, Doughtech, Doughweight);
                        pizza.Dough = dough;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    var toppingName = lines[1];
                    var toppingWeight = double.Parse(lines[2]);

                    try
                    {
                        var topping = new Topping(toppingName, toppingWeight);
                        pizza.Toppings.Add(topping);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                line = Console.ReadLine();
            }

            Console.WriteLine($"{pizza.Name} – {pizza.CaloriesCalculator()} Calories.");
        }
    }
}
