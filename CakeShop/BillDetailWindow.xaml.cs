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
using System.Windows.Shapes;

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for BillDetailWindow.xaml
    /// </summary>
    public partial class BillDetailWindow : Window
    {
        private List<CT_DONHANG> list;

        public BillDetailWindow()
        {
            InitializeComponent();
        }

        public BillDetailWindow(List<CT_DONHANG> list)
        {
            this.list = list;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = list;
            string id = list[0].MA_DONHANG;
            detail.ItemsSource = (from banh in DataProvider.Ins.DB.BANHs
                                  join ct in DataProvider.Ins.DB.CT_DONHANG on banh.MABANH equals ct.MABANH
                                  where ct.MA_DONHANG.Equals(id)
                                  select new { ct.STT, banh.TENBANH, ct.SL_MUA, THANHTIEN = ct.SL_MUA * banh.DONGIA }).ToList();
        }
    }
}
