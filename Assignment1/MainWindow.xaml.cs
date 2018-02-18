using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Vehicle> vehicleCollection = new ObservableCollection<Vehicle>();
        private ObservableCollection<Vehicle> filteredvehicleCollection = new ObservableCollection<Vehicle>();

        public Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
 
            CreateVanObjects(random,20);
            CreateBikeObjects(random, 10);
            CreateCaranObjects(random,10);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sortBy = {"All","Price", "Mileage", "Make" };
            comboBoxFilter.ItemsSource = sortBy;
            comboBoxFilter.SelectedIndex = 0; //Set index to All
            listBoxVehicle.ItemsSource = vehicleCollection;
        }

        private void CreateVanObjects(Random random, int numOfObjects)
        {
            Van[] vanArray = new Van[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                vanArray[i] = new Van(Van.GetVehicleMake(random), Van.GetVehicleModel(random), (VanType)random.Next(6), random.Next(10000,30000),
                    GetRandomYear(),random.Next(300000), random.Next(10, 30));
                vehicleCollection.Add(vanArray[i]);
            }
        }
        private void CreateCaranObjects(Random random, int numOfObjects)
        {
            Car[] CarArray = new Car[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                CarArray[i] = new Car(Car.GetVehicleMake(random), Car.GetVehicleModel(random), (CarBodyType)random.Next(7), random.Next(10000, 50000),
                    GetRandomYear(),random.Next(250000), random.Next(10, 40));
                vehicleCollection.Add(CarArray[i]);
            }
        }
        private void CreateBikeObjects(Random random, int numOfObjects)
        {
            Bike[] BikeArray = new Bike[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                BikeArray[i] = new Bike(Bike.GetVehicleMake(random), Bike.GetVehicleModel(random), (BikeType)random.Next(6), random.Next(5000, 20000),
                    GetRandomYear(),random.Next(100000),random.Next(1,12));
                vehicleCollection.Add(BikeArray[i]);
            }
        }
        private int GetRandomYear()
        {
            DateTime presentYear = DateTime.Now;
            DateTime endYear = new DateTime(presentYear.Year - 10,01,01);

            return random.Next(endYear.Year,presentYear.Year);

        }

        private void listBoxVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle selectedVehicle = listBoxVehicle.SelectedItem as Vehicle;
            if (selectedVehicle != null)
            {
                textBlockInfo.Text = selectedVehicle.GetDetails();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (radioAll.IsChecked == true)
            {
                listBoxVehicle.ItemsSource = vehicleCollection;
            }
            else if (radioBikes.IsChecked == true)
            {
                filteredvehicleCollection.Clear();
                filterRadioButton("Bike");
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
            }
            else if (radioCars.IsChecked == true)
            {
                filteredvehicleCollection.Clear();
                filterRadioButton("Car");
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
            }
            else if (radioVans.IsChecked == true)
            {
                filteredvehicleCollection.Clear();
                filterRadioButton("Van");
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
            }
        }
        private void filterRadioButton(string type)
        {
            for (int i = 0; i < vehicleCollection.Count; i++)
            {
                if (vehicleCollection[i].GetType().Name.ToString() == type)
                {
                    Vehicle temp = vehicleCollection[i];
                    filteredvehicleCollection.Add(temp);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sortType = comboBoxFilter.SelectedValue.ToString();

            if (sortType == "All")
            {
                listBoxVehicle.ItemsSource = vehicleCollection;
            }
            else if (sortType == "Price")
            {
                filteredvehicleCollection.Clear();
                Array.Sort(vehicleCollection.ToArray());
                filteredvehicleCollection = vehicleCollection;

            }
            else if (sortType == "Mileage")
            {
                filteredvehicleCollection.Clear();

            }
            else if (sortType == "Make")
            {
                filteredvehicleCollection.Clear();

            }
        }
        private void sortPriceNMilage()
        {

        }
    }
}
