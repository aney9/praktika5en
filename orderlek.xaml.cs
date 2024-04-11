using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
    /// Логика взаимодействия для orderlek.xaml
    /// </summary>
    public partial class orderlek : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public orderlek()
        {
            InitializeComponent();
            dg1.ItemsSource = context.OrdersMedicines.ToList();
            vyborord.ItemsSource = context.Orders.ToList();
            vyborord.DisplayMemberPath = "NumberOfOrders";
            vyborord.SelectedValuePath = "ID_orders";
            vyborlek.ItemsSource = context.Medicines.ToList();
            vyborlek.DisplayMemberPath = "mediciness";
            vyborlek.SelectedValuePath = "ID_medicines";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (OrdersMedicines)dg1.SelectedItem;
            if (proverka != null)
            {
                vyborord.SelectedValue = proverka.orders_ID;
                vyborlek.SelectedValue = proverka.medicines_ID;
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (vyborord.SelectedItem == null && vyborlek.SelectedItem == null)
            {
                MessageBox.Show("Выберите данные");
            }
            else
            {
                OrdersMedicines ordersMedicines = new OrdersMedicines();
                if (ordersMedicines != null)
                {
                    var Vybor = (Orders)vyborord.SelectedItem;
                    var Vybor1 = (Medicines)vyborlek.SelectedItem;
                    ordersMedicines.orders_ID = Vybor.ID_orders;
                    ordersMedicines.medicines_ID = Vybor1.ID_medicines;
                }
                context.OrdersMedicines.Add(ordersMedicines);
                context.SaveChanges();
                dg1.ItemsSource = context.OrdersMedicines.ToList();
                vyborlek.SelectedItem = null;
                vyborord.SelectedItem = null;
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            OrdersMedicines orders = dg1.SelectedItem as OrdersMedicines;
            if (orders != null)
            {

                var selectord = (Orders)vyborord.SelectedItem;
                var selectusl = (Medicines)vyborlek.SelectedItem;
                orders.orders_ID = selectord.ID_orders;
                orders.medicines_ID = selectusl.ID_medicines;
                context.SaveChanges();
                dg1.ItemsSource = context.OrdersMedicines.ToList();
                vyborlek.SelectedItem = null;
                vyborord.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            OrdersMedicines ordersMedicines = dg1.SelectedItem as OrdersMedicines;
            if (ordersMedicines != null)
            {
                context.OrdersMedicines.Remove(ordersMedicines);
                context.SaveChanges();
                dg1.ItemsSource = context.OrdersMedicines.ToList();
                vyborlek.SelectedItem = null;
                vyborord.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Close();
        }

        private void vyborlek_selected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyborord_selected(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
