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
        string pathImage = ""; // Lưu đường dẫn bánh

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = cake;
        }

        private void editImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == true)
            {
                pathImage = ofd.FileName;
            }
            if (pathImage != "")
            {
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(pathImage);
                logo.EndInit();
                cakeImage.Source = logo;
            }
        }
        string createLinkImage(string path)
        {
            var temp = cake.LOAIBANH1.TENLOAI;
            var info = new FileInfo(pathImage);
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            baseFolder += $"Image\\{cake.LOAIBANH1.TENLOAI.Replace(" ", "")}\\";
            string nameImage = Guid.NewGuid().ToString();
            File.Copy(pathImage, baseFolder + nameImage + info.Extension);
            return $"{temp.Replace(" ", "")}\\{ nameImage + info.Extension}";
        }
        private void updateClick(object sender, RoutedEventArgs e)
        {
            cake.TENBANH = name.Text.Trim();
            cake.THONGTIN = mota.Text.Trim();
            cake.SL_TON = Convert.ToDouble(price.Text.Trim());
            var nameImage = createLinkImage(pathImage);
            string oldImage = $"{AppDomain.CurrentDomain.BaseDirectory}Image\\{ cake.HA_BANH}";
            cake.HA_BANH = nameImage;
            DataProvider.Ins.DB.SaveChanges();
            //Chỗ này đang lỗi từ từ t sửa
            //File.Delete(oldImage);
        }

        private void Drag_Move(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
