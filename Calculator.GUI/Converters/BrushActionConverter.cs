using Calculator.Core.Enum;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Calculator.GUI.Converters
{
    [ValueConversion(typeof(Operations), typeof(SolidColorBrush))]
    public class BrushActionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush tmpBrush = new SolidColorBrush();
            if (value is Operations curOperation)
            {
                try
                {
                    switch (curOperation)
                    {
                        case Operations.Adition:
                            tmpBrush = new SolidColorBrush(Color.FromRgb(128, 178, 45));
                            break;
                        case Operations.Subtraction:
                            tmpBrush = new SolidColorBrush(Color.FromRgb(255, 39, 0));
                            break;
                        case Operations.Multiplication:
                            tmpBrush = new SolidColorBrush(Color.FromRgb(8, 177, 200));
                            break;
                        case Operations.Division:
                            tmpBrush = new SolidColorBrush(Color.FromRgb(253, 229, 0));
                            break;
                    }
                }
                catch { }
            }
            return tmpBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
