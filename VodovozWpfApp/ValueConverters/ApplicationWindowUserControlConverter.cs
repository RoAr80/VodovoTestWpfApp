using System;
using System.Diagnostics;
using System.Globalization;

namespace VodovozWpfApp
{
    public class ApplicationWindowUserControlConverter : BaseValueConverter<ApplicationWindowUserControlConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((AppPageEnum)value)
            {
                case AppPageEnum.EmployeesControlPage:
                    return new EmployeesControlPage();
                case AppPageEnum.SubdivisionsControlPage:
                    return new SubdivisionsControlPage();
                case AppPageEnum.OrdersControlPage:
                    return new OrdersControlPage();
                case AppPageEnum.EmployeePage:
                    return new EmployeePage();
                case AppPageEnum.SubdivisionPage:
                    return new SubdivisionPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
