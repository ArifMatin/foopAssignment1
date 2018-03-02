using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        public ObservableCollection<Vehicle> vehicleCollection = new ObservableCollection<Vehicle>();
        public ObservableCollection<Vehicle> filteredvehicleCollection;
        public Vehicle[][] filterVehicle = new Vehicle[4][];
        public Dictionary<string, string> colourList = new Dictionary<string, string>();

        public int selectedIndexOfRadio;

        public Random random = new Random();

        public MainWindow()
        {

            InitializeComponent();
            //image icons displayed
            imgCar.Source = new BitmapImage(new Uri("/images/car-xxl.png", UriKind.Relative));
            imgAll.Source = new BitmapImage(new Uri("/images/all1.png", UriKind.Relative));
            imgBike.Source = new BitmapImage(new Uri("/images/bike.png", UriKind.Relative));
            imgVan.Source = new BitmapImage(new Uri("/images/van1.png", UriKind.Relative));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetColourList();
            //vehicles created
            CreateVanObjects(random, 10);
            CreateBikeObjects(random, 10);
            CreateCaranObjects(random, 10);
            string[] sortBy = { "All", "Price", "Mileage", "Make" };

            listBoxVehicle.ItemsSource = vehicleCollection;
            //combo and radio checked and set to 0
            radioAll.IsChecked = true;
            selectedIndexOfRadio = 0;
            comboBoxFilter.ItemsSource = sortBy;
            comboBoxFilter.SelectedIndex = 0; //Set index to All
        }

        private void CreateVanObjects(Random random, int numOfObjects)
        {
            Van[] vanArray = new Van[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                vanArray[i] = new Van(Van.GetVehicleMake(random), Van.GetVehicleModel(random), (VanType)random.Next(6), random.Next(10000, 30000),
                    GetRandomYear(), random.Next(300000), random.Next(10, 30), (WheelBase)random.Next(4), "Nice vehicle", GetRandomColour(), "/images/all1.png", "vanV.jpg");
                vehicleCollection.Add(vanArray[i]);
            }
        }
        private void CreateCaranObjects(Random random, int numOfObjects)
        {
            Car[] CarArray = new Car[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                CarArray[i] = new Car(Car.GetVehicleMake(random), Car.GetVehicleModel(random), (CarBodyType)random.Next(7), random.Next(10000, 50000),
                    GetRandomYear(), random.Next(250000), random.Next(10, 40), "Nice vehicle", GetRandomColour(), "/images/all1.png", "carV.png");
                vehicleCollection.Add(CarArray[i]);
            }
        }
        private void CreateBikeObjects(Random random, int numOfObjects)
        {
            Bike[] BikeArray = new Bike[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                BikeArray[i] = new Bike(Bike.GetVehicleMake(random), Bike.GetVehicleModel(random), (BikeType)random.Next(6), random.Next(5000, 20000),
                    GetRandomYear(), random.Next(100000), random.Next(1, 12), "Nice vehicle", GetRandomColour(), "/images/all1.png", "bikeV.jpeg");
                vehicleCollection.Add(BikeArray[i]);
            }
        }
        private int GetRandomYear()
        {
            DateTime presentYear = DateTime.Now;
            DateTime endYear = new DateTime(presentYear.Year - 10, 01, 01);

            return random.Next(endYear.Year, presentYear.Year);

        }
        private void GetColourList()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (StreamReader r = new StreamReader("../../colour.json"))
            {
                string json = r.ReadToEnd();
                colourList = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            }
        }
        public string GetRandomColour()
        {
            int x = colourList.Count();
            random.Next(x);
            string randomKey = colourList.Keys.ToArray()[(int)random.Next(0, x - 1)];
            return randomKey;
        }

        private void listBoxVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle selectedVehicle = listBoxVehicle.SelectedItem as Vehicle;
            if (selectedVehicle != null)
            {
                textBlockInfo.Text = selectedVehicle.GetDetails();
                DisplayImage(selectedVehicle);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (radioAll.IsChecked == true)                                                 //checks which radio is checked
            {
                filterVehicle[0] = vehicleCollection.ToArray();                                     //stores it in an jaggered array
                filteredvehicleCollection = new ObservableCollection<Vehicle>(filterVehicle[0]);    //displays that as an ObservableCollection 
                listBoxVehicle.ItemsSource = filteredvehicleCollection;                 //all is 0
                selectedIndexOfRadio = 0;
            }
            else if (radioBikes.IsChecked == true)
            {
                filterVehicle[1] = filterRadioButton("Bike");                          //bike is 1
                filteredvehicleCollection = new ObservableCollection<Vehicle>(filterVehicle[1]);
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
                selectedIndexOfRadio = 1;                                                   //this is used for comboxselection
            }
            else if (radioCars.IsChecked == true)
            {
                filterVehicle[2] = filterRadioButton("Car");                           //car is 2
                filteredvehicleCollection = new ObservableCollection<Vehicle>(filterVehicle[2]);
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
                selectedIndexOfRadio = 2;
            }
            else if (radioVans.IsChecked == true)
            {
                filterVehicle[3] = filterRadioButton("Van");                           //van is 3
                filteredvehicleCollection = new ObservableCollection<Vehicle>(filterVehicle[3]);
                listBoxVehicle.ItemsSource = filteredvehicleCollection;
                selectedIndexOfRadio = 3;
            }
        }
        private Vehicle[] filterRadioButton(string type) // send value down and comnpares the values n sends an array bk
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
            string sortType = comboBoxFilter.SelectedValue.ToString();                          //gets value of sortType

            if (sortType == "All")
            {
                listBoxVehicle.ItemsSource = filterVehicle[selectedIndexOfRadio];
            }
            else if (sortType == "Price")
            {
                IEnumerable<Vehicle> filterPrice = filterVehicle[selectedIndexOfRadio].OrderBy(a => a.Price);           //sorts by the order type
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
                int x = vehicleCollection.IndexOf(selectedVehicle); // this removes from collection of vehicles
                vehicleCollection.RemoveAt(x);
                textBlockInfo.Text = String.Empty;
                imageVehicle.Source = null;
                RadioButton_Checked(sender, e);  //this call the radio changed method which updates the ObservableCollection and the view.
            }
        }

        private void btnEdit3_Click(object sender, RoutedEventArgs e)
        {
            Vehicle selectedVehicle = listBoxVehicle.SelectedItem as Vehicle;
            if (selectedVehicle == null)
            {
                selectedVehicle = vehicleCollection[0];
            }
            Window2 edit = new Window2();                                               // create new window and set onwer
            edit.Owner = this;
            edit.vehicle = selectedVehicle;
            edit.ShowDetails(); //enter class from here

            edit.ShowDialog();

            DisplayImage(selectedVehicle);
            RadioButton_Checked(sender, e); // call this method again to sort the list of vehicles
            textBlockInfo.Text = selectedVehicle.GetDetails();

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Window2 addVehicloe = new Window2();
            addVehicloe.Owner = this;

            addVehicloe.NewVehicle();  //enters class from here
            addVehicloe.ShowDialog();

            RadioButton_Checked(sender, e);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            //write to file
            using (StreamWriter sw = new StreamWriter(@"../../vehicleFile.json"))
            {
                string json = JsonConvert.SerializeObject(vehicleCollection, settings);
                sw.Write(json);
            }

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (StreamReader r = new StreamReader(@"../../vehicleFile.json"))
            {

                string json = r.ReadToEnd();
                ObservableCollection<Vehicle> items = JsonConvert.DeserializeObject<ObservableCollection<Vehicle>>(json, settings);

                for (int i = 0; i < items.Count; i++)
                {
                    vehicleCollection.Add(items[i]);
                }

            }
            RadioButton_Checked(sender, e);

        }

        private void DisplayImage(Vehicle v)
        {
            string filename = v.ImageName;

            if (filename != null)
            {
               imageVehicle.Source = new BitmapImage(new Uri(GetImageDirectory() + filename, UriKind.Absolute));
            }
        }
        private string GetImageDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo parent = Directory.GetParent(currentDir);
            DirectoryInfo grandParent = Directory.GetParent(parent.FullName);
            string imageDirectory = grandParent + "\\images\\";

            return imageDirectory;
        }
    }
}
