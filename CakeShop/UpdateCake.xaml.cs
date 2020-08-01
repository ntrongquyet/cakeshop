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
    /// Interaction logic for UpdateCake.xaml
    /// </summary>
    public partial class UpdateCake : Window
    {
        public UpdateCake()
        {
            InitializeComponent();
        }

        private void out_button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
