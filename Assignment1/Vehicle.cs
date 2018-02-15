using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
   class Vehicle
    {   
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public DateTime Year { get; set; }
        public string Colour { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public Vehicle(string make, string model)
        {
            Make = make;
            Model = model;

        }

        public override string ToString()
        {
            return String.Format("{0} {1}",Make,Model);
        }
    }
}
