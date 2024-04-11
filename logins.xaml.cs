using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для logins.xaml
    /// </summary>
    public partial class logins : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public logins()
        {
            InitializeComponent();
            dg1.ItemsSource = context.LoginPassword.ToList();
            vybor.ItemsSource = context.Roles.ToList();
            vybor.SelectedValuePath = "ID_roles";
            vybor.DisplayMemberPath = "DentistryRole";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (LoginPassword)dg1.SelectedItem;
            if (proverka != null)
            {
                login.Text = proverka.loginvhod.ToString();
                parol.Text = proverka.passwordvhod.ToString();
                vybor.SelectedValue = proverka.roles_ID;
            }
        }

        private void vybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Close();
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                LoginPassword vyborudal1 = dg1.SelectedItem as LoginPassword;

                int selected = vyborudal1.ID_loginpassword;
                var count = context.Clients.Count(lp => lp.loginpassword_ID == selected);
                var count1 = context.Doctors.Count(lp => lp.loginpassword_ID == selected);
                if (count > 0 || count1 > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.LoginPassword.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.LoginPassword.ToList();
                    login.Text = null;
                    parol.Text = null;
                    vybor.SelectedItem = null;
                }
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            if(dg1.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(login.Text) || string.IsNullOrWhiteSpace(parol.Text) || vybor.SelectedItem == null)
                {
                    MessageBox.Show("Пустое поле");
                }
                else
                {
                    LoginPassword vyborLogin = dg1.SelectedItem as LoginPassword;
                    if (context.LoginPassword.Any(r => r.loginvhod == login.Text && r.roles_ID != vyborLogin.roles_ID))
                    {
                        MessageBox.Show("Такой логин уже существует");
                    }
                    else
                    {
                        if (login.Text.Length >= 2 && parol.Text.Length >= 8)
                        {
                            var selectedRole = (Roles)vybor.SelectedItem;
                            vyborLogin.loginvhod = login.Text;
                            vyborLogin.passwordvhod = parol.Text;
                            vyborLogin.roles_ID = selectedRole.ID_roles;
                            context.SaveChanges();
                            dg1.ItemsSource = context.LoginPassword.ToList();
                            login.Text = null;
                            parol.Text = null;
                            vybor.SelectedItem = null;
                        }
                        else
                        {
                            MessageBox.Show("Логин должен быть больше 2-х символов, а пароль больше 8 символов");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите и измените данные");
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login.Text) || string.IsNullOrWhiteSpace(parol.Text) || vybor.SelectedItem == null)
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.LoginPassword.Any(r => r.loginvhod == login.Text))
                {
                    MessageBox.Show("Такой логин уже существует");
                    login.Text = null;
                }
                else
                {
                    if (login.Text.Length >= 2 && parol.Text.Length >= 8)
                    {
                        LoginPassword Login = new LoginPassword();
                        Login.loginvhod = login.Text;
                        Login.passwordvhod = parol.Text;
                        if (vybor.SelectedItem != null)
                        {
                            var vyborRole = (Roles)vybor.SelectedItem;
                            Login.roles_ID = vyborRole.ID_roles;
                        }
                        context.LoginPassword.Add(Login);
                        context.SaveChanges();
                        dg1.ItemsSource = context.LoginPassword.ToList();
                        login.Text = null;
                        parol.Text = null;
                        vybor.SelectedItem = null;
                    }
                    else
                    {
                        MessageBox.Show("Логин должен быть больше 2-х символов, а пароль больше 8 символов");
                        parol.Text = null;
                        login.Text = null;
                    }
                }
            }
        }

        private void proverkalogin(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 15)
            {
                MessageBox.Show("Много слишком символов");
                login.Text = null;
            }
        }

        private void proverkaparol(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 25)
            {
                MessageBox.Show("Много слишком символов");
                parol.Text = null;
            }
        }
        private void proverkalogin1(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
        private void proverkaparol1(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}


