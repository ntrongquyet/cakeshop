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
    public partial class statisticsuc : Usercontrol
    {
        //public seriescollection seriescollection_moneyperday { get; }
        //public seriescollection seriescollection_typeofcake { get; set; }

        //public seriescollection seriescollection_moneypermonth { get; set; }
        //public list<string> labels { get; set; } = new list<string>();

        public statisticsuc()
        {
            Initializecomponent();
            // xuất biểu đồ số loại bánh còn tồn kho
            //seriescollection_moneyperday = new seriescollection();
            //var listinventory = from banh in dataprovider.ins.db.banhs
            //                    where banh.sl_ton > 0
            //                    select banh;
            //foreach (banh item in listinventory)
            //{
            //    chartvalues<int> amount = new chartvalues<int>();
            //    amount.add(convert.toint32(item.sl_ton));
            //    pieseries series = new pieseries
            //    {
            //        values = amount,
            //        title = item.tenbanh,
            //    };
            //    seriescollection_moneyperday.add(series);
            //}
            //// hiện thị biểu đồ doanh thu tháng
            //var listofmonth = dataprovider.ins.db.donhangs.tolist(); // danh sách tất cả các đơn hàng
            //double[] sum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //// tính tổng số tiền thu được theo từng tháng
            //foreach (donhang item in listofmonth)
            //{
            //    var getmonth = item.ng_dathang.value.tostring("mm");
            //    var yeardefault = "2020";
            //    var getyear = item.ng_dathang.value.tostring("yyyy");
            //    if (getyear == yeardefault)
            //    {
            //        sum[convert.toint32(getmonth) - 1] += convert.todouble(item.tong_gtdh);

            //    }
            //}
            //seriescollection_moneypermonth = new seriescollection();
            //for (int i = 0; i < sum.length; i++)
            //{
            //    columnseries series;
            //    if (sum[i] > 0)
            //    {
            //        chartvalues<double> moneyofmonth = new chartvalues<double>();
            //        moneyofmonth.add(sum[i]);
            //        series = new columnseries
            //        {
            //            title = $"tháng {i + 1}",
            //            values = moneyofmonth

            //        };
            //        seriescollection_moneypermonth.add(series);
            //        labels.add("2020");
            //    }

            //}
            //chart();
        }

        private void Initializecomponent()
        {
            throw new NotImplementedException();
        }


        //public void chart()
        //{
        //    seriescollection_typeofcake = new seriescollection();

        //    var db = dataprovider.ins.db;

        //    var list = (from ctdh in db.ct_donhang
        //                join banh in db.banhs on ctdh.mabanh equals banh.mabanh
        //                select new { banh.loaibanh, total = ctdh.sl_mua * banh.dongia });
        //    var result = (from l in list
        //                  join lb in db.loaibanhs on l.loaibanh equals lb.maloai
        //                  select new { lb.tenloai, l.total });
        //    var finallist = (from rs in result
        //                     group rs by rs.tenloai into rsgroup
        //                     select new
        //                     {
        //                         name = rsgroup.key,
        //                         totalmoney = rsgroup.sum(x => x.total)
        //                     }).tolist();
        //    for (int i = 0; i < finallist.count; i++)
        //    {
        //        chartvalues<int> amount = new chartvalues<int>();
        //        amount.add(convert.toint32(finallist[i].totalmoney));
        //        pieseries series = new pieseries
        //        {
        //            values = amount,
        //            title = finallist[i].name,
        //        };
        //        seriescollection_typeofcake.add(series);
        //    }
        //}
        ///// <summary>
        ///// khởi động usercontrol
        ///// </summary>
        //public void usercontrol_initialized(object sender, eventargs e)
        //{
        //    // hiện thị đơn hàng bán được trong ngày
        //    var datenow = datetime.now.tostring("d");
        //    datetime datetime = convert.todatetime(datenow);
        //    totalbillinday.content = (from dh in dataprovider.ins.db.donhangs
        //                              where dh.ng_dathang == datetime
        //                              select dh).count();
        //    // hiện thị số tiền trong 1 ngày
        //    var total = (from dh in dataprovider.ins.db.donhangs
        //                 where dh.ng_dathang == datetime
        //                 select dh.tong_gtdh).sum();
        //    totalmoneyinday.text = $"{string.format("{0:n0}", total)} vnđ";
        //    if (totalmoneyinday.text == null)
        //    {
        //        totalmoneyinday.text = $"{string.format("{0:n0}", 0)} vnđ";
        //    }
        //    // hiện danh sách các loại bánh còn trong kho
        //    table_inventory.itemssource = (from banh in dataprovider.ins.db.banhs
        //                                   where banh.sl_ton > 0
        //                                   select banh).tolist();
        //}
    }
}
