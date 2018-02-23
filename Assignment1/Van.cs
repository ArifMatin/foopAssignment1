using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public enum VanType { CombiVan,Dropside, PanelVan, Pickup,Tripper,Unlisted };

    public enum WheelBase { Short, Medium, Long, Unlisted};

    class Van : Vehicle
    {
        public static int vanMakeIndex;

        public VanType BodyType { get; set; }

        public WheelBase Wheelbase { get; set; }

        public Van(string model, string make, VanType type,int price,int year,int mile,double size, WheelBase wheel,string des):base(model, make, price,year,mile,size,des)
        {
            BodyType = type;
            Wheelbase = wheel;
        }

        public override string ToString()
        {
            return String.Format(base.ToString() + " " + BodyType);
        }

        public static string GetVehicleModel(Random random)
        {
            string[][] vanModelArray = new string[3][];

            vanModelArray[1] = new string[] { "Sprinter", "Viano", "Vito ", "V-Class", "Metis Cargo", "Metris Passenger" };
            vanModelArray[2] = new string[] { "Transit Connect", "Transit Custom", "Transit", "E250", "E150", "E-350 Super Duty" }; 
            vanModelArray[0] = new string[] { "Caddy", "Transporter", "Crafter", "California", "Shuttle", "Caddy Life", "Transporter Dropside", "Caravelle" }; 

            int arrayLength = vanModelArray[vanMakeIndex].Length;

            return vanModelArray[vanMakeIndex][random.Next(0, arrayLength - 1)];
        }
        public static string GetVehicleMake(Random random)               //this method gets 
        {
            string[] vanMakeArray = { "Mercedes", "Ford", "Volkswagen" };
            int arrayLength = vanMakeArray.Length;
            vanMakeIndex = random.Next(0, arrayLength - 1);

            return vanMakeArray[vanMakeIndex];
        }
        public override string GetDetails()
        {
            return String.Format(base.GetDetails() +"Type:\t{0}\n",this.GetType().Name);
        }
    }
}
