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
    /// Логика взаимодействия для ordersbill.xaml
    /// </summary>
    public partial class ordersbill : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public ordersbill()
        {
            InitializeComponent();
            dg1.ItemsSource = context.OrdersBill.ToList();
            vyborzak.ItemsSource = context.Orders.ToList();
            vyborzak.DisplayMemberPath = "NumberOfOrders";
            vyborzak.SelectedValuePath = "ID_orders";
            vyborpok.ItemsSource = context.Bill.ToList();
            vyborpok.DisplayMemberPath = "PurchaseAmount";
            vyborpok.SelectedValuePath = "ID_bill";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (OrdersBill)dg1.SelectedItem;
            if (proverka != null)
            {
                vyborpok.SelectedValue = proverka.bill_ID;
                vyborzak.SelectedValue = proverka.orders_ID;
            }
        }

        private void vyborzak_selected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyborpok_selected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (vyborpok.SelectedItem == null && vyborzak.SelectedItem == null)
            {
                MessageBox.Show("Выберите данные");
            }
            else
            {
                OrdersBill orb = new OrdersBill();
                if (orb != null)
                {
                    var Vybor = (Orders)vyborzak.SelectedItem;
                    var Vybor1 = (Bill)vyborpok.SelectedItem;
                    orb.orders_ID = Vybor.ID_orders;
                    orb.bill_ID = Vybor1.ID_bill;
                }
                context.OrdersBill.Add(orb);
                context.SaveChanges();
                dg1.ItemsSource = context.OrdersBill.ToList();
                vyborzak.SelectedItem = null;
                vyborpok.SelectedItem = null;
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            OrdersBill orders = dg1.SelectedItem as OrdersBill;
            if (orders != null)
            {
                if (vyborpok.SelectedItem != null && vyborzak.SelectedItem != null)
                {



                    var selectord = (Orders)vyborzak.SelectedItem;
                    var selectbill = (Bill)vyborpok.SelectedItem;
                    orders.orders_ID = selectord.ID_orders;
                    orders.bill_ID = selectbill.ID_bill;
                    context.SaveChanges();
                    dg1.ItemsSource = context.OrdersBill.ToList();
                    vyborzak.SelectedItem = null;
                    vyborpok.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Выберите данные");
                }
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            OrdersBill orb = dg1.SelectedItem as OrdersBill;
            if (orb != null)
            {
                context.OrdersBill.Remove(orb);
                context.SaveChanges();
                dg1.ItemsSource = context.OrdersBill.ToList();
                vyborzak.SelectedItem = null;
                vyborpok.SelectedItem = null;
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
    }
}
