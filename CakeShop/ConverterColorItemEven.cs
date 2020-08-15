using MaterialDesignColors.ColorManipulation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CakeShop
{
    class ConverterColorItemEven : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var temp_int = (int)value;          
            //if(temp_int % 2 == 0 )
            //{
            //    //Nếu ID chẳn thì chuyển thành màu Xanh
            //    return System.Windows.Media.Colors.Black; ;
            //}
            //    //Nếu ID lẻ sẽ chuyển thành Hồng
            //return System.Windows.Media.Colors.White;
            if ((bool)value)
            {
                {
                    return System.Windows.Media.Colors.Black;
                }
            }
            return System.Windows.Media.Colors.LightGreen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
