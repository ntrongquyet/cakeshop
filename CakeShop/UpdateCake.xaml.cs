using CakeShop.SQL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for UpdateCake.xaml
    /// </summary>
    public partial class UpdateCake : Window
    {
        private BANH cake;
        BANH temp;

        //public UpdateCake()
        //{
        //    InitializeComponent();
        //}

        public UpdateCake(BANH _cake)
        {
            cake = _cake;

            InitializeComponent();

        }

        private void out_button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = cake;
            temp = DataProvider.Ins.DB.BANHs.ToList().Find(x => x.MABANH.Equals(cake.MABANH));
        }


        private void updateClick(object sender, RoutedEventArgs e)
        {

            cake.TENBANH = name.Text.Trim();
            cake.THONGTIN = mota.Text.Trim();
            cake.SL_TON = Convert.ToDouble(count.Text.Trim());
            cake.DONGIA = Convert.ToDouble(price.Text.Trim());
            cake.DVT = unit.Text.Trim();
            DataProvider.Ins.DB.SaveChanges();
            this.Close();

        }

        private void Drag_Move(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
