﻿using CakeShop.SQL;
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

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var data = Listbox_Cake.SelectedItem as BANH;
            if (data != null)
            {
                DetailCake dt = new DetailCake(data.MABANH);
                dt.Show();
            }
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

        private void Botton_BackHome(object sender, MouseButtonEventArgs e)
        {
            DataContext = new HomeUC();
            this.Content = new HomeUC();
        }
    }
}
