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
    /// Логика взаимодействия для status.xaml
    /// </summary>
    public partial class status : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public status()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Statuss.ToList();
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Statuss)dg1.SelectedItem;
            if (proverka != null)
            {
                stat.Text = proverka.statusss.ToString();
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(stat.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Statuss.Any(r => r.statusss == stat.Text))
                {
                    MessageBox.Show("Такая роль уже существует");
                    stat.Text = null;
                }
                else
                {

                    Statuss statt = new Statuss();
                    statt.statusss = stat.Text;
                    context.Statuss.Add(statt);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Statuss.ToList();
                    stat.Text = null;
                }
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(stat.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Statuss.Any(r => r.statusss == stat.Text))
                {
                    MessageBox.Show("Такой статус уже существует");
                    stat.Text = null;
                }
                else
                {
                    var statt = dg1.SelectedItem as Statuss;
                    statt.statusss = stat.Text;
                    context.SaveChanges();
                    dg1.ItemsSource = context.Statuss.ToList();
                    stat.Text = null;
                }
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Statuss vyborudal1 = dg1.SelectedItem as Statuss;

                int selectedRoleId = vyborudal1.ID_status;
                var count = context.Orders.Count(lp => lp.Status_ID == selectedRoleId);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Statuss.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Statuss.ToList();
                    stat.Text = null;
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

        private void proverkast(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 25)
            {
                MessageBox.Show("Много слишком символов");
                stat.Text = null;
            }
        }
        private void proverkast1(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
