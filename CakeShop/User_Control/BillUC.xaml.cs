using CakeShop.SQL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CakeShop.User_Control;
using System.Data.Entity;

namespace CakeShop.User_Control
{
    /// <summary>
    /// Interaction logic for BillUC.xaml
    /// </summary>
    public partial class BillUC : UserControl
    {
        public BillUC()
        {
            InitializeComponent();
        }

        private void Search_button(object sender, RoutedEventArgs e)
        {
         
        }

        private void UC_Loaded(object sender, RoutedEventArgs e)
        {
            var list = (from d in DataProvider.Ins.DB.BANHs
                        select d);
            Select_Food.ItemsSource = list.ToList();
        }

        private void bill_button(object sender, RoutedEventArgs e)
        {

        }

        private void ShowQuality(object sender, MouseButtonEventArgs e)
        {
            var data = Select_Food.SelectedItem as  BANH;
            DetailCake show_Detail = new DetailCake(data.MABANH);
            show_Detail.ShowDialog();
        }
    }
}
