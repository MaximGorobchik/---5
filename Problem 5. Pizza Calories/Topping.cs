using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Pizza_Calories
{
    public class Topping
    {
        private string[] ToppingType = { "Meat", "Veggies", "Cheese", "Sauce" };
        private const decimal meatmod = 1.2m;
        private const decimal veggiesmod = 0.8m;
        private const decimal cheesemod = 1.1m;
        private const decimal saucemod = 0.9m;
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (value == null || value == string.Empty || value == " ")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza");
                }
                this.type = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50]");
                }
                this.weight = value;
            }
        }
        public decimal CaloriesCalculator()
        {
            var typeValue = 0.0m;
            switch (this.type)
            {
                case "Meat":
                    typeValue = meatmod;
                    break;
                case "Veggies":
                    typeValue = veggiesmod;
                    break;
                case "Cheese":
                    typeValue = cheesemod;
                    break;
                case "Sauce":
                    typeValue = saucemod;
                    break;
                case "meat":
                    typeValue = meatmod;
                    break;
                case "veggies":
                    typeValue = veggiesmod;
                    break;
                case "cheese":
                    typeValue = cheesemod;
                    break;
                case "sauce":
                    typeValue = saucemod;
                    break;
                default: throw new ArgumentException($"Cannot place {this.type} on top of your pizza");
            }

            return 2 * typeValue * (decimal)this.Weight;
        }
    }
    }
