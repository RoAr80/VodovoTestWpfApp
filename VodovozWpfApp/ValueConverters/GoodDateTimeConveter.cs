using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VodovozWpfApp
{
    public class GoodDateTimeConveter : BaseValueConverter<GoodDateTimeConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Без этого if можно жить
            
            return ((DateTime)value).ToString("MMMM dd, yyyy hh:mm:ss");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
