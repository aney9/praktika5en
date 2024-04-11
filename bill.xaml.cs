using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для bill.xaml
    /// </summary>
    public partial class bill : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public bill()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Bill.ToList();
            vyborstom.ItemsSource = context.Dentistry.ToList();
            vyborstom.SelectedValuePath = "ID_dentistry";
            vyborstom.DisplayMemberPath = "AddressDentistry";
            vyborlogin.ItemsSource = context.Doctors.ToList();
            vyborlogin.SelectedValuePath = "ID_doctors";
            vyborlogin.DisplayMemberPath = "DoctorSurname";
            vyborlogincl.ItemsSource = context.Clients.ToList();
            vyborlogincl.SelectedValuePath = "ID_clients";
            vyborlogincl.DisplayMemberPath = "ClientSurname";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Bill)dg1.SelectedItem;
            if (proverka != null)
            {
                pokup.Text = proverka.PurchaseAmount.ToString();
                vyborstom.SelectedValue = proverka.Dentistry_ID;
                vyborlogin.SelectedValue = proverka.Doctor_ID;
                vyborlogincl.SelectedValue = proverka.Clients_ID;
            }
        }

        private void vyborstom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyborlogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyborlogincl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if((string.IsNullOrWhiteSpace(pokup.Text) || vyborstom.SelectedItem == null || vyborlogin.SelectedItem == null || vyborlogincl == null))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                decimal Price = Convert.ToDecimal(pokup.Text);
                if(Price <= 0)
                {
                    MessageBox.Show("Суммма покупки должна быть больше 0");
                }
                else
                {
                    Bill bill = new Bill();
                    if (bill != null)
                    {
                        var Vybor = (Dentistry)vyborstom.SelectedItem;
                        var Vybor1 = (Doctors)vyborlogin.SelectedItem;
                        var Vybor2 = (Clients)vyborlogincl.SelectedItem;
                        bill.Dentistry_ID = Vybor.ID_dentistry;
                        bill.Doctor_ID = Vybor1.ID_doctors;
                        bill.Clients_ID = Vybor2.ID_clients;
                    }
                    bill.PurchaseAmount = Price;
                    context.Bill.Add(bill);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Bill.ToList();
                    pokup.Text = null;
                    vyborstom.SelectedItem = null;
                    vyborlogin.SelectedItem = null;
                    vyborlogincl.SelectedItem = null;
                }
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(pokup.Text) || vyborstom.SelectedItem == null || vyborlogin.SelectedItem == null || vyborlogincl == null))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                decimal Price = Convert.ToDecimal(pokup.Text);
                if (Price <= 0)
                {
                    MessageBox.Show("Суммма покупки должна быть больше 0");
                }
                else
                {
                    Bill bill = dg1.SelectedItem as Bill;
                    if (bill != null)
                    {
                        var Vybor = (Dentistry)vyborstom.SelectedItem;
                        var Vybor1 = (Doctors)vyborlogin.SelectedItem;
                        var Vybor2 = (Clients)vyborlogincl.SelectedItem;
                        bill.Dentistry_ID = Vybor.ID_dentistry;
                        bill.Doctor_ID = Vybor1.ID_doctors;
                        bill.Clients_ID = Vybor2.ID_clients;
                        bill.PurchaseAmount = Price;
                        context.SaveChanges();
                        dg1.ItemsSource = context.Bill.ToList();
                        pokup.Text = null;
                        vyborstom.SelectedItem = null;
                        vyborlogin.SelectedItem = null;
                        vyborlogincl.SelectedItem = null;
                    }
                }
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {

        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Close();
        }
        private void proverkaprice1(object sender, TextCompositionEventArgs e)
        {
            string newText = (sender as TextBox).Text + e.Text;
            if (!decimal.TryParse(newText, out _))
            {
                e.Handled = true;
            }
        }
    }
}
