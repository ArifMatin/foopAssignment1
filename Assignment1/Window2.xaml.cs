using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Vehicle vehicle { get; set; }
        public Window2()
        {
            InitializeComponent();

        }
        public void ShowDetails()
        {
            GetVehicleType();

            string name = vehicle.GetType().Name;
            txtMake.Text = vehicle.Make;
            txtModel.Text = vehicle.Model;
            txtPrice.Text = vehicle.Price.ToString();
            txtYear.Text = vehicle.Year.ToString();
            txtMileage.Text = vehicle.Mileage.ToString();
        }
        public void GetVehicleType()
        {

            if (vehicle.GetType().Name == "Car")
            {
                vehicle = vehicle as Car;
                comboBoxType.ItemsSource = Enum.GetValues(typeof(CarBodyType));
            }
            else if (vehicle.GetType().Name == "Van")
            {
                vehicle = vehicle as Van;
                comboBoxType.ItemsSource = Enum.GetValues(typeof(VanType));
            }
            else if (vehicle.GetType().Name == "Bike")
            {
                vehicle = vehicle as Bike;
                comboBoxType.ItemsSource = Enum.GetValues(typeof(BikeType));
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string make = txtMake.Text;
        }
    }
}
