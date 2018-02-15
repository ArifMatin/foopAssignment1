using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public enum VanType { CombiVan,Dropside, PanelVan, Pickup,Tripper,Unlisted };
    class Van : Vehicle
    {
        public static Random random = new Random();
        public static int vanMakeIndex;

        public VanType BodyType { get; set; }

        public Van(string model, string make, VanType type):base(model, make)
        {
            BodyType = type;
        }

        public override string ToString()
        {
            return String.Format(base.ToString() + " " + BodyType);
        }

        public static string GetVehicleModel()
        {
            string[][] vanModelArray = new string[3][];

            vanModelArray[1] = new string[] { "", "Focus", "Mondeo ", "Taurus", "Mustang", "C-Max" }; // fords models
            vanModelArray[2] = new string[] { "Golf", "Passat", "Jetta", "Polo", "Bora", "GTI", "T-Roc" }; //vw
            vanModelArray[0] = new string[] { "A1", "A2", "S3", "A4", "A5", "A6", "Q3", "Q7" }; // Audi

            int arrayLength = vanModelArray.Length;

            return vanModelArray[vanMakeIndex][random.Next(0, arrayLength - 1)];
        }
        public static string GetVehicleMake()               //this method gets 
        {
            string[] vanMakeArray = { "Audi", "Ford", "Volkswagen" };
            int arrayLength = vanMakeArray.Length;
            vanMakeIndex = random.Next(0, arrayLength - 1);

            return vanMakeArray[vanMakeIndex];
        }
    }
}
