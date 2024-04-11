using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для lekarstva.xaml
    /// </summary>
    public partial class lekarstva : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public lekarstva()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Medicines.ToList();
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Medicines)dg1.SelectedItem;
            if (proverka != null)
            {
                lek.Text = proverka.mediciness.ToString();
                price.Text = proverka.PriceMedicines.ToString();
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lek.Text) || string.IsNullOrWhiteSpace(price.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Medicines.Any(r => r.mediciness == lek.Text))
                {
                    MessageBox.Show("Такое лекарство уже существует");
                    lek.Text = null;
                    price.Text = null;
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
                        if (lek.Text.Length > 2 && lek.Text.Length <= 30)
                        {
                            Medicines med = new Medicines();
                            med.mediciness = lek.Text;
                            med.PriceMedicines = Price;
                            context.Medicines.Add(med);
                            context.SaveChanges();
                            dg1.ItemsSource = context.Medicines.ToList();
                            lek.Text = null;
                            price.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("Название лекарства должно быть больше 2 и меньше 30 символов");
                            lek.Text = null; 
                            price.Text = null;
                        }
                    }
                }

            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lek.Text) || string.IsNullOrWhiteSpace(price.Text))
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
                    if (lek.Text.Length > 2 && lek.Text.Length <= 30)
                    {
                        var leka = dg1.SelectedItem as Medicines;
                        if (!context.Medicines.Any(r => r.mediciness == lek.Text && r.ID_medicines != leka.ID_medicines))
                        {
                            leka.mediciness = lek.Text;
                            leka.PriceMedicines = Price;
                            context.SaveChanges();
                            dg1.ItemsSource = context.Medicines.ToList();
                            lek.Text = null;
                            price.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("Такое лекарство уже существует");
                            lek.Text = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Название лекарства должно быть больше 2 и меньше 30 символов");
                        lek.Text = null;
                        price.Text = null;
                    }
                }
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Medicines vyborudal1 = dg1.SelectedItem as Medicines;

                int selectedId = vyborudal1.ID_medicines;
                var count = context.OrdersMedicines.Count(lp => lp.medicines_ID == selectedId);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Medicines.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Medicines.ToList();
                    lek.Text = null;
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
        private void proverkaprice1(object sender, TextCompositionEventArgs e)
        {
            string newText = (sender as TextBox).Text + e.Text;
            if (!decimal.TryParse(newText, out _))
            {
                e.Handled = true;
            }
        }
        private void proverkalek1(object sender, TextCompositionEventArgs e)
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
