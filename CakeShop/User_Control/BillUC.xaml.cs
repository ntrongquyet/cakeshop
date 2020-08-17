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
        public class tempDetailCake
        {
            private string tenbanh;
            private string mabanh;
            private int soluong;
            private double thanhtien;
            private string hinhanh;
            public string Tenbanh { get => tenbanh; set => tenbanh = value; }
            public string Mabanh { get => mabanh; set => mabanh = value; }
            public int Soluong { get => soluong; set => soluong = value; }
            public double Thanhtien { get => thanhtien; set => thanhtien = value; }
            public string Hinhanh { get => hinhanh; set => hinhanh = value; }
        }
        List<tempDetailCake> listCake = new List<tempDetailCake>();
        public BillUC()
        {
            InitializeComponent();
        }
        List<BANH> tempList = new List<BANH>();
        private void order_button(object sender, MouseButtonEventArgs e)
        {
            DataContext = new BillUC();
            this.Content = new BillUC();
        }
        private void UC_Loaded(object sender, RoutedEventArgs e)
        {
            tempList = DataProvider.Ins.DB.BANHs.ToList();
            Listbox_Cake.ItemsSource = tempList;
        }
        int amount = 0;
        double total = 0;
        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var data = Listbox_Cake.SelectedItem as BANH;
            if (data != null)
            {
                DetailCake dt = new DetailCake(data.MABANH);
                if (dt.ShowDialog() == true)
                {
                    amount = dt.amount;

                }
                if (amount > 0)
                {
                    addCakeToBill(data.MABANH);
                }
            }
        }
        // Thêm bánh vào danh sách mua
        void addCakeToBill(string idCake)
        {
            BANH cake = DataProvider.Ins.DB.BANHs.ToList().Find(x => x.MABANH == idCake);
            if (amount > cake.SL_TON)
            {
                MessageBox.Show($"Không đủ số lượng yêu cầu \nSố lượng trong kho còn: {cake.SL_TON}");
            }
            else
            {
                tempDetailCake temp = new tempDetailCake()
                {

                    Mabanh = cake.MABANH,
                    Soluong = amount,
                    Thanhtien = amount * (double)cake.DONGIA,
                    Tenbanh = cake.TENBANH,
                    Hinhanh = cake.HA_BANH,
                };

                var exist = checkCakeExsit(temp.Mabanh);
                // Nếu chưa tồn tại thì add vào list
                if (exist == null)
                {
                    cart.Items.Add(temp);
                    listCake.Add(temp);
                    displayMoney(listCake);
                }
                // Ngược lại đã tồn tại
                else
                {
                    var result = MessageBox.Show($"{cake.TENBANH} đã tồn tại trong đơn hàng, bạn muốn sửa số lượng?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        cart.Items.Remove(exist);
                        listCake.Remove(exist);
                        displayMoney(listCake);
                        DetailCake dt = new DetailCake(idCake, amount);
                        if (dt.ShowDialog() == true)
                        {
                            amount = dt.amount;

                        }
                        if (amount > 0)
                        {
                            addCakeToBill(idCake);
                        }
                    }
                }
            }

        }
        // Tính tổng tiền và hiện thị số tiền
        void displayMoney(List<tempDetailCake> ls)
        {
            total = ls.Select(x => x.Thanhtien).Sum();
            totalMoney.Text = $"{string.Format("{0:n0}", total)} VNĐ";
        }
        // Kiểm tra sự tồn tại của sản phẩm trong giỏ hàng
        tempDetailCake checkCakeExsit(string idCake)
        {
            bool exsit = listCake.Any(x => x.Mabanh == idCake);
            if (exsit == true)
            {
                return listCake.Find(x => x.Mabanh == idCake);
            }
            return null;
        }
        private void Button_CupCake(object sender, MouseButtonEventArgs e)
        {
            tempList = DataProvider.Ins.DB.LOAIBANHs.Find("LB001").BANHs.ToList();
            Listbox_Cake.ItemsSource = tempList;
        }

        private void Button_CreamCake(object sender, MouseButtonEventArgs e)
        {
            tempList = DataProvider.Ins.DB.LOAIBANHs.Find("LB002").BANHs.ToList();
            Listbox_Cake.ItemsSource = tempList;
        }

        private void Button_BiscuitCake(object sender, MouseButtonEventArgs e)
        {
            tempList = DataProvider.Ins.DB.LOAIBANHs.Find("LB003").BANHs.ToList();
            Listbox_Cake.ItemsSource = tempList;
        }

        private void Button_IceCream(object sender, MouseButtonEventArgs e)
        {
            tempList = DataProvider.Ins.DB.LOAIBANHs.Find("LB004").BANHs.ToList();
            Listbox_Cake.ItemsSource = tempList;
        }

        private void Button_ShowAllCake(object sender, MouseButtonEventArgs e)
        {
            tempList = DataProvider.Ins.DB.BANHs.ToList();
            Listbox_Cake.ItemsSource = tempList;
        }
        private void Search_button(object sender, RoutedEventArgs e)
        {
            var text = Search.Text.Trim();
            if (text == "")
            {
                Listbox_Cake.ItemsSource = DataProvider.Ins.DB.BANHs.ToList();
            }
            else
            {
                var dbBanh = DataProvider.Ins.DB.BANHs; // List sử dụng để lưu tạm các loại bánh
                Listbox_Cake.ItemsSource = tempList.Where(q => (q.MABANH + q.TENBANH)
                        .ToLower()
                        .Contains(text.ToLower()));
            }
        }

        private void payClick(object sender, RoutedEventArgs e)
        {
            string maDonHang = $"DH{DataProvider.Ins.DB.DONHANGs.Count() + 1}";

            //Tạo đơn hàng
            DONHANG dh = new DONHANG()
            {
                ID = DataProvider.Ins.DB.DONHANGs.Count() + 1,
                MA_DONHANG = maDonHang,
                NG_DATHANG = DateTime.Now,
                TONG_GTDH = total,
            };
            int i = 0;
            foreach (tempDetailCake item in listCake)
            {
                i++; // Lấy stt cho danh sách món hàng
                BANH banh = DataProvider.Ins.DB.BANHs.ToList().Find(x => x.MABANH == item.Mabanh);
                banh.SL_TON -= amount;
                CT_DONHANG cT = new CT_DONHANG()
                {
                    MA_DONHANG = dh.MA_DONHANG,
                    ID = DataProvider.Ins.DB.CT_DONHANG.Count() + 1,
                    SL_MUA = item.Soluong,
                    MABANH = item.Mabanh,
                    STT = i,
                    DONHANG = dh,
                    BANH = banh,
                };
                dh.CT_DONHANG.Add(cT);
            }
            if (dh.TONG_GTDH == 0)
            {
                MessageBox.Show("Bạn chưa thêm sản phẩm, hãy thêm sản phẩm để thanh toán!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DataProvider.Ins.DB.DONHANGs.Add(dh);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show($"Thanh toán đơn hàng {dh.MA_DONHANG} thành công với tổng đơn hàng là {string.Format("{0:n0}", dh.TONG_GTDH)} VNĐ", "Thanh toán thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            reset();
        }
        // Hàm reset giá trị 
        void reset()
        {
            cart.Items.Clear();
            listCake.Clear();
            displayMoney(listCake);
        }
        private void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            var item = cart.SelectedItem as tempDetailCake;
            cart.Items.Remove(item);
            listCake.Remove(item);
            displayMoney(listCake);
        }
    }
}