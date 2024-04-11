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
    /// Логика взаимодействия для stomatologii.xaml
    /// </summary>
    public partial class stomatologii : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public stomatologii()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Dentistry.ToList();
            vyborord.ItemsSource = context.Stock.ToList();
            vyborord.SelectedValuePath = "ID_stock";
            vyborord.DisplayMemberPath = "WerehouseAddress";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Dentistry)dg1.SelectedItem;
            if (proverka != null)
            {
                stom.Text = proverka.AddressDentistry.ToString();
                vyborord.SelectedValue = proverka.stock_ID;
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(stom.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Dentistry.Any(r => r.AddressDentistry == stom.Text))
                {
                    MessageBox.Show("Такой адрес уже существует");
                    stom.Text = null;
                    vyborord.SelectedItem = null;
                }
                else
                {
                    if(context.Dentistry.Any(r => r.stock_ID == ((Stock)vyborord.SelectedItem).ID_stock))
                    {
                        MessageBox.Show("Такой склад привязан к стоматологии");
                    }
                    else
                    {
                        Dentistry stomm = new Dentistry();
                        stomm.AddressDentistry = stom.Text;
                        if (vyborord.SelectedItem != null)
                        {
                            var vyborLogin = (Stock)vyborord.SelectedItem;
                            stomm.stock_ID = vyborLogin.ID_stock;
                        }
                        context.Dentistry.Add(stomm);
                        context.SaveChanges();
                        dg1.ItemsSource = context.Dentistry.ToList();
                        stom.Text = null;
                        vyborord.SelectedItem = null;
                    }
                    
                }
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(stom.Text) || vyborord.SelectedItem == null)
                {
                    MessageBox.Show("Пустое поле");
                    stom.Text=null;
                    vyborord.SelectedItem = null;
                }
                else
                {
                    if (context.Dentistry.Any(r => r.AddressDentistry == stom.Text))
                    {
                        MessageBox.Show("Такой адрес уже существует");
                        stom.Text = null;
                        vyborord.SelectedItem = null;
                    }
                    else
                    {

                        var stomm = dg1.SelectedItem as Dentistry;
                        var select = (Stock)vyborord.SelectedItem;
                        if(stomm.stock_ID == select.ID_stock)
                        {
                            stomm.AddressDentistry = stom.Text;
                            stomm.stock_ID = select.ID_stock;
                            context.SaveChanges();
                            dg1.ItemsSource = context.Dentistry.ToList();
                            stom.Text = null;
                            vyborord.SelectedItem = null;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Dentistry vyborudal1 = dg1.SelectedItem as Dentistry;

                int selected = vyborudal1.ID_dentistry;
                var count = context.Bill.Count(lp => lp.Dentistry_ID == selected);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Dentistry.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Dentistry.ToList();
                    stom.Text = null;
                    vyborord.SelectedItem = null;
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

        private void vyborord_selected(object sender, SelectionChangedEventArgs e)
        {

        }
        private void proverka2(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != "." && !char.IsLetter(e.Text, 0) && e.Text != "\b")
            {
                e.Handled = true;
            }
        }

        private void stom_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 40)
            {
                MessageBox.Show("Много слишком символов");
                stom.Text = null;
            }
        }
    }
}
