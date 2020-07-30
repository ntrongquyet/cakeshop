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

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for DetailCake.xaml
    /// </summary>
    public partial class DetailCake : Window
    {
        private string mABANH;

        public DetailCake(string mABANH)
        {
            InitializeComponent();
            this.mABANH = mABANH;
        }

        private void Out_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var listcake = (from cake in DataProvider.Ins.DB.BANHs
                            where cake.MABANH == mABANH
                            select cake);
        }
    }
}
