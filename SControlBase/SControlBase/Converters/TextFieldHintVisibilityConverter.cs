using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

/************************************************************************************
    *命名空间：SControlBase.Converters
    *文件名：  TextFieldHintVisibilityConverter
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/14 11:39:15
    *描述： 
/************************************************************************************/

namespace SControlBase.Converters
{
    public class TextFieldHintVisibilityConverter : IValueConverter
    {
        public Visibility IsEmptyValue { get; set; } = Visibility.Visible;
        public Visibility IsNotEmptyValue { get; set; } = Visibility.Hidden;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty((value ?? "").ToString()) ? IsEmptyValue : IsNotEmptyValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
