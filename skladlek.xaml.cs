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
    /// Логика взаимодействия для skladlek.xaml
    /// </summary>
    public partial class skladlek : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public skladlek()
        {
            InitializeComponent();
            dg1.ItemsSource = context.StockMedicines.ToList();
            vyborskl.ItemsSource = context.Stock.ToList();
            vyborskl.DisplayMemberPath = "WerehouseAddress";
            vyborskl.SelectedValuePath = "ID_stock";
            vyborlek.ItemsSource = context.Medicines.ToList();
            vyborlek.DisplayMemberPath = "mediciness";
            vyborlek.SelectedValuePath = "ID_medicines";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (StockMedicines)dg1.SelectedItem;
            if (proverka != null)
            {
                vyborskl.SelectedValue = proverka.stock_ID;
                vyborlek.SelectedValue = proverka.medicines_ID;
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            StockMedicines Skladlek = new StockMedicines();
            if (vyborlek.SelectedItem == null && vyborskl.SelectedItem == null)
            {
                MessageBox.Show("Выберите данные");
            }
            else { 
                var Vybor = (Medicines)vyborlek.SelectedItem;
                var Vybor1 = (Stock)vyborskl.SelectedItem;
                Skladlek.medicines_ID = Vybor.ID_medicines;
                Skladlek.stock_ID = Vybor1.ID_stock;
                if (!context.StockMedicines.Any(sm => sm.medicines_ID == Skladlek.medicines_ID))
                {
                    context.StockMedicines.Add(Skladlek);
                    context.SaveChanges();
                    dg1.ItemsSource = context.StockMedicines.ToList();
                    vyborlek.SelectedItem = null;
                    vyborskl.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Такое лекарство уже есть на складе");
                }
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            StockMedicines Skladlek = dg1.SelectedItem as StockMedicines;
            if (dg1.SelectedItem != null)
            {

                var Vybor = (Medicines)vyborlek.SelectedItem;
                var Vybor1 = (Stock)vyborskl.SelectedItem;
                Skladlek.medicines_ID = Vybor.ID_medicines;
                Skladlek.stock_ID = Vybor1.ID_stock;
                if (!context.StockMedicines.Any(sm => sm.medicines_ID == Skladlek.medicines_ID))
                {
                    context.SaveChanges();
                    dg1.ItemsSource = context.StockMedicines.ToList();
                    vyborlek.SelectedItem = null;
                    vyborskl.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Такое лекарство уже есть на складе");
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные");
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            StockMedicines Skladlek = dg1.SelectedItem as StockMedicines;
            if (dg1.SelectedItem != null)
            {
                context.StockMedicines.Remove(Skladlek);
                context.SaveChanges();
                dg1.ItemsSource = context.StockMedicines.ToList();
                vyborlek.SelectedItem = null;
                vyborskl.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные");
            }
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Close();
        }

        private void vyborlek_selected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyborskl_selected(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
