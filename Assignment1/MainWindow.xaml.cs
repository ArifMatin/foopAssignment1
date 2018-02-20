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
        private ObservableCollection<Vehicle> filteredvehicleCollection;
        private Vehicle[][] filterVehicle = new Vehicle[4][];
        private int selectedIndexOfRadio;

        public Random random = new Random();

        public MainWindow()
        {
            
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateVanObjects(random, 20);
            CreateBikeObjects(random, 10);
            CreateCaranObjects(random, 10);
            string[] sortBy = {"All","Price", "Mileage", "Make" };
            comboBoxFilter.ItemsSource = sortBy;
            comboBoxFilter.SelectedIndex = 0; //Set index to All
            listBoxVehicle.ItemsSource = vehicleCollection;
            radioAll.IsChecked = true;
            selectedIndexOfRadio = 0;
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
                filterVehicle[0] = vehicleCollection.ToArray();
                filteredvehicleCollection = new ObservableCollection<Vehicle>(filterVehicle[0]);
                listBoxVehicle.ItemsSource = filteredvehicleCollection;                 //all is 0
            }
            else if (radioBikes.IsChecked == true)
            {
                filterVehicle[1] =  filterRadioButton("Bike");                          //bike is 1
                filteredvehicleCollection = new ObservableCollection<Vehicle>(filterVehicle[1]);
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
                selectedIndexOfRadio = 1;
            }
            else if (radioCars.IsChecked == true)
            {
                filterVehicle[2] =  filterRadioButton("Car");                           //car is 2
                filteredvehicleCollection = new ObservableCollection<Vehicle>(filterVehicle[2]);
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
                selectedIndexOfRadio = 2;
            }
            else if (radioVans.IsChecked == true)
            {
                filterVehicle[3] =  filterRadioButton("Van");                           //van is 3
                filteredvehicleCollection = new ObservableCollection<Vehicle>(filterVehicle[3]);
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
                selectedIndexOfRadio = 3;
            }
        }
        private Vehicle[] filterRadioButton(string type)
        {
            List<Vehicle> tempArray = new List<Vehicle>();

            for (int i = 0; i < vehicleCollection.Count; i++)
            {
                if (vehicleCollection[i].GetType().Name.ToString() == type)
                {
                    Vehicle temp = vehicleCollection[i];
                    tempArray.Add(temp);
                }
            }

            return tempArray.ToArray();
        }

        private void comboBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sortType = comboBoxFilter.SelectedValue.ToString();

            if (sortType == "All")
            {
                listBoxVehicle.ItemsSource = filterVehicle[selectedIndexOfRadio];
            }
            else if (sortType == "Price")
            {
                IEnumerable<Vehicle> filterPrice = filterVehicle[selectedIndexOfRadio].OrderBy(a => a.Price);
                filterPrice.Reverse();
                listBoxVehicle.ItemsSource = filterPrice;

            }
            else if (sortType == "Mileage")
            {
                IEnumerable<Vehicle> filterMilage = filterVehicle[selectedIndexOfRadio].OrderBy(a => a.Mileage);
                filterMilage.Reverse();
                listBoxVehicle.ItemsSource = filterMilage;

            }
            else if (sortType == "Make")
            {
                IEnumerable<Vehicle> filterMkee = filterVehicle[selectedIndexOfRadio].OrderBy(a => a.Make);
                filterMkee.Reverse();
                listBoxVehicle.ItemsSource = filterMkee;

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Vehicle selectedVehicle = listBoxVehicle.SelectedItem as Vehicle;
            if (selectedVehicle != null)
            {
                int x = filteredvehicleCollection.IndexOf(selectedVehicle);
                filteredvehicleCollection.RemoveAt(x);
                textBlockInfo.Text = String.Empty;
            }
        }
    }
}
