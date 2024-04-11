using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace praktika5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();    
        public MainWindow()
        {
            InitializeComponent();
        }

        private void avtoriz(object sender, RoutedEventArgs e)
        {
            var loginpas = context.LoginPassword.ToList();
            bool vhod = false;
            foreach (var item in loginpas)
            {
                if (item.loginvhod == Login.Text && item.passwordvhod == Parol.Password && Parol.Password.Length > 8)
                {
                    vhod = true;
                    if(item.roles_ID == 1)
                    {
                        admin admin = new admin();
                        admin.Show();
                        this.Close();
                    }
                    else if (item.roles_ID == 2)
                    {
                        vrach vrach = new vrach();
                        vrach.Show();
                        this.Close();
                    }
                    else if (item.roles_ID == 3)
                    {
                        clients clients = new clients();
                        clients.Show();
                        this.Close();
                    }
                    break;
                }
            }
            if (!vhod)
            {
                MessageBox.Show("Неверный логин или пароль, либо пароль меньше 8 символов");
                Login.Text = null;
                Parol.Password = null;
            }
        }
    }
}
