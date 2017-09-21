using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

/************************************************************************************
    *命名空间：SControlBase
    *文件名：  ScaleHost
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/13 10:19:27
    *描述： 
/************************************************************************************/

namespace SControlBase
{
    public class ScaleHost : FrameworkElement
    {
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(
            "Scale", typeof(double), typeof(ScaleHost), new PropertyMetadata(0.0));

        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }
    }
}
