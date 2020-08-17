using CakeShop.SQL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UpdateCake.xaml
    /// </summary>
    public partial class UpdateCake : Window
    {
        private BANH cake;

        public UpdateCake()
        {
            InitializeComponent();
        }

        public UpdateCake(BANH cake)
        {
            this.cake = cake;
            InitializeComponent();

        }

        private void out_button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = cake;
        }
        private void updateClick(object sender, RoutedEventArgs e)
        {
            if (cake.TENBANH.Trim().Length == 0 || cake.THONGTIN.Trim().Length == 0 || cake.SL_TON == 0 || cake.DONGIA == 0 || cake.DVT.Trim().Length == 0  )
            {
                MessageBox.Show("Chưa đầy đủ thông tin", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(name.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa có tên bánh", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }    
            else if (mota.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa có thông tin bánh", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (unit.Text.Trim().Length == 0)
            {
                {
                    MessageBox.Show("Chưa nhập đơn vị tính", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (cake.DONGIA <= 0) 
            {
                MessageBox.Show("Sai định dạng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }    
            else
            {
                cake.TENBANH = name.Text.Trim();
                cake.THONGTIN = mota.Text.Trim();
                cake.SL_TON = Convert.ToDouble(count.Text.Trim());
                cake.DONGIA = Convert.ToDouble(price.Text.Trim());
                cake.DVT = unit.Text.Trim();
                DataProvider.Ins.DB.SaveChanges();
                this.Close();
            }
        }
    }
}
