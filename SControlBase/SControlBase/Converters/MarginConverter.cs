using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using WpfPresentationControl;

/************************************************************************************
    *命名空间：SControlBase.Converters
    *文件名：  MarginConverter
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/30 9:04:24
    *描述： 
/************************************************************************************/

namespace SControlBase.Converters
{
    class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MarginData data = (MarginData)value;
            Thickness margin = new Thickness();
            margin.Left = data.LEFT;
            margin.Top = data.TOP;
            margin.Right = data.RIGHT;
            margin.Bottom = data.BOTTON;
            return data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Thickness margin = (Thickness)value;
            MarginData data = new MarginData();
            data.LEFT = margin.Left;
            data.TOP = margin.Top;
            data.RIGHT = margin.Right;
            data.BOTTON = margin.Bottom;
            return data;
        }
    }
}
