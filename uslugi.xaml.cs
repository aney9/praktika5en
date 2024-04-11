using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для uslugi.xaml
    /// </summary>
    public partial class uslugi : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public uslugi()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Servicess.ToList();
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Servicess)dg1.SelectedItem;
            if (proverka != null)
            {
                usl.Text = proverka.servicesss.ToString();
                price.Text = proverka.PriceService.ToString();
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usl.Text) || string.IsNullOrWhiteSpace(price.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Servicess.Any(r => r.servicesss == usl.Text))
                {
                    MessageBox.Show("Такая услуга уже существует");
                    usl.Text = null;
                }
                else
                {
                    decimal Price = Convert.ToDecimal(price.Text);
                    if (Price == 0)
                    {
                        MessageBox.Show("Цена должна быть больше нуля");
                    }
                    else
                    {
                        if (usl.Text.Length < 8 || usl.Text.Length > 30)
                        {
                            MessageBox.Show("Название услуги должно быть больше 8 и меньше 30 символов");
                        }
                        else
                        {
                            Servicess serv = new Servicess();
                            serv.servicesss = usl.Text;
                            serv.PriceService = Price;
                            context.Servicess.Add(serv);
                            context.SaveChanges();
                            dg1.ItemsSource = context.Servicess.ToList();
                            usl.Text = null;
                            price.Text = null;
                        }
                    }
                }

            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usl.Text) || string.IsNullOrWhiteSpace(price.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                decimal Price = Convert.ToDecimal(price.Text);
                if (Price == 0)
                {
                    MessageBox.Show("Цена должна быть больше нуля");
                }
                else
                {
                    if (usl.Text.Length < 8 || usl.Text.Length > 30)
                    {
                        MessageBox.Show("Название услуги должно быть больше 8 и меньше 30 символов");
                    }
                    else
                    {

                        var usluga = dg1.SelectedItem as Servicess;
                        if (!context.Servicess.Any(r => r.servicesss == usl.Text && r.ID_service != usluga.ID_service))
                        {
                            usluga.servicesss = usl.Text;
                            usluga.PriceService = Price;
                            context.SaveChanges();
                            dg1.ItemsSource = context.Servicess.ToList();
                            usl.Text = null;
                            price.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("Такая услуга уже существует");
                            usl.Text = null;
                        }
                    }
                }
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Servicess vyborudal1 = dg1.SelectedItem as Servicess;

                int selectedId = vyborudal1.ID_service;
                var count = context.OrdersService.Count(lp => lp.service_ID == selectedId);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Servicess.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Servicess.ToList();
                    usl.Text = null;
                    price.Text = null;
                }
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

        private void proverkausl1(object sender, TextCompositionEventArgs e)
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
