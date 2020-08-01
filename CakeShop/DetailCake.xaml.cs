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
using CakeShop.SQL;
using System.Text.RegularExpressions;

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for DetailCake.xaml
    /// </summary>
    public partial class DetailCake : Window
    {
        private string mABANH;

        //Khai báo biến số lượng
        private int _numValue = 0;
        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                price.Text = value.ToString();
            }
        }

        public DetailCake(string mABANH)
        {
            InitializeComponent();
            this.mABANH = mABANH;
            price.Text = _numValue.ToString();
        }

        private void Out_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = DataProvider.Ins.DB.BANHs.Find(mABANH);
            
        }

        private void Drag_Window(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Hàm ngăn không cho nhập các chữ cái "a, b, c"
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //Giảm số lượng không cho giảm đến âm
        private void div_quality(object sender, MouseButtonEventArgs e)
        {
            if(int.Parse(price.Text) <= 0)
            {
                NumValue = 0;
            }
            else
            {
                NumValue--;
            }
        }

        //Tăng số lượng
        private void add_quality(object sender, MouseButtonEventArgs e)
        {
            NumValue++;
          
        }

        //Hàm cập nhật lại số lượng
        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (price == null)
            {
                return;
            }

            if (!int.TryParse(price.Text, out _numValue))
                price.Text = _numValue.ToString();
        }
    }
}
