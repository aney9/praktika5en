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
    /// Логика взаимодействия для typedoctors.xaml
    /// </summary>
    public partial class typedoctors : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public typedoctors()
        {
            InitializeComponent();
            dg1.ItemsSource = context.TypeOfDoctor.ToList();
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (TypeOfDoctor)dg1.SelectedItem;
            if (proverka != null)
            {
                type.Text = proverka.typeofdoctors.ToString();
            }
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(type.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.TypeOfDoctor.Any(r => r.typeofdoctors == type.Text))
                {
                    MessageBox.Show("Такой тип доктора уже существует");
                    type.Text = null;
                }
                else
                {
                    if (type.Text.Length > 5 && type.Text.Length < 25)
                    {
                        TypeOfDoctor typee = new TypeOfDoctor();
                        typee.typeofdoctors = type.Text;
                        context.TypeOfDoctor.Add(typee);
                        context.SaveChanges();
                        dg1.ItemsSource = context.TypeOfDoctor.ToList();
                        type.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Тип врача должен быть больше 5 букв и меньше 30");
                    }
                }
            }
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            if(dg1.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(type.Text))
                {
                    MessageBox.Show("Пустое поле");
                }
                else
                {
                    if (context.TypeOfDoctor.Any(r => r.typeofdoctors == type.Text))
                    {
                        MessageBox.Show("Такая роль уже существует");
                        type.Text = null;
                    }
                    else
                    {
                        if (type.Text.Length > 5 && type.Text.Length < 25)
                        {

                            var typee = dg1.SelectedItem as TypeOfDoctor;
                            typee.typeofdoctors = type.Text;
                            context.SaveChanges();
                            dg1.ItemsSource = context.TypeOfDoctor.ToList();
                            type.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("Тип врача должен быть больше 5 букв и меньше 30");
                        }
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
                TypeOfDoctor vyborudal1 = dg1.SelectedItem as TypeOfDoctor;

                int selectedRoleId = vyborudal1.ID_typeofdoctor;
                var count = context.Doctors.Count(lp => lp.TypeOfDoctor_ID == selectedRoleId);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.TypeOfDoctor.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.TypeOfDoctor.ToList();
                    type.Text = null;
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
