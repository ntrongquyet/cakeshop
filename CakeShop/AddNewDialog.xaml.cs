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
using CakeShop.SQL;
using CakeShop.User_Control;
using Microsoft.Win32;

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
        string pathImage = ""; // Lưu đường dẫn bánh

        //private void Drag_Window(object sender, MouseButtonEventArgs e)
        //{
        //    this.DragMove();
        //}

        private void Image_Button(object sender, MouseButtonEventArgs e)
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
        public int getIndexSelected(ItemCollection items)
        {
            int index = -1;

            foreach (RadioButton item in items)
            {
                index++;
                if (item.IsChecked == true)
                {
                    return index;

                }
            }
            return index;
        }
        protected LOAIBANH temp;
        private void Add_Button(object sender, RoutedEventArgs e)
        {
            
            double money = 0; // Lưu giá tiền
            int amount = 0; // Lưu số lượng bánh
            int.TryParse(count.Text.Trim(), out amount);
            double.TryParse(price.Text.Trim(), out money);
            if (temp == null)
            {
                MessageBox.Show("Chưa chọn loại bánh", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (name.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập tên bánh", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else if (ingredients.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập thông tin cho bánh", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            else if (amount == 0)
            {
                MessageBox.Show("Sai định dạng số lượng bánh", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else if (money == 0 && money < 1000)
            {
                MessageBox.Show("Sai định dạng số tiền", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else if (unit.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập đơn vị tính", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else if (pathImage == "")
            {
                MessageBox.Show("Chưa thêm hình ảnh cho bánh", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                var info = new FileInfo(pathImage);
                string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
                baseFolder += "Image\\Cakes\\";
                string nameImage = Guid.NewGuid().ToString();
                File.Copy(pathImage, baseFolder + nameImage + info.Extension);
                var newCake = new BANH
                {
                    ID = DataProvider.Ins.DB.BANHs.Count() + 1,
                    MABANH = $"BA{DataProvider.Ins.DB.BANHs.Count() + 1}",
                    TENBANH = name.Text.Trim(),
                    SL_TON = amount,
                    DONGIA = money,
                    DVT = unit.Text.Trim(),
                    HA_BANH = $"Cakes\\{nameImage}",
                    LOAIBANH = temp.MALOAI,
                    THONGTIN = ingredients.Text.Trim()



                };
                DataProvider.Ins.DB.BANHs.Add(newCake);
                DataProvider.Ins.DB.SaveChanges();
                resetTextBox();
                MessageBox.Show($"Thêm thành công món {newCake.TENBANH}", "Thành công", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }
        private void resetTextBox()
        {
            listCombobox.SelectedIndex = default;
            name.Text = default;
            ingredients.Text = default;
            count.Text = default;
            price.Text = default;
            unit.Text = default;
        }
        private void out_button(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listCombobox.ItemsSource = DataProvider.Ins.DB.LOAIBANHs.ToList();

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string name = "";
            if (((RadioButton)sender).IsChecked == true)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                name = rb.Content.ToString();
            }
            temp = DataProvider.Ins.DB.LOAIBANHs.ToList().Find(x=>x.TENLOAI == name);
        }
    }
}
