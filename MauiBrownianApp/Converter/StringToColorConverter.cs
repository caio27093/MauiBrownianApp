using System;
using System.Globalization;

namespace MauiBrownianApp.Converter;

public class StringToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string stringValue)
        {
            try
            {
                return Color.FromArgb(stringValue);
            }
            catch (Exception)
            {
            }
        }

        return Color.FromArgb("#FFF");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush brushValue)
        {
            try
            {
                return brushValue.Color.ToHex();
            }
            catch (Exception)
            {
            }
        }
        else if (value is Color cor)
        {
            if (cor.Red < 0 || cor.Red > 255 || cor.Green < 0 || cor.Green > 255 || cor.Blue < 0 || cor.Blue > 255 || cor.Alpha < 0 || cor.Alpha > 255)
            {
                return "#FFF";
            }

            int intR = (int)(cor.Red * 255);
            int intG = (int)(cor.Green * 255);
            int intB = (int)(cor.Blue * 255);

            // Converter os valores inteiros para sua representação hexadecimal
            string hexR = intR.ToString("X2");
            string hexG = intG.ToString("X2");
            string hexB = intB.ToString("X2");

            string hexColor = $"#{hexR}{hexG}{hexB}";

            return hexColor;
        }
        return "FFF";
    }
}