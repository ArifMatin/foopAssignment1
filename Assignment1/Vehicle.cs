using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Assignment1

    //tired added the icon image beside each vehicle as a special feature
{
    public abstract class Vehicle 
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string Socure { get; set; } //added this 
        public int Year { get; set; }
        public string Colour { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public double EngineSize { get; set; }

        public Vehicle(string make, string model, int price, int year, int mile, double size,string des,string color,string socure,string img)
        {
            Make = make;
            Model = model;
            Price = price;
            Year = year;
            Mileage = mile;
            EngineSize = size / 10;
            Description = des;
            Colour = color;
            Socure = socure;
            ImageName = img;

        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n{3} {4}\n", Make, Model, Price, Year, Mileage);
        }

        public virtual string GetDetails()
        {
            return String.Format("Make:\t{0}\nModel:\t{1}\nPrice:\t{2}\nYear:\t{3}\nMilage:\t{4}\nDescription: {6}\nEgine:\t{5}Litre\n",
                Make, Model, Price, Year, Mileage, EngineSize,Description);
        }

        public BitmapImage GetIcon()   //this method is called from App.xmal application resources
        {
            BitmapImage x = new BitmapImage(new Uri(Socure, UriKind.Relative));

            return x;
        }
    }
}
