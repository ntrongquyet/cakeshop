using CakeShop.SQL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for HomeUC.xaml
    /// </summary>
    public partial class HomeUC : UserControl
    {
        public HomeUC()
        {
            InitializeComponent();
        }

        private void order_button(object sender, MouseButtonEventArgs e)
        {
            DataContext = new BillUC();
            this.Content = new BillUC();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Listbox_Cake.ItemsSource = DataProvider.Ins.DB.BANHs.ToList();
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Hover_Image(object sender, MouseEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, EventArgs e)
        {

        }
    }
}
