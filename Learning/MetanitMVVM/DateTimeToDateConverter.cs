﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MetanitMVVM
{
    public class DateTimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && parameter.ToString() == "UA")
            {
                return ((DateTime)value).ToString("MM-dd-yyyy");
            }
            return ((DateTime)value).ToString("dd.MM.yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
