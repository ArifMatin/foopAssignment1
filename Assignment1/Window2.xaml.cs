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
        public Window2()
        {
            InitializeComponent();

            
        }
        public void ShowDetails(Vehicle c)
        {
            string name = c.GetType().Name;
            txtMake.Text = c.Make;
            txtModel.Text = c.Model;
            txtPrice.Text = c.Price.ToString();
            txtYear.Text = c.Year.ToString();
            txtMileage.Text = c.Mileage.ToString();
           // txtBodyType.Text = c.BodyType;                      //bodytype is not in vehicle class
        }
    }
}
