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

            var list_pie = (from banh in DataProvider.Ins.DB.BANHs
                            join ct in DataProvider.Ins.DB.CT_DONHANG on banh.MABANH equals ct.MABANH
                            where ct.MA_DONHANG.Equals(id)
                            select new { ct.STT, banh.TENBANH, ct.SL_MUA, THANHTIEN = ct.SL_MUA * banh.DONGIA, banh.DVT, banh.DONGIA });
            detail.ItemsSource = list_pie.ToList();
            Sum_Bill.Content = $"{string.Format("{0:n0}", list_pie.Select(tongtien => tongtien.THANHTIEN).Sum())} VNĐ";

            var date_detallbill = (from dh in DataProvider.Ins.DB.DONHANGs
                                   where dh.MA_DONHANG.Equals(id)
                                   select new { dh.NG_DATHANG }).ToList();

            Date_Bill.Content = $"{string.Format("{0:dd/MM/yyyy}", date_detallbill[0].NG_DATHANG)}";
        }

        private void Drag_Move(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_BillDetail(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
