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
    /// Логика взаимодействия для vrach.xaml
    /// </summary>
    public partial class vrach : Window
    {
        List<string> list = new List<string> {"Клиенты","Лекарства","Склад","Стоматологии","Врачи"};
        public vrach()
        {
            InitializeComponent();
            vybor.ItemsSource = list;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vybor.SelectedItem == list[0])
            {
                clientsforvrach vr = new clientsforvrach();
                vr.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[1])
            {
                lekforvrach vr = new lekforvrach();
                vr.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[2])
            {
                skladforvrach skl = new skladforvrach(); 
                skl.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[3])
            {
                stomforvrach stom = new stomforvrach();
                stom.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[4])
            {
                vrachforvrach vrach = new vrachforvrach();
                vrach.Show();
                this.Close();
            }
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
