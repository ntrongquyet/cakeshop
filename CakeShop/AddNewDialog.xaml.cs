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

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for AddNewDialog.xaml
    /// </summary>
    public partial class AddNewDialog : Window
    {
        public AddNewDialog()
        {
            InitializeComponent();
        }

        private void Out_button(object sender, RoutedEventArgs e)
        {
              this.Close();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Image_Button(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Đã Click");
        }
    }
}
