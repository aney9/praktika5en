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
    /// Логика взаимодействия для sklad.xaml
    /// </summary>
    public partial class sklad : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public sklad()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Stock.ToList();
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Stock)dg1.SelectedItem;
            if (proverka != null)
            {
                skladd.Text = proverka.WerehouseAddress.ToString();
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(skladd.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Stock.Any(r => r.WerehouseAddress == skladd.Text))
                {
                    MessageBox.Show("Такой адрес уже существует");
                    skladd.Text = null;
                }
                else
                {

                    Stock sklad = new Stock();
                    sklad.WerehouseAddress = skladd.Text;
                    context.Stock.Add(sklad);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Stock.ToList();
                    skladd.Text = null;
                }
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(skladd.Text))
                {
                    MessageBox.Show("Пустое поле");
                }
                else
                {
                    if (context.Stock.Any(r => r.WerehouseAddress == skladd.Text))
                    {
                        MessageBox.Show("Такой адрес уже существует");
                        skladd.Text = null;
                    }
                    else
                    {

                        var sklad = dg1.SelectedItem as Stock;
                        sklad.WerehouseAddress = skladd.Text;
                        context.SaveChanges();
                        dg1.ItemsSource = context.Stock.ToList();
                        skladd.Text = null;
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
                Stock vyborudal1 = dg1.SelectedItem as Stock;

                int selectedRoleId = vyborudal1.ID_stock;
                var count = context.StockMedicines.Count(lp => lp.stock_ID == selectedRoleId);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Stock.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Stock.ToList();
                    skladd.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Close();
        }
        private void proverka2(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != "." && !char.IsLetter(e.Text, 0) && e.Text != "\b")
            {
                e.Handled = true;
            }
        }
    }
}
