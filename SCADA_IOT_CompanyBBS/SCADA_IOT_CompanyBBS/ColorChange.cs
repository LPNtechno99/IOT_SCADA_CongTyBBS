using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SCADA_IOT_CompanyBBS
{
    public class ColorMachineState : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Machine.Machine3State)
            {
                switch ((Machine.Machine3State)value)
                {
                    case Machine.Machine3State.NONE:
                        return null;
                    case Machine.Machine3State.RUNNING:
                        return new SolidColorBrush(Color.FromRgb(100, 243, 106));
                    case Machine.Machine3State.STOPPING:
                        return new SolidColorBrush(Color.FromRgb(249, 241, 69));
                    case Machine.Machine3State.FAILING:
                        return new SolidColorBrush(Color.FromRgb(243, 112, 63));
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ColorDoorState : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Machine.MachineDoorStatus)
            {
                if((Machine.MachineDoorStatus)value==Machine.MachineDoorStatus.OPEN)
                {
                    return new SolidColorBrush(Color.FromRgb(243, 112, 63));
                }
                if((Machine.MachineDoorStatus)value == Machine.MachineDoorStatus.CLOSE)
                {
                    return new SolidColorBrush(Color.FromRgb(100, 243, 106));
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class FailingColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 2)
            {
                return Brushes.Red;
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
