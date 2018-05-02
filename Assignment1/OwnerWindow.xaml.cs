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
    /// Interaction logic for OwnerWindow.xaml
    /// </summary>
    public partial class OwnerWindow : Window
    {
        dataEntities db = new dataEntities();
        List<string> OwnersList = new List<string>();
        
        public OwnerWindow()
        {
            InitializeComponent();
        }
        public void ShowOwners()
        {
            var query1 = from own1 in db.Staffs
                         select new
                         {
                             own1.Name,
                             own1.ID,
                             own1.DOB
                         };

            foreach (var item in query1)
            {
                string x = string.Format("Name : {0} ID : {1} DOB : {2} Cars Owned : {0}",item.Name,item.ID,item.DOB);
                OwnersList.Add(x);
            }

            ListBoxOwners.ItemsSource = OwnersList;
        }
    }
}
