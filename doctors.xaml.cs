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
    /// Логика взаимодействия для doctors.xaml
    /// </summary>
    public partial class doctors : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public doctors()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Doctors.ToList();
            vybortype.ItemsSource = context.TypeOfDoctor.ToList();
            vybortype.SelectedValuePath = "ID_typeofdoctor";
            vybortype.DisplayMemberPath = "typeofdoctors";
            vyborlogin.ItemsSource = context.LoginPassword.Where(r => r.roles_ID == 2).ToList();
            vyborlogin.SelectedValuePath = "ID_loginpassword";
            vyborlogin.DisplayMemberPath = "loginvhod";
            vyboradres.ItemsSource = context.Dentistry.ToList();
            vyboradres.SelectedValuePath = "ID_dentistry";
            vyboradres.DisplayMemberPath = "AddressDentistry";
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Doctors)dg1.SelectedItem;
            if (proverka != null)
            {
                imya.Text = proverka.DoctorName.ToString();
                fam.Text = proverka.DoctorSurname.ToString();
                otch.Text = proverka.DoctorMiddlename.ToString();
                vybortype.SelectedValue = proverka.TypeOfDoctor_ID;
                vyborlogin.SelectedValue = proverka.loginpassword_ID;
                vyboradres.SelectedValue = proverka.Dentistry_ID;
            }
        }

        private void vybortype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyborlogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyboradres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dob(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(imya.Text) || string.IsNullOrWhiteSpace(fam.Text) || vyborlogin.SelectedItem == null || vyboradres.SelectedItem == null || vybortype.SelectedItem == null)
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (context.Doctors.Any(r => r.loginpassword_ID == ((LoginPassword)vyborlogin.SelectedItem).ID_loginpassword))
                {
                    MessageBox.Show("Такой логин привязан к аккаунту");
                }
                else
                {
                    Doctors doctor = new Doctors();
                    doctor.DoctorSurname = fam.Text;
                    doctor.DoctorName = imya.Text;
                    doctor.DoctorMiddlename = otch.Text;
                    if (vybortype.SelectedItem != null)
                    {
                        var vyborType = (TypeOfDoctor)vybortype.SelectedItem;
                        doctor.TypeOfDoctor_ID = vyborType.ID_typeofdoctor;
                    }
                    if (vyborlogin.SelectedItem != null)
                    {
                        var vyborLogin = (LoginPassword)vyborlogin.SelectedItem;
                        doctor.loginpassword_ID = vyborLogin.ID_loginpassword;
                    }
                    if (vyboradres.SelectedItem != null)
                    {
                        var vyborAdres = (Dentistry)vyboradres.SelectedItem;
                        doctor.Dentistry_ID = vyborAdres.ID_dentistry;
                    }
                    context.Doctors.Add(doctor);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Doctors.ToList();
                    imya.Text = null;
                    fam.Text = null;
                    otch.Text = null;
                    vybortype.SelectedItem = null;
                    vyborlogin.SelectedItem = null;
                    vyboradres.SelectedItem = null;
                }
            }
        }

        private void izm(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(imya.Text) || string.IsNullOrWhiteSpace(fam.Text) || vyborlogin.SelectedItem == null || vyboradres.SelectedItem == null || vybortype.SelectedItem == null)
                {
                    MessageBox.Show("Пустое поле");
                }
                else
                {
                    Doctors doctor = dg1.SelectedItem as Doctors;
                    var selectedLogin = (LoginPassword)vyborlogin.SelectedItem;
                    var vyborType = (TypeOfDoctor)vybortype.SelectedItem;
                    var vyborAdres = (Dentistry)vyboradres.SelectedItem;
                    if (doctor.loginpassword_ID != selectedLogin.ID_loginpassword)
                    {
                        MessageBox.Show("Такой логин привязан к аккаунту");
                    }
                    else
                    {
                        doctor.DoctorSurname = fam.Text;
                        doctor.DoctorName = imya.Text;
                        doctor.DoctorMiddlename = otch.Text;
                        doctor.TypeOfDoctor_ID = vyborType.ID_typeofdoctor;
                        doctor.loginpassword_ID = selectedLogin.ID_loginpassword;
                        doctor.Dentistry_ID = vyborAdres.ID_dentistry;
                        context.SaveChanges();
                        dg1.ItemsSource = context.Doctors.ToList();
                        imya.Text = null;
                        fam.Text = null;
                        otch.Text = null;
                        vybortype.SelectedItem = null;
                        vyborlogin.SelectedItem = null;
                        vyboradres.SelectedItem = null;
                    }
               
                }
            }
            else
            {
                MessageBox.Show("Выберите или введите данные");
            }
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem != null)
            {
                Doctors vyborudal1 = dg1.SelectedItem as Doctors;
                int selected = vyborudal1.ID_doctors;
                var count = context.Bill.Count(lp => lp.Doctor_ID == selected);
                if (count > 0)
                {
                    MessageBox.Show("Эта строка используется в другой таблице");
                }
                else
                {
                    context.Doctors.Remove(vyborudal1);
                    context.SaveChanges();
                    dg1.ItemsSource = context.Doctors.ToList();

                }
                imya.Text = null;
                fam.Text = null;
                otch.Text = null;
                vybortype.SelectedItem = null;
                vyborlogin.SelectedItem = null;
                vyboradres.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Выберите или введите данные");
            }
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Close();
        }
        private void proverkaim(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 25)
            {
                MessageBox.Show("Много слишком символов");
                imya.Text = null;
            }
        }
        private void proverkaim1(object sender, System.Windows.Input.TextCompositionEventArgs e)
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

        private void proverkafam(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 25)
            {
                MessageBox.Show("Много слишком символов");
                fam.Text = null;
            }
        }
        private void proverkafam1(object sender, System.Windows.Input.TextCompositionEventArgs e)
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

        private void proverkaotch(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 25)
            {
                MessageBox.Show("Много слишком символов");
                otch.Text = null;
            }
        }
        private void proverkaotch1(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
