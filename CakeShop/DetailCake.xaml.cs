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

        public int amount { get => _numValue; set => _numValue = value; }

        public DetailCake(string mABANH)
        {
            InitializeComponent();
            this.mABANH = mABANH;
            price.Text = _numValue.ToString();
        }

        public DetailCake(string mABANH, int amount) : this(mABANH)
        {
            this.amount = amount;
        }

        private void Out_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = DataProvider.Ins.DB.BANHs.Find(mABANH);
            if (amount != 0)
            {
                price.Text = amount.ToString();
            }
            
        }

        private void Drag_Window(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Hàm ngăn không cho nhập ký tự khác số nguyên "a, b, c,..."
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (int.Parse(price.Text) == 0)
            {
                price.Text = "";
            }
        }

        //Button giảm số lượng
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

        //Button tăng số lượng
        private void add_quality(object sender, MouseButtonEventArgs e)
        {
            NumValue++;
        }

        // Tăng giảm số lượng từ bàn phím "lên, xuống"
        private void Div_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (int.Parse(price.Text) <= 0)
                {
                    NumValue = 0;
                }
                else 
                {
                    NumValue--;
                }
            }
            else if (e.Key == Key.Up)
            {
                NumValue++;
            }
            else
            {
                NumValue = int.Parse(price.Text);
            }
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

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
