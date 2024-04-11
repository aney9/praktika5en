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

namespace praktika5
{
    /// <summary>
    /// Логика взаимодействия для clientsforvrach.xaml
    /// </summary>
    public partial class clientsforvrach : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public clientsforvrach()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Clients.ToList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            vrach vrach = new vrach();
            vrach.Show();
            this.Close();
        }
    }
}
