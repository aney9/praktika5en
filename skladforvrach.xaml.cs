﻿using System;
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
    /// Логика взаимодействия для skladforvrach.xaml
    /// </summary>
    public partial class skladforvrach : Window
    {
        private DentistryEntities1 context = new DentistryEntities1();
        public skladforvrach()
        {
            InitializeComponent();
            dg1.ItemsSource = context.Stock.ToList();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            vrach vrach = new vrach();
            vrach.Show();
            this.Close();
        }
    }
}
