using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

/************************************************************************************
    *命名空间：SControlBase.Converters
    *文件名：  MathConverter
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/13 10:12:56
    *描述： 
/************************************************************************************/

namespace SControlBase.Converters
{
    public enum MathOperation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public sealed class MathConverter : IValueConverter
    {
        public MathOperation Operation { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double value1 = System.Convert.ToDouble(value, CultureInfo.InvariantCulture);
                double value2 = System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);
                switch (Operation)
                {
                    case MathOperation.Add:
                        return value1 + value2;
                    case MathOperation.Divide:
                        return value1 / value2;
                    case MathOperation.Multiply:
                        return value1 * value2;
                    case MathOperation.Subtract:
                        return value1 - value2;
                    default:
                        return Binding.DoNothing;
                }
            }
            catch (FormatException)
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
