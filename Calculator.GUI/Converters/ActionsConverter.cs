using Calculator.Core.Enum;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Calculator.GUI.Converters
{
    [ValueConversion(typeof(Operations),typeof(BitmapImage))]
    public class ActionsConverter : IValueConverter
    {
        String _path = "pack://application:,,,/";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage tempImage = new BitmapImage();
            if (value is Operations curOperation)
            {
                try
                {
                    switch (curOperation)
                    {
                        case Operations.Adition:
                            tempImage = new BitmapImage(new Uri(_path + "Data/Images/plus.png"));
                            break;
                        case Operations.Subtraction:
                            tempImage = new BitmapImage(new Uri(_path + "Data/Images/minus.png"));
                            break;
                        case Operations.Multiplication:
                            tempImage = new BitmapImage(new Uri(_path + "Data/Images/multiplication.png"));
                            break;
                        case Operations.Division:
                            tempImage = new BitmapImage(new Uri(_path + "Data/Images/division.png"));
                            break;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return tempImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
