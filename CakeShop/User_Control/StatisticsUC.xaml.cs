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
using CakeShop.SQL;
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using Microsoft.SqlServer.Server;

namespace CakeShop.User_Control
{
    /// <summary>
    /// Interaction logic for StatisticsUC.xaml
    /// </summary>
    public partial class StatisticsUC : UserControl
    {
        public SeriesCollection SeriesCollection_MoneyPerDay { get; }
        public SeriesCollection SeriesCollection_MoneyPerMonth { get; set; }
        public List<string> Labels { get; set; } = new List<string>();
        string yearDefault = "2020";
        
        public StatisticsUC()
        {
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
                    Values = amount, // show số lượng tồn                         
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
            for (int i = 0 ; i < sum.Length; i++)
            {
                ColumnSeries series;
                if (sum[i] > 0)
                {
                    ChartValues<double> moneyOfMonth = new ChartValues<double>();
                    moneyOfMonth.Add(sum[i]);
                    series = new ColumnSeries
                    {
                        Title = $"Tháng {i+1}",
                        Values = moneyOfMonth// show số lượng tồn                         

                    };
                    SeriesCollection_MoneyPerMonth.Add(series);

                }

            }



        }
        public void Chart()
        {
            // Hiện thị biểu đồ doanh thu tháng
            var listOfMonth = DataProvider.Ins.DB.DONHANGs.ToList(); // Danh sách tất cả các đơn hàng
            double[] sum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // Tính tổng số tiền thu được theo từng tháng
            foreach (DONHANG item in listOfMonth)
            {
                var getMonth = item.NG_DATHANG.Value.ToString("MM");
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
                        Values = moneyOfMonth// show số lượng tồn                         

                    };
                    SeriesCollection_MoneyPerMonth.Add(series);

                }

            }
        }
        /// <summary>
        /// Khởi động usercontrol
        /// </summary>
        public void UserControl_Initialized(object sender, EventArgs e)
        {
            // Hiện thị lựa chọn tháng
            year.ItemsSource = new string[] {
                "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2023", "2024", "2025" };
            // Hiện thị đơn hàng bán được trong ngày
            var dateNow = DateTime.Now.ToString("d");
            DateTime dateTime = Convert.ToDateTime(dateNow);
            totalBillInDay.Content = (from dh in DataProvider.Ins.DB.DONHANGs
                                      where dh.NG_DATHANG == dateTime
                                      select dh).Count();
            // Hiện thị số tiền trong 1 ngày
            totalMoneyInDay.Content = (from dh in DataProvider.Ins.DB.DONHANGs
                                       where dh.NG_DATHANG == dateTime
                                       select dh.TONG_GTDH).Sum();
        }

        private void changeYear_Click(object sender, RoutedEventArgs e)
        {
            yearDefault = year.SelectedValue.ToString();
            Chart();
        }
    }
}
