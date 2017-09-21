using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

/************************************************************************************
    *命名空间：SControlBase.Propertys
    *文件名：  TransitionAssist
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/13 9:23:05
    *描述：类的依赖属性 
/************************************************************************************/

namespace SControlBase.Propertys
{
    class TransitionAssist
    {
        /// <summary>
        /// Allows transitions to be disabled where supported.  Note this is an inheritable property.
        /// </summary>
        public static readonly DependencyProperty DisableTransitionsProperty = DependencyProperty.RegisterAttached(
            "DisableTransitions", typeof(bool), typeof(TransitionAssist), new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Allows transitions to be disabled where supported.  Note this is an inheritable property.
        /// </summary>
        public static void SetDisableTransitions(DependencyObject element, bool value)
        {
            element.SetValue(DisableTransitionsProperty, value);
        }

        /// <summary>
        /// Allows transitions to be disabled where supported.  Note this is an inheritable property.
        /// </summary>
        public static bool GetDisableTransitions(DependencyObject element)
        {
            return (bool)element.GetValue(DisableTransitionsProperty);
        }
    }
}
