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

        public Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
 
            CreateVanObjects(random,10);
            CreateBikeObjects(random, 10);
            CreateCaranObjects(random,10);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBoxVehicle.ItemsSource = vehicleCollection;
        }

        private void CreateVanObjects(Random random, int numOfObjects)
        {
            Van[] vanArray = new Van[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                vanArray[i] = new Van(Van.GetVehicleMake(random), Van.GetVehicleModel(random), (VanType)random.Next(6));
                vehicleCollection.Add(vanArray[i]);
            }
        }
        private void CreateCaranObjects(Random random, int numOfObjects)
        {
            Car[] CarArray = new Car[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                CarArray[i] = new Car(Car.GetVehicleMake(random), Car.GetVehicleModel(random), (CarBodyType)random.Next(6));
                vehicleCollection.Add(CarArray[i]);
            }
        }
        private void CreateBikeObjects(Random random, int numOfObjects)
        {
            Bike[] BikeArray = new Bike[numOfObjects];
            for (int i = 0; i < numOfObjects; i++)
            {
                BikeArray[i] = new Bike(Bike.GetVehicleMake(random), Bike.GetVehicleModel(random), (BikeType)random.Next(6));
                vehicleCollection.Add(BikeArray[i]);
            }
        }
    }
}
