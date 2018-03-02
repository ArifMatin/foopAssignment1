using System;
using System.Collections.Generic;
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

        private List<string> imageList = new List<string>();
        private int imageListIndex = 0;

        private string make = "";
        private string model = "";
        private int mileage = 0;
        private int price = 0;
        private int year = 0;
        private string description = "";
        private string[] colors;
        private string color = ""; // read in the colors and show in combox
        private string imageName = "";

        public Window2()
        {
            InitializeComponent();

        }
        public void ShowDetails()
        {
            labelAddVehicle.Visibility = Visibility.Hidden;  //changes the visibility for edit
            labelEdit.Visibility = Visibility.Visible;
            comboAddVehicle.Visibility = Visibility.Hidden;

            GetVehicleType();
            ShowColorList();

            txtMake.Text = vehicle.Make;
            txtModel.Text = vehicle.Model;
            txtPrice.Text = vehicle.Price.ToString();
            txtYear.Text = vehicle.Year.ToString();
            txtMileage.Text = vehicle.Mileage.ToString();
            txtDescription.Text = vehicle.Description;
            textImage.Text = vehicle.ImageName;


            int x = Array.IndexOf(colors, vehicle.Colour.ToString());
            comboColor.SelectedIndex = x;


            string type = vehicle.GetType().Name;
            ShowComboBoxBodyType(type);


        }
        private void ShowColorList()
        {
            MainWindow m = Owner as MainWindow;
            colors = m.colourList.Keys.ToArray();
            comboColor.ItemsSource = colors;

        }
        private void GetVehicleType()
        {

            if (vehicle.GetType().Name == "Car")
            {
                tempcar = (Car)vehicle;
            }
            else if (vehicle.GetType().Name == "Van")
            {
                tempvan = (Van)vehicle;
            }
            else if (vehicle.GetType().Name == "Bike")
            {
                tempbike = (Bike)vehicle;
            }
        }
        private void ShowComboBoxBodyType(string type)
        {
            if (type == "Car")
            {
                comboBoxType.ItemsSource = Enum.GetValues(typeof(CarBodyType));
                comboBoxType.SelectedIndex = (int)tempcar.BodyType;
            }
            else if (type == "Van")
            {
                comboBoxType.ItemsSource = Enum.GetValues(typeof(VanType));
                comboBoxType.SelectedIndex = (int)tempvan.BodyType;
            }
            else if (type == "Bike")
            {
                comboBoxType.ItemsSource = Enum.GetValues(typeof(BikeType));
                comboBoxType.SelectedIndex = (int)tempbike.BodyType;
            }
        }
        private void ReadInDeatils()
        {
            make = txtMake.Text;
            model = txtModel.Text;
            mileage = Convert.ToInt32(txtMileage.Text);
            price = Convert.ToInt32(txtPrice.Text);
            year = Convert.ToInt32(txtYear.Text);
            description = txtDescription.Text;
            color = comboColor.SelectedItem.ToString();
            imageName = textImage.Text;
        }
        private void AssignVales()
        {
            vehicle.Make = make;
            vehicle.Model = model;
            vehicle.Mileage = mileage;
            vehicle.Price = price;
            vehicle.Year = year;
            vehicle.Description = description;
            vehicle.Colour = color;
            vehicle.ImageName = imageName;
        }
        private void AssignComboSelection()
        {
            int x = comboBoxType.SelectedIndex;

            if (tempbike != null)
            {
                tempbike.BodyType = (BikeType)x;
            }
            else if (tempcar != null)
            {
                tempcar.BodyType = (CarBodyType)x;
            }
            else if (tempvan != null)
            {
                tempvan.BodyType = (VanType)x;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (labelEdit.Visibility == Visibility.Visible) // for when its edit
            {
                ReadInDeatils();
                AssignVales();
                AssignComboSelection();
            }
            else if (labelAddVehicle.Visibility == Visibility.Visible) // for when its add new vehicle
            {
                ReadInDeatils();
                CreateNewVehicle();
                AssignComboSelection();

                if (tempvan != null)
                {
                    GetWheelBase();
                }
                CheckNotNull();
            }      
            //bodytype and wheelbase.
            this.Close();
        }
        //entery into this class to add new vehicle.
        public void NewVehicle()
        {
            labelEdit.Visibility = Visibility.Hidden;
            labelAddVehicle.Visibility = Visibility.Visible;
            comboAddVehicle.Visibility = Visibility.Visible;
            ShowColorList();
            comboColor.SelectedIndex = 0;
            //combo vehicle type then cretate new type vehicle, run getypye method to display enum

        }
        private void comboAddVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string type = comboAddVehicle.SelectedItem.ToString();
            labelWheelbase.Visibility = Visibility.Hidden;
            comboWheelBse.Visibility = Visibility.Hidden;

            if (type == "Car")
            {
                comboBoxType.ItemsSource = Enum.GetValues(typeof(CarBodyType));
                comboBoxType.SelectedIndex = 0;
            }
            else if (type == "Van")
            {
                labelWheelbase.Visibility = Visibility.Visible;
                comboWheelBse.Visibility = Visibility.Visible;
                comboWheelBse.ItemsSource = Enum.GetValues(typeof(WheelBase));
                comboWheelBse.SelectedIndex = 0;
                comboBoxType.ItemsSource = Enum.GetValues(typeof(VanType));
                comboBoxType.SelectedIndex = 0;
            }
            else if (type == "Bike")
            {
                comboBoxType.ItemsSource = Enum.GetValues(typeof(BikeType));
                comboBoxType.SelectedIndex = 0;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] type = { "Car", "Van", "Bike" };
            comboAddVehicle.ItemsSource = type;
            comboAddVehicle.SelectedIndex = 0;
        }
        private void CreateNewVehicle()
        {
            string type = comboAddVehicle.SelectedItem.ToString();

            if (type == "Car")
            {
                tempcar = new Car(model,make,CarBodyType.Convertible,price,year,mileage,0,description,color, "/images/all1.png",imageName);
            }
            else if (type == "Van")
            {
                tempvan = new Van(model, make,VanType.Dropside, price, year, mileage, 0,WheelBase.Short, description,color, "/images/all1.png",imageName);
            }
            else if (type == "Bike")
            {
                tempbike = new Bike(model, make,BikeType.Commuter, price, year, mileage, 0, description,color, "/images/all1.png",imageName);
            }
        }
        private void GetWheelBase()
        {
            int x = comboWheelBse.SelectedIndex;
            tempvan.Wheelbase = (WheelBase)x;
        }
        private void CheckNotNull()
        {
            MainWindow main = Owner as MainWindow;


            if (tempbike != null)
            {
                main.vehicleCollection.Add(tempbike);

            }
            else if (tempcar != null)
            {
                main.vehicleCollection.Add(tempcar);
            }
            else if (tempvan != null)
            {
                main.vehicleCollection.Add(tempvan);

            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Images (*.JPG;*.JPEG;*.PNG) | *.JPG;*.JPEG;*.PNG";
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;

                string imageDirectory = GetImageDirectory();

                string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1);

                if (CheckImageName(shortFileName))
                {
                    string newFile = imageDirectory + shortFileName;

                    File.Copy(filename, newFile);
                }

                textImage.Text = shortFileName;

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
        private bool CheckImageName(string newImage)
        {
            bool ans = true;
            string[] files = Directory.GetFiles(GetImageDirectory());

            foreach (string s in files)
            {
                imageList.Add(s.Substring(s.LastIndexOf('\\') + 1));
            }

            for(int i = 0; i < imageList.Count; i++) // checks if newimage is in images folder.
            {
                if (imageList[i] == newImage)
                {
                    ans = false;
                    imageListIndex = i;
                }
            }
            return ans;
        }
    }
}
