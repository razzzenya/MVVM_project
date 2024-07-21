using System;
using System.Globalization;

namespace MVVM_project.Services
{
    static internal class StringToDouble
    {
        public static double MakeDouble(string value)
        {
            if (double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out double doubleValue) ||
                 double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out doubleValue) ||
                 double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
            {
                return doubleValue;
            }

            throw new InvalidOperationException("Неверный ввод числа");
        }
    }
}
