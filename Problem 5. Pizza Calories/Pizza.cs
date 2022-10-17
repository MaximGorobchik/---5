using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private int toppings;
        private decimal calories;

        public Pizza(string name, int toppings)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
            this.ToppingCount = toppings;
        }
        public Pizza()
        {

        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null || value == " " || value == String.Empty|| value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols");
                }
                this.name = value;
            }
        }
        public int ToppingCount
       {
           get { return this.toppings; }
           set
           {
               if (value < 0 || value > 10)
               {
                   throw new ArgumentException("Number of toppings should be in range [0..10]");
               }
               this.toppings = value;
           }
       }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; set; }
        public decimal CaloriesCalculator()
        {
            return this.Dough.CaloriesCalculator() + this.Toppings.Sum(x => x.CaloriesCalculator());
        }
    }
}
