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

namespace CakeShop.User_Control
{
    /// <summary>
    /// Interaction logic for SumBillUC.xaml
    /// </summary>
    public partial class SumBillUC : UserControl
    {
        public SumBillUC()
        {
            InitializeComponent();
        }
        List<DONHANG> list_donhang = new List<DONHANG>();
        private void SumBill_Loaded(object sender, RoutedEventArgs e)
        {
            list_donhang = DataProvider.Ins.DB.DONHANGs.ToList();
            Show_SumBill.ItemsSource = list_donhang;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = Show_SumBill.SelectedItem as DONHANG;
            var list = (from ct in DataProvider.Ins.DB.CT_DONHANG
                        where ct.MA_DONHANG.Equals(item.MA_DONHANG)
                        select ct).ToList();
            BillDetailWindow bill = new BillDetailWindow(list);
            bill.ShowDialog();
        }

    }
}
