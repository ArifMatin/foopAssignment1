using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public abstract class Vehicle 
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public int Year { get; set; }
        public string Colour { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public double EngineSize { get; set; }

        public Vehicle(string make, string model, int price, int year, int mile, double size)
        {
            Make = make;
            Model = model;
            Price = price;
            Year = year;
            Mileage = mile;
            EngineSize = size / 10;

        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n{3} {4}\n", Make, Model, Price, Year, Mileage);
        }

        public virtual string GetDetails()
        {
            return String.Format("Make:\t{0}\nModel:\t{1}\nPrice:\t{2}\nYear:\t{3}\nMilage:\t{4}\nEgine:\t{5}Litre\n",
                Make, Model, Price, Year, Mileage, EngineSize);
        }
    }
}
