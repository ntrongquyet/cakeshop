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
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using CakeShop.SQL;

namespace CakeShop.User_Control
{
    /// <summary>
    /// Interaction logic for StatisticsUCVers2.xaml
    /// </summary>
    public partial class StatisticsUCVers2 : UserControl
    {
        public SeriesCollection SeriesCollection_MoneyPerDay { get; }
        public SeriesCollection SeriesCollection_TypeOfCake { get; set; }

        public SeriesCollection SeriesCollection_MoneyPerMonth { get; set; }
        public List<string> Labels { get; set; } = new List<string>();
        public StatisticsUCVers2()
        {
            InitializeComponent();
            InitializeComponent();
            // Xuất biểu đồ số loại bánh còn tồn kho
            SeriesCollection_MoneyPerDay = new SeriesCollection();
            var listInventory = from banh in DataProvider.Ins.DB.BANHs
                                where banh.SL_TON > 0
                                select banh;
            foreach (BANH item in listInventory)
            {
                ChartValues<int> amount = new ChartValues<int>();
                amount.Add(Convert.ToInt32(item.SL_TON));
                PieSeries series = new PieSeries
                {
                    Values = amount,
                    Title = item.TENBANH,
                };
                SeriesCollection_MoneyPerDay.Add(series);
            }
            // Hiện thị biểu đồ doanh thu tháng
            var listOfMonth = DataProvider.Ins.DB.DONHANGs.ToList(); // Danh sách tất cả các đơn hàng
            double[] sum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // Tính tổng số tiền thu được theo từng tháng
            foreach (DONHANG item in listOfMonth)
            {
                var getMonth = item.NG_DATHANG.Value.ToString("MM");
                var yearDefault = "2020";
                var getYear = item.NG_DATHANG.Value.ToString("yyyy");
                if (getYear == yearDefault)
                {
                    sum[Convert.ToInt32(getMonth) - 1] += Convert.ToDouble(item.TONG_GTDH);

                }
            }
            SeriesCollection_MoneyPerMonth = new SeriesCollection();
            for (int i = 0; i < sum.Length; i++)
            {
                ColumnSeries series;
                if (sum[i] > 0)
                {
                    ChartValues<double> moneyOfMonth = new ChartValues<double>();
                    moneyOfMonth.Add(sum[i]);
                    series = new ColumnSeries
                    {
                        Title = $"Tháng {i + 1}",
                        Values = moneyOfMonth

                    };
                    SeriesCollection_MoneyPerMonth.Add(series);
                    Labels.Add("2020");
                }

            }
            Chart();
        }
        public void Chart()
        {
            SeriesCollection_TypeOfCake = new SeriesCollection();

            var db = DataProvider.Ins.DB;

            var list = (from ctdh in db.CT_DONHANG
                        join banh in db.BANHs on ctdh.MABANH equals banh.MABANH
                        select new { banh.LOAIBANH, total = ctdh.SL_MUA * banh.DONGIA });
            var result = (from l in list
                          join lb in db.LOAIBANHs on l.LOAIBANH equals lb.MALOAI
                          select new { lb.TENLOAI, l.total });
            var finalList = (from rs in result
                             group rs by rs.TENLOAI into rsGroup
                             select new
                             {
                                 Name = rsGroup.Key,
                                 totalMoney = rsGroup.Sum(x => x.total)
                             }).ToList();
            for (int i = 0; i < finalList.Count; i++)
            {
                ChartValues<int> amount = new ChartValues<int>();
                amount.Add(Convert.ToInt32(finalList[i].totalMoney));
                PieSeries series = new PieSeries
                {
                    Values = amount,
                    Title = finalList[i].Name,
                };
                SeriesCollection_TypeOfCake.Add(series);
            }
        }
        /// <summary>
        /// Khởi động usercontrol
        /// </summary>
        public void UserControl_Initialized(object sender, EventArgs e)
        {
            // Hiện thị đơn hàng bán được trong ngày
            var dateNow = DateTime.Now.ToString("d");
            DateTime dateTime = Convert.ToDateTime(dateNow);
            totalBillInDay.Text = (from dh in DataProvider.Ins.DB.DONHANGs
                                      where dh.NG_DATHANG == dateTime
                                      select dh).Count().ToString();
            // Hiện thị số tiền trong 1 ngày
            var total = (from dh in DataProvider.Ins.DB.DONHANGs
                         where dh.NG_DATHANG == dateTime
                         select dh.TONG_GTDH).Sum();
            totalMoneyInDay.Text = $"{string.Format("{0:n0}", total)} VNĐ";
            if (totalMoneyInDay.Text == null)
            {
                totalMoneyInDay.Text = $"{string.Format("{0:n0}", 0)} VNĐ";
            }
            //Hiện danh sách các loại bánh còn trong kho
            table_Inventory.ItemsSource = (from banh in DataProvider.Ins.DB.BANHs
                                           where banh.SL_TON > 0
                                           select banh).ToList();
        }
    }
}
