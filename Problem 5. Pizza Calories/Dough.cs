using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Pizza_Calories
{
    public class Dough
    {
        private string[] DoughType = { "White", "Wholegrain"};
        private string[] BakingTechnique = { "Crispy", "Chewy", "Homemade" };
        private const decimal whitemod = 1.5m;
        private const decimal wholegrainmod = 1.0m;
        private const decimal crispymod = 0.9m;
        private const decimal chewymod = 1.1m;
        private const decimal homemademod = 1.0m;
        private string doughtype;
        private string bakingtechique;
        private double weight;

        public Dough(string doughtype, string bakingtech, double weight)
        {
            this.typedough = doughtype;
            this.Bakingtechique = bakingtech;
            this.Weight = weight;
        }
        public Dough()
        {

        }
        public string typedough
        {
            get { return this.doughtype; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid type of dough");
                }
                this.doughtype = value;
            }
        }
        public string Bakingtechique
        {
            get { return this.bakingtechique; }
            set
            {
                if (String.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid baking technique");
                }
                this.bakingtechique = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1...200]");
                }
                this.weight = value;
            }
        }

        public decimal CaloriesCalculator()
        {
            var typeValue = 0.0m;
            var bakingTechValue = 0.0m;
            switch (this.doughtype)
            {
                case "White":
                    typeValue = whitemod;
                    break;
                case "Wholegrain":
                    typeValue = wholegrainmod;
                    break;
                case "white":
                    typeValue = whitemod;
                    break;
                case "wholegrain":
                    typeValue = wholegrainmod;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough");
            }
            switch (this.bakingtechique)
            {
                case "Crispy":
                    bakingTechValue = crispymod;
                    break;
                case "Chewy":
                    bakingTechValue = chewymod;
                    break;
                case "Homemade":
                    bakingTechValue = homemademod;
                    break;
                case "crispy":
                    bakingTechValue = crispymod;
                    break;
                case "chewy":
                    bakingTechValue = chewymod;
                    break;
                case "homemade":
                    bakingTechValue = homemademod;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough");
            }
            return (2 * (decimal)this.Weight) * typeValue * bakingTechValue;
        }
    }
}
