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
        private Car tempcar;
        private Bike tempbike;
        private Van tempvan;

        public Window2()
        {
            InitializeComponent();

        }
        public void ShowDetails()
        {
            labelAddVehicle.Visibility = Visibility.Hidden;
            labelEdit.Visibility = Visibility.Visible;

            GetVehicleType();

            txtMake.Text = vehicle.Make;
            txtModel.Text = vehicle.Model;
            txtPrice.Text = vehicle.Price.ToString();
            txtYear.Text = vehicle.Year.ToString();
            txtMileage.Text = vehicle.Mileage.ToString();
            txtDescription.Text = vehicle.Description;
        }
        private void GetVehicleType()
        {

            if (vehicle.GetType().Name == "Car")
            {
                tempcar = (Car)vehicle;
                comboBoxType.ItemsSource = Enum.GetValues(typeof(CarBodyType));
                comboBoxType.SelectedIndex = (int)tempcar.BodyType;
            }
            else if (vehicle.GetType().Name == "Van")
            {
                tempvan = (Van)vehicle;
                comboBoxType.ItemsSource = Enum.GetValues(typeof(VanType));
                comboBoxType.SelectedIndex = (int)tempvan.BodyType;
            }
            else if (vehicle.GetType().Name == "Bike")
            {
                tempbike = (Bike)vehicle;
                comboBoxType.ItemsSource = Enum.GetValues(typeof(BikeType));
                comboBoxType.SelectedIndex = (int)tempbike.BodyType;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (labelEdit.Visibility == Visibility.Visible)
            {
                vehicle.Make = txtMake.Text;                //make method to show add details
                vehicle.Model = txtModel.Text;
                vehicle.Mileage = Convert.ToInt32(txtMileage.Text);
                vehicle.Price = Convert.ToInt32(txtPrice.Text);
                vehicle.Year = Convert.ToInt32(txtYear.Text);
                vehicle.Description = txtDescription.Text;
            }
            else if (labelAddVehicle.Visibility == Visibility.Visible)
            {
                //code
            }
           
            //bodytype and wheelbase.
            this.Close();
        }
        private void ReadInDeatils()
        {
            string make = txtMake.Text;
            string model = txtModel.Text;
            int mileage = Convert.ToInt32(txtMileage.Text);
            int price = Convert.ToInt32(txtPrice.Text);
            int year = Convert.ToInt32(txtYear.Text);
            string description = txtDescription.Text;
        }
        public void fhy()
        {
            labelEdit.Visibility = Visibility.Hidden;
            labelAddVehicle.Visibility = Visibility.Visible;
            //combo vehicle type then cretate new type vehicle, run getypye method to display enum
        }

        private void comboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int x = comboBoxType.SelectedIndex;
            tempcar.BodyType = (CarBodyType)x;

        }
    }
}
