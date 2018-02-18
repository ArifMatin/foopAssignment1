using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public enum CarBodyType { Convertible, Hatchback, Coupe, Estate, MPV, SUV, Saloon, Unlisted }

    class Car : Vehicle
    {
        public static int vehicleMakeIndex;

        public CarBodyType BodyType { get; set; }

        public Car(string model, string make, CarBodyType type, int price,int year,int mile,double size):base(model, make, price,year,mile,size)
        {
            BodyType = type;
        }

        public override string ToString()
        {
            return String.Format(base.ToString() + " " + BodyType);
        }

        public static string GetVehicleModel(Random random)
        {
            string[][] vehicleModelArray = new string[3][];

            vehicleModelArray[1] = new string[] { "Fiesta", "Focus", "Mondeo Fusion", "Taurus", "Mustang", "C-Max" }; // fords models
            vehicleModelArray[2] = new string[] { "Golf", "Passat", "Jetta", "Polo", "Bora", "GTI", "T-Roc" }; //vw
            vehicleModelArray[0] = new string[] { "A1", "A2", "S3", "A4", "A5", "A6", "Q3", "Q7" }; // Audi

            int arrayLength = vehicleModelArray[vehicleMakeIndex].Length;

            return vehicleModelArray[vehicleMakeIndex][random.Next(0, arrayLength - 1)];
        }
        public static string GetVehicleMake(Random random)               //this method gets 
        {
            string[] vehicleMakeArray = { "Audi", "Ford", "Volkswagen" };
            int arrayLength = vehicleMakeArray.Length;
            vehicleMakeIndex = random.Next(0, arrayLength - 1);

            return vehicleMakeArray[vehicleMakeIndex];
        }
        public override string GetDetails()
        {
            return String.Format(base.GetDetails() + "Type:\t{0}\n", this.GetType().Name);
        }
    }
}
