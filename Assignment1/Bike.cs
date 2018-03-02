using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public enum BikeType { Scooter, Trail, Bike, Sports, Commuter, Tourer};

    class Bike : Vehicle
    {
        public static int bikeMakeIndex;

        public BikeType BodyType { get; set; }

        public Bike (string model, string make, BikeType type, int price,int year,int mile,double size,string des,
            string color,string socure, string img):base(model, make,price,year,mile,size,des,color,socure,img)
        {
            BodyType = type;
        }

        public override string ToString()
        {
            return String.Format(base.ToString() + " " + BodyType);
        }

        public static string GetVehicleModel(Random random)               //this method gets the bike model
        {
            string[][] BikeModelArray = new string[3][];

            BikeModelArray[0] = new string[] { "Street 750", "Street 500", "Iron 883", "SuperLow", "Fat Boy", "Night Rod" };
            BikeModelArray[1] = new string[] { "Navi", "Dream Neo Commuter", "Dio Scooter", "CBR 1000RR", "CB 1000R", "CB Unicorn 150", "Aviator Scooter" }; 
            BikeModelArray[2] = new string[] { "YZF R15", "FZ S V", "YZF R15", "FZ V", "YZF-R15 S", "FZ25", " Fascino", "YZF R3" }; 

            int arrayLength = BikeModelArray[bikeMakeIndex].Length;

            return BikeModelArray[bikeMakeIndex][random.Next(0, arrayLength - 1)];
        }

        public static string GetVehicleMake(Random random)               //this method gets the bike make
        {
            string[] BikeMakeArray = { "Harley-Davidson", "Honda", "Yamaha" };
            int arrayLength = BikeMakeArray.Length;
            bikeMakeIndex = random.Next(0, arrayLength - 1);

            return BikeMakeArray[bikeMakeIndex];
        }
        public override string GetDetails()
        {
            return String.Format(base.GetDetails() + "Type:\t{0}\n", this.GetType().Name);
        }
    }
}
