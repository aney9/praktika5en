using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace praktika5
{
    /// <summary>
    /// Логика взаимодействия для orderusl.xaml
    /// </summary>
    public partial class orderusl : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public orderusl()
        {
            InitializeComponent();
            dg1.ItemsSource = context.OrdersService.ToList();
            vyborord.ItemsSource = context.Orders.ToList();
            vyborord.DisplayMemberPath = "NumberOfOrders";
            vyborord.SelectedValuePath = "ID_orders";
            vyborusl.ItemsSource = context.Servicess.ToList();
            vyborusl.DisplayMemberPath = "servicesss";
            vyborusl.SelectedValuePath = "ID_service";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (OrdersService)dg1.SelectedItem;
            if (proverka != null)
            {
                vyborord.SelectedValue = proverka.orders_ID;
                vyborusl.SelectedValue = proverka.service_ID;
            }
        }

        private void vyborord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (vyborusl.SelectedItem == null && vyborord.SelectedItem == null)
            {
                MessageBox.Show("выберите данные");
            }
            else
            {
                OrdersService ordersService = new OrdersService();
                if (ordersService != null)
                {
                    var Vybor = (Orders)vyborord.SelectedItem;
                    var Vybor1 = (Servicess)vyborusl.SelectedItem;
                    ordersService.orders_ID = Vybor.ID_orders;
                    ordersService.service_ID = Vybor1.ID_service;
                }
                context.OrdersService.Add(ordersService);
                context.SaveChanges();
                dg1.ItemsSource = context.OrdersService.ToList();
                vyborusl.SelectedItem = null;
                vyborord.SelectedItem = null;
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            OrdersService orders = dg1.SelectedItem as OrdersService;
            if (orders != null)
            {

                var selectord = (Orders)vyborord.SelectedItem;
                var selectusl = (Servicess)vyborusl.SelectedItem;
                orders.orders_ID = selectord.ID_orders;
                orders.service_ID = selectusl.ID_service;
                context.SaveChanges();
                dg1.ItemsSource = context.OrdersService.ToList();
                vyborusl.SelectedItem = null;
                vyborord.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("выберите данные");
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            OrdersService ordersService = dg1.SelectedItem as OrdersService;
            if(ordersService != null)
            {
                context.OrdersService.Remove(ordersService);
                context.SaveChanges();
                dg1.ItemsSource = context.OrdersService.ToList();
                vyborusl.SelectedItem = null;
                vyborord.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("выберите данные");
            }
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Close();
        }

        private void vyborusl_selected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyborord_selected(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
