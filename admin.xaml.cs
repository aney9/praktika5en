using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using Newtonsoft.Json;
using System.IO;

namespace praktika5
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        List<string> list = new List<string> {"Роли","Логины","Клиенты","Статус","Заказы","Услуги","ЗаказУслуги","Лекарства","ЗаказЛекарства",
            "Склад","СкладЛекарства","Стоматологии","Тип докторов","Врачи","КлиентВрач","Чек","ЗаказЧек"};
        public admin()
        {
            InitializeComponent();
            vybor.ItemsSource = list;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vybor.SelectedItem == list[0]) 
            {
                roles roles = new roles();
                roles.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[1])
            {
                logins login = new logins();
                login.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[2])
            {
                client client = new client();
                client.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[3])
            {
                status status = new status();
                status.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[4])
            {
                orders orders = new orders();
                orders.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[5])
            {
                uslugi uslugi = new uslugi();
                uslugi.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[6])
            {
                orderusl orderusl = new orderusl();
                orderusl.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[7])
            {
                lekarstva lekarstva = new lekarstva();
                lekarstva.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[8])
            {
                orderlek orderlek = new orderlek();
                orderlek.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[9])
            {
                sklad sklad = new sklad();
                sklad.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[10])
            {
                skladlek skladlek = new skladlek();
                skladlek.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[11])
            {
                stomatologii stomatologii = new stomatologii();
                stomatologii.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[12])
            {
                typedoctors typedoctors = new typedoctors();
                typedoctors.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[13])
            {
                doctors doctors = new doctors();
                doctors.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[14])
            {
                clientdoc clientdoc = new clientdoc();
                clientdoc.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[15])
            {
                bill bill = new bill();
                bill.Show();
                this.Close();
            }
            if (vybor.SelectedItem == list[16])
            {
                ordersbill ordersbill = new ordersbill();
                ordersbill.Show();
                this.Close();
            }

        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            var backupPath = @"C:\Users\Public\backup\Backup.bak";
            using (var dbContext = new DentistryEntities1())
            {
                try
                {
                    var sqlCommand = $"BACKUP DATABASE {dbContext.Database.Connection.Database} TO DISK = '{backupPath}'";

                    dbContext.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sqlCommand);
                    MessageBox.Show("Резервная копия базы данных успешно создана.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании резервной копии: {ex.Message}");
                }
            }
        }

        private void import(object sender, RoutedEventArgs e)
        {
            var filePath = @"C:\Users\nitz4\Desktop\import.json";

            if (!File.Exists(filePath))//проверка на существование файла
            {
                MessageBox.Show("Файл не найден.");
                return;
            }

            using (var dbContext = new DentistryEntities1())
            {
                var json = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<List<Roles>>(json);
                var data1 = JsonConvert.DeserializeObject<List<TypeOfDoctor>>(json);
                var data2 = JsonConvert.DeserializeObject<List<Statuss>>(json);

                foreach (var item in data)//Импортирует данные в таблицу
                {
                    dbContext.Roles.Add(item);
                }
                foreach (var item in data1)
                {
                    dbContext.TypeOfDoctor.Add(item);
                }
                foreach (var item in data2)
                {
                    dbContext.Statuss.Add(item);
                }
                try
                {
                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно импортированы в таблицы (Роль, статус, тип доктора)");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Имя ошибки: {validationError.PropertyName}\nОшибка: {validationError.ErrorMessage}");
                        }
                    }
                }
            }
        }

        private void check(object sender, RoutedEventArgs e)
        {
            var filePath = @"C:\Users\nitz4\Desktop\check.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (var dbContext = new DentistryEntities1())
                {
                    var data = dbContext.Bill.ToList();

                    foreach (var item in data)
                    {
                        writer.WriteLine($"ID: {item.ID_bill}, Сумма покупки: {item.PurchaseAmount}, ID клиента: {item.Clients_ID}, ID доктора: {item.Doctor_ID}, ID стоматологии: {item.Dentistry_ID}");
                    }
                }
            }

            MessageBox.Show("Данные успешно экспортированы в TXT файл.");
        }
    }
}
