using CakeShop.SQL;
using System;
using System.Collections;
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
    /// Interaction logic for UpdateUC.xaml
    /// </summary>
    public partial class UpdateUC : UserControl
    {
        public UpdateUC()
        {
            InitializeComponent();
        }

        public IEnumerable tempList { get; private set; }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tempList = DataProvider.Ins.DB.BANHs.ToList();
            Listbox_Cake.ItemsSource = tempList;
        }

        private void update_Click(object sender, MouseButtonEventArgs e)
        {
            UpdateCake up = new UpdateCake();
            up.Show();
        }
    }
}
