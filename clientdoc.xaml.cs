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
    /// Логика взаимодействия для clientdoc.xaml
    /// </summary>
    public partial class clientdoc : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public clientdoc()
        {
            InitializeComponent();
            dg1.ItemsSource = context.ClientDoctor.ToList();
            vyborcli.ItemsSource = context.Clients.ToList();
            vyborcli.SelectedValuePath = "ID_clients";
            vyborcli.DisplayMemberPath = "ClientSurname";
            vybordoc.ItemsSource = context.Doctors.ToList();
            vybordoc.SelectedValuePath = "ID_doctors";
            vybordoc.DisplayMemberPath = "DoctorSurname";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (ClientDoctor)dg1.SelectedItem;
            if (proverka != null)
            {
                vyborcli.SelectedValue = proverka.clients_ID;
                vybordoc.SelectedValue = proverka.doctors_ID;
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (vyborcli.SelectedItem == null && vybordoc.SelectedItem == null)
            {
                MessageBox.Show("выберите данные");
            }
            else
            {
                ClientDoctor cld= new ClientDoctor();
                if (cld != null)
                {
                    var Vybor = (Clients)vyborcli.SelectedItem;
                    var Vybor1 = (Doctors)vybordoc.SelectedItem;
                    cld.clients_ID = Vybor.ID_clients;
                    cld.doctors_ID = Vybor1.ID_doctors;
                }
                context.ClientDoctor.Add(cld);
                context.SaveChanges();
                dg1.ItemsSource = context.ClientDoctor.ToList();
                vyborcli.SelectedItem = null;
                vybordoc.SelectedItem = null;
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            ClientDoctor cld = dg1.SelectedItem as ClientDoctor;
            if (cld != null )
            {
                if(vyborcli.SelectedItem != null && vybordoc.SelectedItem != null)
                {
                    var Vybor = (Clients)vyborcli.SelectedItem;
                    var Vybor1 = (Doctors)vybordoc.SelectedItem;
                    cld.clients_ID = Vybor.ID_clients;
                    cld.doctors_ID = Vybor1.ID_doctors;
                    context.SaveChanges();
                    dg1.ItemsSource = context.ClientDoctor.ToList();
                    vyborcli.SelectedItem = null;
                    vybordoc.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("выберите данные");
                }
            }
            else
            {
                MessageBox.Show("выберите данные");
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            ClientDoctor cld = dg1.SelectedItem as ClientDoctor;
            if (cld != null)
            {
                context.ClientDoctor.Remove(cld);
                context.SaveChanges();
                dg1.ItemsSource = context.ClientDoctor.ToList();
                vyborcli.SelectedItem = null;
                vybordoc.SelectedItem = null;
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
