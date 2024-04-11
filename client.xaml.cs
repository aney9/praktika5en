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
    /// Логика взаимодействия для client.xaml
    /// </summary>
    public partial class client : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public client()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Clients.ToList();
            vybor.ItemsSource = context.LoginPassword.Where(r => r.roles_ID == 3).ToList();
            vybor.SelectedValuePath = "ID_loginpassword";
            vybor.DisplayMemberPath = "loginvhod";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Clients)dg1.SelectedItem;
            if (proverka != null)
            {
                imya.Text = proverka.ClientName.ToString();
                fam.Text = proverka.ClientSurname.ToString();
                otch.Text = proverka.ClientMiddlename.ToString();
                tel.Text = proverka.PhoneNumber.ToString();
                vybor.SelectedValue = proverka.loginpassword_ID;
            }
        }

        private void dob(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(imya.Text) || string.IsNullOrWhiteSpace(fam.Text) || vybor.SelectedItem == null)
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Clients.Any(r => r.PhoneNumber == tel.Text))
                {
                    MessageBox.Show("Такой номер телефона уже есть");
                    tel.Text = null;
                }
                else if (context.Clients.Any(r => r.loginpassword_ID == ((LoginPassword)vybor.SelectedItem).ID_loginpassword))
                {
                    MessageBox.Show("Такой логин привязан к аккаунту");
                }
                else
                {
                    Clients clients = new Clients();
                    clients.ClientName = imya.Text;
                    clients.ClientSurname = fam.Text;
                    clients.ClientMiddlename = otch.Text;
                    clients.PhoneNumber = tel.Text;
                    if (vybor.SelectedItem != null)
                    {
                        var vyborLogin = (LoginPassword)vybor.SelectedItem;
                        clients.loginpassword_ID = vyborLogin.ID_loginpassword;
                    }
                    context.Clients.Add(clients);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Clients.ToList();
                    imya.Text = null;
                    fam.Text = null;
                    otch.Text = null;
                    tel.Text = null;
                    vybor.SelectedItem = null;
                }
            }
        }

        private void izm(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(imya.Text) || string.IsNullOrWhiteSpace(fam.Text) || string.IsNullOrWhiteSpace(tel.Text) || vybor.SelectedItem == null)
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                Clients vyborclient = dg1.SelectedItem as Clients;
                var selectedLogin = (LoginPassword)vybor.SelectedItem;
                if (context.Clients.Any(r => r.PhoneNumber == tel.Text && r.loginpassword_ID != selectedLogin.ID_loginpassword))
                {
                    MessageBox.Show("Такой номер телефона уже есть");
                    tel.Text = null;
                }
                else
                {
                    if(vyborclient.loginpassword_ID == selectedLogin.ID_loginpassword)
                    {
                        vyborclient.ClientSurname = fam.Text;
                        vyborclient.ClientName = imya.Text;
                        vyborclient.ClientMiddlename = otch.Text;
                        vyborclient.PhoneNumber = tel.Text;
                        vyborclient.loginpassword_ID = selectedLogin.ID_loginpassword;
                        context.SaveChanges();
                        dg1.ItemsSource = context.Clients.ToList();
                        imya.Text = null;
                        fam.Text = null;
                        otch.Text = null;
                        tel.Text = null;
                        vybor.SelectedItem = null;
                    }
                }
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Clients vyborudal1 = dg1.SelectedItem as Clients;
                int selected = vyborudal1.ID_clients;
                var count = context.LoginPassword.Count(lp => lp.ID_loginpassword == selected);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Clients.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Clients.ToList();

                }
                imya.Text = null;
                fam.Text = null;
                otch.Text = null;
                tel.Text = null;
                vybor.SelectedItem = null;
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void proverkaim(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 25)
            {
                MessageBox.Show("Много слишком символов");
                imya.Text = null;
            }
        }
        private void proverkaim1(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void proverkafam(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 25)
            {
                MessageBox.Show("Много слишком символов");
                fam.Text = null;
            }
        }
        private void proverkafam1(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void proverkaotch(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 25)
            {
                MessageBox.Show("Много слишком символов");
                otch.Text = null;
            }
        }
        private void proverkaotch1(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void proverkatel(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text.Length == 0)
            {
                return;
            }

            if (textBox.Text.Length != 11 && textBox.Text[0] != '8' && textBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Номер телефона должен иметь 11 символов и начинаться с 8");
            }
        }
        private void proverkatel1(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
    }
}
