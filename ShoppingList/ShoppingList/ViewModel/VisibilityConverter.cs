using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ShoppingList.ViewModel
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo? culture)
        {
            return value is ShoppingListItemModel ? "Visible" : "Hidden";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
