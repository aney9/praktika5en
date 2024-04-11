using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace praktika5
{
    /// <summary>
    /// Логика взаимодействия для roles.xaml
    /// </summary>
    public partial class roles : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public roles()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Roles.ToList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Roles)dg1.SelectedItem;
            if (proverka != null)
            {
                rol.Text = proverka.DentistryRole.ToString();
            }
        }

        private void dob(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rol.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Roles.Any(r => r.DentistryRole == rol.Text))
                {
                    MessageBox.Show("Такая роль уже существует");
                    rol.Text = null;
                }
                else
                {

                    Roles roles = new Roles();
                    roles.DentistryRole = rol.Text;
                    context.Roles.Add(roles);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Roles.ToList();
                    rol.Text = null;
                }
            }
        }

        private void izm(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(rol.Text))
                {
                    MessageBox.Show("Пустое поле");
                }
                else
                {
                    if (context.Roles.Any(r => r.DentistryRole == rol.Text))
                    {
                        MessageBox.Show("Такая роль уже существует");
                        rol.Text = null;
                    }
                    else
                    {

                        var roles = dg1.SelectedItem as Roles;
                        roles.DentistryRole = rol.Text;
                        context.SaveChanges();
                        dg1.ItemsSource = context.Roles.ToList();
                        rol.Text = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Roles vyborudal1 = dg1.SelectedItem as Roles;

                int selectedRoleId = vyborudal1.ID_roles; 
                var count = context.LoginPassword.Count(lp => lp.roles_ID == selectedRoleId);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Roles.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Roles.ToList();
                    rol.Text = null;
                }
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

        private void proverka(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 20)
            {
                MessageBox.Show("Много слишком символов");
                rol.Text = null;
            }
        }
        private void proverka2(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
    }
}
