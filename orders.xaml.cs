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
    /// Логика взаимодействия для orders.xaml
    /// </summary>
    public partial class orders : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public orders()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Orders.ToList();
            vyborlogin.ItemsSource = context.Clients.ToList();
            vyborlogin.DisplayMemberPath = "ClientSurname";
            vyborlogin.SelectedValuePath = "ID_clients";
            vyborstatus.ItemsSource = context.Statuss.ToList();
            vyborstatus.DisplayMemberPath = "statusss";
            vyborstatus.SelectedValuePath = "ID_status";
            data.PreviewKeyDown += (sender, e) =>
            {
                e.Handled = e.Key == Key.Tab || e.Key == Key.Enter;
            };
            data.PreviewTextInput += (sender, e) =>
            {
                e.Handled = true;
            };
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Orders)dg1.SelectedItem;
            if (proverka != null)
            {
                data.SelectedDate = proverka.DateOrders;
                nomer.Text = proverka.NumberOfOrders.ToString();
                vyborlogin.SelectedValue = proverka.Clients_ID;
                vyborstatus.SelectedValue = proverka.Status_ID;
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (data.SelectedDate == null || string.IsNullOrWhiteSpace(nomer.Text) || vyborlogin.SelectedItem == null || vyborstatus.SelectedItem == null)
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Orders.Any(r => r.NumberOfOrders.ToString() == nomer.Text))
                {
                    MessageBox.Show("Такой номер заказа уже существует");
                }
                else
                {
                    Orders orders = new Orders();
                    if (int.TryParse(nomer.Text, out int orderNumber))
                    {
                        orders.NumberOfOrders = orderNumber;
                        orders.DateOrders = data.SelectedDate ?? DateTime.Now;

                        if (vyborlogin.SelectedItem != null)
                        {
                            var vyborLogin = (Clients)vyborlogin.SelectedItem;
                            orders.Clients_ID = vyborLogin.ID_clients;
                        }

                        if (vyborstatus.SelectedItem != null)
                        {
                            var vyborStatus = (Statuss)vyborstatus.SelectedItem;
                            orders.Status_ID = vyborStatus.ID_status;
                        }

                        context.Orders.Add(orders);
                        context.SaveChanges();

                        dg1.ItemsSource = context.Orders.ToList();
                        data.SelectedDate = null;
                        nomer.Text = null;
                        vyborlogin.SelectedItem = null;
                        vyborstatus.SelectedItem = null;
                    }
                }
            }
        }




        private void izmen(object sender, RoutedEventArgs e)
        {
            if (data.SelectedDate == null || string.IsNullOrWhiteSpace(nomer.Text) || vyborlogin.SelectedItem == null || vyborstatus.SelectedItem == null)
            {
                MessageBox.Show("Пустое поле");
            }
            if (dg1.SelectedItem != null)
            {
                var select = dg1.SelectedItem as Orders;
                if (context.Orders.Any(r => r.NumberOfOrders.ToString() == nomer.Text))
                {
                    MessageBox.Show("Такой номер заказа уже привязан");
                }
                else
                { 
                    int.TryParse(nomer.Text, out int orderNumber);
                    select.NumberOfOrders = orderNumber;
                    select.DateOrders = DateTime.Parse(data.Text);

                    if (vyborlogin.SelectedItem != null)
                    {
                        var vyborLogin = (Clients)vyborlogin.SelectedItem;
                        select.Clients_ID = vyborLogin.ID_clients;
                    }

                    if (vyborstatus.SelectedItem != null)
                    {
                        var vyborStatus = (Statuss)vyborstatus.SelectedItem;
                        select.Status_ID = vyborStatus.ID_status;
                    }
                    context.SaveChanges();

                    dg1.ItemsSource = context.Orders.ToList();
                    data.SelectedDate = null;
                    nomer.Text = null;
                    vyborlogin.SelectedItem = null;
                    vyborstatus.SelectedItem = null;
                }
            }
            
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Orders vyborudal1 = dg1.SelectedItem as Orders;
                int selected = vyborudal1.ID_orders;
                var count = context.OrdersBill.Count(lp => lp.orders_ID == selected);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Orders.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Orders.ToList();

                }
                data.SelectedDate = null;
                nomer.Text = null;
                vyborlogin.SelectedItem = null;
                vyborstatus.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Выберите или введите данные");
            }
        }
        

        private void vyhod(object sender, RoutedEventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Close();
        }

        private void provaerka(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void vyborlogin_select(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyborstatus_select(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
