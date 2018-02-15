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

        public MainWindow()
        {
            InitializeComponent();
            Car car1;
            Car car2;
            Car car3;

            Bike bike1;
            Bike bike2;
            Bike bike3;

            vehicleCollection.Add(car1 = new Car(Car.GetVehicleMake(), Car.GetVehicleModel(), CarBodyType.MPV));
            vehicleCollection.Add(car2 = new Car(Car.GetVehicleMake(), Car.GetVehicleModel(), CarBodyType.MPV));
            vehicleCollection.Add(car3 = new Car(Car.GetVehicleMake(), Car.GetVehicleModel(), CarBodyType.MPV));

            vehicleCollection.Add(bike1 = new Bike(Bike.GetVehicleMake(),Bike.GetVehicleModel(),BikeType.Scooter));
            vehicleCollection.Add(bike3 = new Bike(Bike.GetVehicleMake(), Bike.GetVehicleModel(), BikeType.Scooter));
            vehicleCollection.Add(bike3 = new Bike(Bike.GetVehicleMake(), Bike.GetVehicleModel(), BikeType.Scooter));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBoxVehicle.ItemsSource = vehicleCollection;
        }
    }
}
