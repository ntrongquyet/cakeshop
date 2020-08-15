using CakeShop.User_Control;
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

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Home_Button(object sender, MouseButtonEventArgs e)
        {
            DataContext = new HomeUC();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeUC();
        }

        private void Bill_Button(object sender, MouseButtonEventArgs e)
        {
            DataContext = new BillUC();
        }

        private void New_Button(object sender, MouseButtonEventArgs e)
        {
            AddNewDialog add = new AddNewDialog();
            add.ShowDialog();
        }

        private void Update_Button(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UpdateUC();
        }

        private void Static_Button(object sender, MouseButtonEventArgs e)
        {
            DataContext = new StatisticsUCVers2();
        }

        private void Info_Button(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoUC();
        }
    }
}
