using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

/************************************************************************************
    *命名空间：SControlBase.Converters
    *文件名：  HintProxyFabricConverter
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/13 10:25:31
    *描述： 
/************************************************************************************/

namespace SControlBase.Converters
{
    public class HintProxyFabricConverter : IValueConverter
    {
        private static readonly Lazy<HintProxyFabricConverter> _instance = new Lazy<HintProxyFabricConverter>();

        public static HintProxyFabricConverter Instance => _instance.Value;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return HintProxyFabric.Get(value as Control);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
