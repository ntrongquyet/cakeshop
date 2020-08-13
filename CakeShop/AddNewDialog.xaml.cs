using System;
using System.Collections.Generic;
using System.IO;
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
using CakeShop.User_Control;
using Microsoft.Win32;

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for AddNewDialog.xaml
    /// </summary>
    public partial class AddNewDialog : Window
    {
        public AddNewDialog()
        {
            InitializeComponent();
        }

        private void Out_button(object sender, RoutedEventArgs e)
        {
              this.Close();
        }
        string pathImage = ""; // Lưu đường dẫn bánh

        //private void add_button(object sender, routedeventargs e)
        //{
        //    var id = listcombobox.selectedvalue as loaibanh; // lưu mã bánh
        //    double money = 0; // lưu giá tiền
        //    int amount = 0; // lưu số lượng bánh
        //    int.tryparse(count.text.trim(), out amount);
        //    double.tryparse(price.text.trim(), out money);
        //    if (listcombobox.selectedindex == -1)
        //    {
        //        messagebox.show("chưa chọn loại bánh", "lỗi", messageboxbutton.ok, messageboximage.warning);
        //    }
        //    else if (name.text.trim().length == 0)
        //    {
        //        messagebox.show("chưa nhập tên bánh", "lỗi", messageboxbutton.ok, messageboximage.warning);

        //    }
        //    else if (ingredients.text.trim().length == 0)
        //    {
        //        messagebox.show("chưa nhập thông tin cho bánh", "lỗi", messageboxbutton.ok, messageboximage.warning);

        //    }

        //    else if (amount == 0)
        //    {
        //        messagebox.show("sai định dạng số lượng bánh", "lỗi", messageboxbutton.ok, messageboximage.warning);

        //    }
        //    else if (money == 0 && money<1000)
        //    {
        //        messagebox.show("sai định dạng số tiền", "lỗi", messageboxbutton.ok, messageboximage.warning);

        //    }
        //    else if (unit.text.trim().length == 0)
        //    {
        //        messagebox.show("chưa nhập đơn vị tính", "lỗi", messageboxbutton.ok, messageboximage.warning);

        //    }
        //    else if (pathimage == "")
        //    {
        //        messagebox.show("chưa thêm hình ảnh cho bánh", "lỗi", messageboxbutton.ok, messageboximage.warning);

        //    }else
        //    {
        //        var info = new fileinfo(pathimage);
        //        string basefolder = appdomain.currentdomain.basedirectory;
        //        basefolder += "image\\cakes\\";
        //        string nameimage = guid.newguid().tostring();
        //        file.copy(pathimage, basefolder + nameimage + info.extension);
        //        var newcake = new banh
        //        {
        //            id = dataprovider.ins.db.banhs.count() + 1,
        //            mabanh = $"ba{dataprovider.ins.db.banhs.count() + 1}",
        //            tenbanh = name.text.trim(),
        //            sl_ton = amount,
        //            dongia = money,
        //            dvt = unit.text.trim(),
        //            ha_banh = $"cakes\\{nameimage}",
        //            loaibanh = id.maloai,
        //            thongtin = ingredients.text.trim()
                    


        //        };
        //        dataprovider.ins.db.banhs.add(newcake);
        //        dataprovider.ins.db.savechanges();
        //        resettextbox();
        //        messagebox.show($"thêm thành công món {newcake.tenbanh}", "thành công", messageboxbutton.ok, messageboximage.exclamation);

        //    }
        //}
        //private void resettextbox()
        //{
        //    listcombobox.selectedindex = default;
        //    name.text = default;
        //    ingredients.text = default;
        //    count.text = default;
        //    price.text = default;
        //    unit.text = default;
        //}
        //private void image_button(object sender, mousebuttoneventargs e)
        //{
        //    openfiledialog ofd = new openfiledialog();
        //    ofd.multiselect = false;
        //    ofd.filter = "image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        //    if (ofd.showdialog() == true)
        //    {
        //        pathimage = ofd.filename;
        //    }
        //    if (pathimage != "")
        //    {
        //        bitmapimage logo = new bitmapimage();
        //        logo.begininit();
        //        logo.urisource = new uri(pathimage);
        //        logo.endinit();
        //        cakeimage.source = logo;
        //    }
        //}

        //private void window_loaded(object sender, routedeventargs e)
        //{
        //    listcombobox.itemssource = dataprovider.ins.db.loaibanhs.tolist();
        //}

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Drag_Window(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Image_Button(object sender, MouseButtonEventArgs e)
        {

        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {

        }

        private void out_button(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
